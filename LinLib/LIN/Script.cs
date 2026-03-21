#pragma warning disable 1591

namespace LinLib.LIN;

public enum ScriptType
{
    TEXTLESS = 1,
    TEXT = 2
}

public class ScriptEntry
{
    public byte[] Args = null!;
    public byte Opcode;
    public string Text = null!;
}

public class Script
{
    public byte[] File = null!;
    public int FileSize;
    public int HeaderSize;
    public List<ScriptEntry> ScriptData = null!;
    public int TextBlockPos;
    public int TextEntries;
    public ScriptType Type;

    public Script(string filename, bool compiled = true, Game game = Game.BASE)
    {
        if (compiled)
        {
            if (!ScriptRead.ReadCompiled(this, System.IO.File.ReadAllBytes(filename), game))
                throw new Exception("[load] error: failed to load script.");
        }
        else
        {
            if (!ScriptRead.ReadSource(this, filename, game))
                throw new Exception("[load] error: failed to load script.");
        }
    }
}