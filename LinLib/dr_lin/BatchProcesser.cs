using LinLib.LIN;

namespace LinLib.dr_lin;

internal static class BatchProcesser
{
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
    
}