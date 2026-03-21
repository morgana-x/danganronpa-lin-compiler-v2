using System.Text;
using LinLib.dr_lin;

namespace LinLib.LIN;

/// <summary>
/// Script reading functions
/// </summary>
public static class ScriptRead
{
    private static void SkipWhitespace(StreamReader file, ref char c)
    {
        while (c == ' ' || (c == '\t' && file.Peek() != -1))
            c = (char)file.Read();
    }

    private static string ReadString(StreamReader file, StringBuilder sb, ref char c)
    {
        while (c != ' ' && c != '\n' && c != '\r' && file.Peek() != -1)
        {
            sb.Append(c);
            c = (char)file.Read();
        }

        return sb.ToString();
    }

    /// <summary>
    /// Reads a decompiled script
    /// </summary>
    /// <param name="s">The empty script instance</param>
    /// <param name="filename">The decompiled txt file to read</param>
    /// <param name="game">Danganronpa 1 or 2</param>
    /// <returns>Whether the read was successful</returns>
    public static bool ReadSource(Script s, string filename, Game game = Game.BASE)
    {
        var definitionClass = new Definition();
        definitionClass.LoadDefinitions();
        // Default script type is textless
        s.Type = ScriptType.TEXTLESS;
        //Program.PrintLine("[read] reading source file...");
        var file = new StreamReader(filename, Encoding.UTF8);
        var scriptData = new List<ScriptEntry>();
        var sb = new StringBuilder();
        uint sourceLine = 0;
        try
        {
            while (file.Peek() != -1)
            {
                var c = (char)file.Read();
                var e = new ScriptEntry();


                while (char.IsWhiteSpace(c) || c == '{' || c == '}')
                {
                    c = (char)file.Read();
                    if (c == '\n' || c == '\r') sourceLine++;
                    if (c == '/')
                    {
                        c = (char)file.Read();
                        if (c == '/')
                        {
                            while (c != '\n') c = (char)file.Read();
                        }
                        else if (c == '*')
                        {
                            while (true)
                            {
                                c = (char)file.Read();
                                if (c == '*')
                                {
                                    c = (char)file.Read();
                                    if (c == '/') break;
                                }
                            }

                            c = (char)file.Read();
                        }
                    }
                }

                if (file.Peek() == -1) break;

                // Get opcode
                sb.Clear();

                while (c != '(' && file.Peek() != -1)
                {
                    if (sb.Length > 0 && sb[0] == '#' && c == ' ') break;
                    sb.Append(c);
                    c = (char)file.Read();
                }

                if (file.Peek() != -1) c = (char)file.Read();

                if (sb.ToString().Trim().ToLower() == "#define")
                {
                    SkipWhitespace(file, ref c);

                    sb.Clear();
                    var defName = ReadString(file, sb, ref c).Trim();

                    SkipWhitespace(file, ref c);

                    sb.Clear();
                    var defValue = byte.Parse(ReadString(file, sb, ref c).Trim());

                    definitionClass.ScriptDefineDefinition(defName, defValue);
                    continue;
                }

                e.Opcode = Opcode.GetOpcodeByName(sb.ToString().Trim(), game);

                // Get args
                sb.Clear();
                while (char.IsWhiteSpace(c)) c = (char)file.Read();
                if (file.Peek() == -1) break;
                if (e.Opcode == 0x02)
                {
                    while (c != '"' && file.Peek() != -1)
                        c = (char)file.Read();
                    if (file.Peek() != -1) c = (char)file.Read();
                    while (c != '"' && file.Peek() != -1)
                    {
                        if (c == '\\')
                        {
                            var peek = (char)file.Peek();
                            switch (peek)
                            {
                                case '\\':
                                    sb.Append('\\');
                                    break;
                                case '"':
                                    sb.Append('"');
                                    break;
                                case 'n':
                                    sb.Append('\n');
                                    break;
                                case 'r':
                                    sb.Append('\r');
                                    break;
                                default:
                                    sb.Append(c);
                                    break;
                            }
                        }
                        else
                        {
                            sb.Append(c);
                        }

                        c = (char)file.Read();
                    }

                    while (c != ')' && file.Peek() != -1)
                        c = (char)file.Read();

                    s.Type = ScriptType.TEXT;
                    s.TextEntries++;
                    e.Text = sb.ToString();
                    e.Args = new byte[2];
                }
                else
                {
                    while (c != ')' && file.Peek() != -1)
                    {
                        sb.Append(c);
                        c = (char)file.Read();
                    }

                    var args = new List<byte>();
                    if (sb.ToString().Trim().Length > 0)
                        foreach (var a in sb.ToString().Trim().Split(','))
                        {
                            var trimmed = a.Trim();
                            if (!byte.TryParse(trimmed, out var value))
                                value = definitionClass.TryGetDefinitionValue(trimmed, game);
                            args.Add(value);
                        }

                    e.Args = args.ToArray();
                }

                scriptData.Add(e);
            }

            s.ScriptData = scriptData;

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error at line {sourceLine}. ({sb})\n{e}");
            return false;
        }
    }

    /// <summary>
    /// Reads a compiled script file
    /// </summary>
    /// <param name="s">Empty script instance</param>
    /// <param name="bytes">The binary compiled file to read</param>
    /// <param name="game">Danganronpa 1 or 2</param>
    /// <returns>Whether the operation was successfull</returns>
    /// <exception cref="Exception">The given file isn't a compiled file</exception>
    public static bool ReadCompiled(Script s, byte[] bytes, Game game = Game.BASE)
    {
        //Program.PrintLine("[read] reading compiled file...");
        s.File = bytes;
        //Program.PrintLine("[read] reading header...");
        s.Type = (ScriptType)BitConverter.ToInt32(s.File, 0x0);
        s.HeaderSize = BitConverter.ToInt32(s.File, 0x4);
        switch (s.Type)
        {
            case ScriptType.TEXTLESS:
                s.FileSize = BitConverter.ToInt32(s.File, 0x8);
                if (s.FileSize == 0)
                    s.FileSize = s.File.Length;
                s.TextBlockPos = s.FileSize;
                s.ScriptData = ReadScriptData(s, game);
                break;
            case ScriptType.TEXT:
                s.TextBlockPos = BitConverter.ToInt32(s.File, 0x8);
                s.FileSize = BitConverter.ToInt32(s.File, 0xC);
                if (s.FileSize == 0)
                    s.FileSize = s.File.Length;
                s.ScriptData = ReadScriptData(s, game);
                s.TextEntries = BitConverter.ToInt32(s.File, s.TextBlockPos);
                ReadTextEntries(s);
                break;
            default:
                throw new Exception("[read] error: unknown script type.");
        }

        return true;
    }

    private static List<ScriptEntry> ReadScriptData(Script s, Game game = Game.BASE)
    {
        //Program.PrintLine("[read] reading script data...");
        var scriptData = new List<ScriptEntry>();
        for (var i = s.HeaderSize; i < s.TextBlockPos; i++)
            if (s.File[i] == 0x70)
            {
                i++;
                var e = new ScriptEntry
                {
                    Opcode = s.File[i]
                };

                var argCount = Opcode.GetOpcodeArgCount(e.Opcode, game);
                if (argCount == -1)
                {
                    // Vararg
                    var args = new List<byte>();
                    while (s.File[i + 1] != 0x70)
                    {
                        args.Add(s.File[i + 1]);
                        i++;
                    }

                    e.Args = args.ToArray();
                    scriptData.Add(e);
                }
                else
                {
                    e.Args = new byte[argCount];
                    for (var a = 0; a < e.Args.Length; a++)
                    {
                        e.Args[a] = s.File[i + 1];
                        i++;
                    }

                    scriptData.Add(e);
                }
            }
            else
            {
                // EOF?
                while (i < s.TextBlockPos)
                {
                    if (s.File[i] != 0x00)
                    {
                        Console.WriteLine($"[read] error: expected 0x00, got 0x{s.File[i]:X2}.");
                        Console.WriteLine(
                            "SCRIPT IS NOW BROKEN, please check the last opcode at the end of the file and report the error! (If you're feeling generous :)");
                        break;
                        //throw new Exception("[read] error: expected 0x00, got 0x" + s.File[i].ToString("X2") + ".");
                    }

                    i++;
                }

                return scriptData;
            }

        return scriptData;
    }

    private static void ReadTextEntries(Script s)
    {
        //Program.PrintLine("[read] reading text entries...");
        foreach (var t in s.ScriptData)
            if (t.Opcode == 0x02)
            {
                var first = t.Args[0];
                var second = t.Args[1];
                var textId = (first << 8) | second;

                if (textId >= s.TextEntries) throw new Exception("[read] error: text id out of range.");

                var textPos = BitConverter.ToInt32(s.File, s.TextBlockPos + (textId + 1) * 4);
                var nextTextPos = BitConverter.ToInt32(s.File, s.TextBlockPos + (textId + 2) * 4);
                if (textId == s.TextEntries - 1) nextTextPos = s.FileSize - s.TextBlockPos;
                t.Text =
                    Encoding.Unicode.GetString(s.File, s.TextBlockPos + textPos + 2, nextTextPos - textPos - 2);
            }
            else
            {
                t.Text = null!;
            }
    }
}