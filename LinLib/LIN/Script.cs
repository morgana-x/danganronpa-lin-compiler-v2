#pragma warning disable 1591

namespace LinLib.LIN;

public enum ScriptType
{
    Textless = 1,
    Text = 2
}

public class ScriptEntry
{
    public int[] Args = null!;
    public byte Opcode;
    public string? Text = null!;
}

public class Script
{
    public byte[] File = null!;
    public int FileSize;
    public int HeaderSize;
    public List<ScriptEntry>? ScriptData;
    public int TextBlockPos;
    public int TextEntries;
    public ScriptType Type;

    public Definition Definitions;

    public Script(string filename, bool compiled = true, Game game = Game.BASE)
    {
        Definitions = new Definition();
        
        if (compiled)
        {
            if (!ScriptRead.ReadCompiled(this, System.IO.File.ReadAllBytes(filename), game))
                throw new Exception("[load] error: failed to load script.");
        }
        else
        {
            // Need this here for including to work!
            ScriptData = new List<ScriptEntry>();
            
            if (!ScriptRead.ReadSource(this, filename, game))
                throw new Exception("[load] error: failed to load script.");
        }
    }

    public void Include(string filename, Game game = Game.BASE)
    {
        var includedScript = new Script(filename, false, game);
        
        includedScript.Definitions.CopyTo(Definitions);
        
        if (includedScript.ScriptData != null && ScriptData != null)
            ScriptData.AddRange(includedScript.ScriptData);
        
        TextEntries += includedScript.TextEntries;
        
        if (includedScript.Type == ScriptType.Text)
            Type = ScriptType.Text;
    }
}