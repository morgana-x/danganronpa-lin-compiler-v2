using System.Text;

namespace LinLib.LIN;

internal static class ScriptWrite
{
    public static void WriteSource(Script s, StreamWriter file, Game game = Game.Base, bool append = false)
    {
        var indentLevel = 0;
        var shouldPlaceBracket = 0;
        var shouldPlaceBrackedChoice = 0;
        var textEntryId = 0;
        foreach (var e in s.ScriptData)
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (e.Opcode == 0x02)
            {
                file.Write("//text " + textEntryId);
                file.WriteLine();
                textEntryId++;
            }

            if (e.Opcode is 0x2B or 0x29 or 0x27 && shouldPlaceBrackedChoice > 0)
            {
                shouldPlaceBrackedChoice -= 1;
                if (indentLevel > 0) indentLevel -= 1;
                file.Write(new string('\t', indentLevel));
                file.Write('}');
                file.Write('\n');
                if (e.Opcode is 0x29 or 0x27) indentLevel = 0;
            }

            if (e.Opcode is 0x29 or 0x27 &&
                shouldPlaceBracket >
                0) // || (s.ScriptData.IndexOf(e) + 1 < s.ScriptData.Count) && s.ScriptData[s.ScriptData.IndexOf(e) + 1].Opcode == 0x29)))
            {
                shouldPlaceBracket -= 1;
                if (indentLevel > 0) indentLevel -= 1;
                file.Write(new string('\t', indentLevel));
                file.Write('}');
                file.Write('\n');
            }

            /*
            if (e.Opcode == 0x29 || e.Opcode == 0x27) // CheckObject, Check Character
            {

                if (indentLevel > 0)
                {
                    indentLevel -= 1;//-= 1;
                }
                indentLevel += 1;
                if (shouldPlaceBracket > 0)
                {
                    shouldPlaceBracket -= 1;
                    File.WriteLine("}");
                }

            }
            */
            if (s.ScriptData.IndexOf(e) > 1 &&
                s.ScriptData[s.ScriptData.IndexOf(e) - 2].Opcode == 0x3C) // If flag check
            {
                if (indentLevel > 0) indentLevel -= 1;
                if (shouldPlaceBracket > 0) shouldPlaceBracket -= 1;
                file.Write(new string('\t', indentLevel));
                file.Write('}');
                file.Write('\n');
            }

            if (indentLevel > 0) file.Write(new string('\t', indentLevel));
            //File.Write(new string('\t', ((indentLevel > 0 && (e.Opcode == 0x29 || e.Opcode == 0x27)) ? indentLevel - 1 : indentLevel)));
            file.Write(Opcode.GetOpName(e.Opcode, game));
            if (e.Opcode == 0x02)
            {
                var text = e.Text;
                if (text.EndsWith('\0')) text = text.Replace("\0", string.Empty);

                // Escapes
                text = text.Replace("\\", @"\\");
                text = text.Replace("\"", "\\\"");
                text = text.Replace("\r", "\\r");
                text = text.Replace("\n", "\\n");


                file.Write("(\"" + text + "\")");
            }
            else
            {
                file.Write("(");
                if (e.Args.Length > 0)
                    for (var a = 0; a < e.Args.Length; a++)
                    {
                        if (a > 0) file.Write(", ");
                        file.Write(Opcode.GetOpcodeById(e.Opcode, game).DecompileArg(game, e.Args, a, e.Args[a]));
                    }

                file.Write(")");
            }

            file.WriteLine();
            if (e.Opcode is 0x29 or 0x27 or 0x3C or 0x2B) // Check Object, Check Character, If_Flag
            {
                file.Write(new string('\t', indentLevel));
                file.Write('{');
                file.Write('\n');
                indentLevel += 1;
                if (e.Opcode != 0x2B)
                    shouldPlaceBracket += 1;
                else
                    shouldPlaceBrackedChoice += 1;
            }

            if (s.ScriptData.IndexOf(e) == s.ScriptData.Count - 1 && shouldPlaceBrackedChoice > 0)
            {
                shouldPlaceBrackedChoice -= 1;

                if (indentLevel > 0) indentLevel -= 1;
                file.WriteLine(new string('\t', indentLevel) + '}');
            }

            if (s.ScriptData.IndexOf(e) != s.ScriptData.Count - 1 || shouldPlaceBracket <= 0) continue;
            shouldPlaceBracket -= 1;
            if (indentLevel > 0) indentLevel -= 1;
            file.WriteLine(new string('\t', indentLevel) + '}');
        }

        if (!append) file.Close();
    }

    public static void WriteSource(Script s, string filename, Game game = Game.Base, bool append = false)
    {
        var file = new StreamWriter(filename, false, Encoding.UTF8);
        WriteSource(s, file, game, append);
    }

    public static void WriteCompiled(Script s, string filename)
    {
        var file = new List<byte>();

        // Header
        file.AddRange(BitConverter.GetBytes((int)s.Type));
        file.AddRange(BitConverter.GetBytes(s.Type == ScriptType.Text ? 16 : 12));
        switch (s.Type)
        {
            case ScriptType.Textless:
                break;
            case ScriptType.Text:
                file.AddRange(BitConverter.GetBytes(s.TextBlockPos));
                break;
            default: throw new Exception("[write] error: unknown script type.");
        }

        file.AddRange(BitConverter.GetBytes(s.FileSize));

        var textData = new Dictionary<int, string>();
        if (s.Type == ScriptType.Text)
        {
            s.TextEntries = 0;
            foreach (var e in s.ScriptData.Where(e => e.Opcode == 0x02))
            {
                while (textData.ContainsKey(s.TextEntries)) s.TextEntries++;
                textData.Add(s.TextEntries, e.Text);

                e.Args[0] = (byte)((s.TextEntries >> 8) & 0xFF);
                e.Args[1] = (byte)(s.TextEntries & 0xFF);

                s.TextEntries++;
            }

            s.TextEntries = Math.Max(s.TextEntries, textData.Keys.Max() + 1);
        }

        foreach (var e in s.ScriptData)
        {
            file.Add(0x70);
            file.Add(e.Opcode);
            file.AddRange(e.Args);
        }

        while (file.Count % 4 != 0) file.Add(0x00);

        s.TextBlockPos = file.Count;
        for (var i = 0; i < 4; i++) file[0x08 + i] = BitConverter.GetBytes(s.TextBlockPos)[i];

        switch (s.Type)
        {
            case ScriptType.Textless:
                s.FileSize = s.TextBlockPos;
                break;
            case ScriptType.Text:
            {
                file.AddRange(BitConverter.GetBytes(s.TextEntries));
                var startPoints = new int[s.TextEntries];
                var total = 8 + s.TextEntries * 4;

                for (var i = 0; i < s.TextEntries; i++)
                {
                    var text = "";
                    if (textData.TryGetValue(i, out var value)) text = value;
                    if (!text.EndsWith('\0')) text += '\0';

                    var byteText = Encoding.Unicode.GetBytes(text);
                    if (byteText[0] != 0xFF || byteText[1] != 0xFE)
                    {
                        var temp = new byte[byteText.Length + 2];
                        temp[0] = 0xFF;
                        temp[1] = 0xFE;
                        byteText.CopyTo(temp, 2);
                        byteText = temp;
                    }

                    startPoints[i] = total;
                    total += byteText.Length;
                }

                foreach (var sp in startPoints) file.AddRange(BitConverter.GetBytes(sp));
                file.AddRange(BitConverter.GetBytes(total));

                for (var i = 0; i < s.TextEntries; i++)
                {
                    var text = "";
                    if (textData.TryGetValue(i, out var value)) text = value;
                    if (!text.EndsWith('\0')) text += '\0';

                    var byteText = Encoding.Unicode.GetBytes(text);
                    if (byteText[0] != 0xFF || byteText[1] != 0xFE)
                    {
                        var temp = new byte[byteText.Length + 2];
                        temp[0] = 0xFF;
                        temp[1] = 0xFE;
                        byteText.CopyTo(temp, 2);
                        byteText = temp;
                    }

                    file.AddRange(byteText);
                }

                while (file.Count % 4 != 0) file.Add(0x00);
                s.FileSize = file.Count;
                for (var i = 0; i < 4; i++) file[0x0C + i] = BitConverter.GetBytes(s.FileSize)[i];
                break;
            }
            default:
                throw new ArgumentOutOfRangeException(s.Type.ToString(), "Invalid script type.");
        }

        File.WriteAllBytes(filename, file.ToArray());
    }
}