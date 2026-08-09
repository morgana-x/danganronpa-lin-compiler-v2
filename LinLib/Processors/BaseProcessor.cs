using LinLib.LIN;

namespace LinLib.Processors;

public abstract class BaseProcessor
{
    public abstract void processScript(KeyValuePair<string, Script> s);
    
    private async void processScripts(IDictionary<string, Script> scripts, bool async)
    {
        if (async)
        {
            await Parallel.ForEachAsync(scripts, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                async (s, ct) => processScript(s));
        }
        else
        {
            foreach (var s in scripts)
                processScript(s);
        }
    }

    public virtual Script readScript(string file, bool compiled, Game game)
    {
        return new Script(file, compiled, game);
    }

    internal virtual void processFolder(string folder, Game game, bool async = false)
    {
        Dictionary<string, Script> scripts = new Dictionary<string, Script>();

        foreach (var f in Directory.GetFiles(folder))
        {
            try
            {
                if (f.EndsWith(".lin"))
                {
                    scripts.Add(f, new Script(f, true, game));
                    continue;
                }

                if (f.EndsWith(".txt") || f.EndsWith(".d"))
                    scripts.Add(f, new Script(f, false, game));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        var t = Task.Run(() => { processScripts(scripts, async); });
        t.Wait();
    }

    protected void prepareDirectory(string folder, bool decompile, ref string? outFolder)
    {
        if (string.IsNullOrEmpty(outFolder))
            outFolder = folder + "_" + (decompile ? "extracted" : "repacked");
        
        if (!outFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            outFolder += Path.DirectorySeparatorChar;
        
        if (!Directory.Exists(folder))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"There is no folder existent at \"{folder}\"");
            return;
        }
        
        if (!Directory.Exists(outFolder)) 
            Directory.CreateDirectory(outFolder);
        
    }
}