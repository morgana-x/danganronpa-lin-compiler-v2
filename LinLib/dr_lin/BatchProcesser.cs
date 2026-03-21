using LinLib.LIN;

namespace LinLib.dr_lin;

/// <summary>
/// Batch processing handler
/// </summary>
public static class BatchProcesser
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
        if (string.IsNullOrEmpty(outFolder))
            outFolder = folder + "_" + (decompile ? "extracted" : "repacked");
        if (!outFolder.EndsWith(Path.DirectorySeparatorChar.ToString())) outFolder += Path.DirectorySeparatorChar;
        if (!Directory.Exists(folder))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"There is no folder existent at \"{folder}\"");
            return;
        }

        var files = Directory.GetFiles(folder);
        Console.WriteLine($"{(decompile ? "Decompiling" : "Recompiling")} {files.Length} files...");
        if (!Directory.Exists(outFolder)) Directory.CreateDirectory(outFolder);
        foreach (var file in files)
        {
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

        Console.WriteLine($"Finished {(decompile ? "Decompiling" : "Recompiling")} {files.Length} files!");
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
        if (string.IsNullOrEmpty(outFolder))
            outFolder = folder + "_" + (decompile ? "extracted" : "repacked");
        if (!outFolder.EndsWith(Path.DirectorySeparatorChar.ToString())) outFolder += Path.DirectorySeparatorChar;
        if (!Directory.Exists(folder))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"There is no folder existent at \"{folder}\"");
            return;
        }

        var files = Directory.GetFiles(folder);
        Console.WriteLine($"{(decompile ? "Decompiling" : "Recompiling")} {files.Length} files...");
        if (!Directory.Exists(outFolder)) Directory.CreateDirectory(outFolder);
        await Parallel.ForEachAsync(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
            async (file, _) =>
            {
                var script = new Script(file, decompile, game);
                var outPath = outFolder + Path.GetFileNameWithoutExtension(file) + (decompile ? ".txt" : ".lin");
                Console.WriteLine(outPath);
                try
                {
                    if (decompile)
                    {
                        await ScriptWrite.WriteSourceAsync(script, outPath, game);
                    }
                    else
                    {
                        await ScriptWrite.WriteCompiledAsync(script, outPath);
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error occured while processing {file}. Error:\n{e}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            });
        Console.WriteLine($"Finished {(decompile ? "Decompiling" : "Recompiling")} {files.Length} files!");
    }
}