using LinLib.LIN;

namespace LinLib.Processors;

/// <summary>
/// Batch processing handler
/// </summary>
public class BatchProcessor : BaseProcessor
{
    private bool decompileScripts;

    private string outFolder;
    
    public BatchProcessor(string folder, string? outPath, Game game, bool decompile, bool async = false)
    {
        decompileScripts = decompile;
        outFolder = outPath;
        
        prepareDirectory(folder, decompileScripts, ref outFolder);
        
        processFolder(outFolder, game, async);
    }

    public override void processScript(KeyValuePair<string, Script> s)
    {
        Console.WriteLine($"Processing {s.Key}");
        
        string outPath = outFolder + "/" + Path.GetFileNameWithoutExtension(s.Key) + (decompileScripts ? ".txt" : ".lin");

        try
        {
            if (decompileScripts)
                ScriptWrite.WriteSource(s.Value, outPath);
            else
                ScriptWrite.WriteCompiled(s.Value, outPath, s.Value.Game);
        }
        catch(Exception e)
        {
            Console.Error.WriteLine(e.ToString());
        }
    }
}