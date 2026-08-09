using System.Text.RegularExpressions;
using LinLib.LIN;

namespace LinLib.Processors;

public class ReplaceProcessor : BaseProcessor
{
    private string outFolder;

    private bool decompileScripts;


    private IDictionary<string, string> replacements;
    
    
    public ReplaceProcessor(string folder, string? outPath, Game game, IDictionary<string, string> rep, bool decompile = false, bool async = false)
    {
        replacements = rep;
        
        outFolder = outPath;
        decompileScripts = decompile;
        
        prepareDirectory(folder, async, ref outFolder);
        
        processFolder(folder, game, async);
    }

    static bool doReplace(ref string text, IDictionary<string, string> replacements)
    {
        foreach (KeyValuePair<string, string> re in replacements)
        {
            if (Regex.IsMatch(text, re.Key))
            {
                text = Regex.Replace(text, re.Key, re.Value);
                return true;
            }
        }

        return false;
    }

    public static bool DoReplace(Script s, IDictionary<string, string> replacements)
    {
        if (s.Type == ScriptType.Textless)
            return false;
        
        bool changed = false;

        foreach (var data in s.ScriptData)
        {
            if (data.Text == null)
                continue;

            if (doReplace(ref data.Text, replacements))
                changed = true;
        }
        
        return changed;
    }

    public override void processScript(KeyValuePair<string, Script> s)
    {
        if (s.Value.Type == ScriptType.Textless)
            return;
        
        if (!DoReplace(s.Value, replacements))
            return;
        
        Console.WriteLine($"Processing {s.Key} (Found replacement)");
            
        string outPath = outFolder + "/" + Path.GetFileNameWithoutExtension(s.Key) + (decompileScripts ? ".txt" : ".lin");

        try
        {
            if (decompileScripts)
                ScriptWrite.WriteSource(s.Value, outPath);
            else
                ScriptWrite.WriteCompiled(s.Value, outPath, s.Value.Game);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.ToString());
        }
    }
}