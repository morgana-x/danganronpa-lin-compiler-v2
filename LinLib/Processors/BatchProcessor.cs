using LinLib.LIN;

namespace LinLib.Processors;

/// <summary>
/// Batch processing handler
/// </summary>
public static class BatchProcessor
{
    /// <summary>
    /// Batch processes a directory
    /// </summary>
    /// <param name="folder">Folder with the files to be processed</param>
    /// <param name="decompile"> Set whether to decompile .lin files to .txt files or the opposite</param>
    /// <param name="game">Set the game (DR1 or DR2)</param>
    /// <param name="outFolder">Set the output folder for the processed files</param>
    public static void BatchProcessDirectory(string folder, bool decompile, Game game, string? outFolder)
    {
        PrepareDirectory(folder, decompile, ref outFolder);
        
        var files = Directory.GetFiles(folder);
        
        Console.WriteLine($"{(decompile ? "Decompiling" : "Recompiling")} {files.Length} files...");
        
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        foreach (var file in files)
            ProcessFile(file, decompile, game, outFolder);
        
        stopwatch.Stop();
        Console.WriteLine($"Finished {(decompile ? "Decompiling" : "Recompiling")} {files.Length} files!");
        Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
    }

    /// <summary>
    /// Batch processes a directory asynchronously
    /// </summary>
    /// <param name="folder">Folder with the files to be processed</param>
    /// <param name="decompile"> Set whether to decompile .lin files to .txt files or the opposite</param>
    /// <param name="game">Set the game (DR1 or DR2)</param>
    /// <param name="outFolder">Set the output folder for the processed files</param>
    public static async Task BatchProcessDirectoryAsync(string folder, bool decompile, Game game, string? outFolder)
    {
        PrepareDirectory(folder, decompile, ref outFolder);
        
        var files = Directory.GetFiles(folder);
        
        Console.WriteLine($"{(decompile ? "Decompiling" : "Recompiling")} {files.Length} files...");
        
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        

        await Parallel.ForEachAsync(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
            async (file, ct) => ProcessFile(file,  decompile, game, outFolder));
        
        stopwatch.Stop();
        
        Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Finished {(decompile ? "Decompiling" : "Recompiling")} {files.Length} files!");
    }
    
    
    private static void ProcessFile(string file, bool decompile, Game game, string? outFolder)
    {
        if (!file.EndsWith(".lin") && !file.EndsWith(".txt"))
            return;
        
        var script = new Script(file, decompile, game);
        var outPath = outFolder + Path.GetFileNameWithoutExtension(file) + (decompile ? ".txt" : ".lin");
        
        Console.WriteLine(outPath);
        
        try
        {
            if (decompile)
                ScriptWrite.WriteSource(script, outPath, game);
            else
                ScriptWrite.WriteCompiled(script, outPath);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error occured while processing {file}. Error:\n{e}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private static void PrepareDirectory(string folder, bool decompile, ref string? outFolder)
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