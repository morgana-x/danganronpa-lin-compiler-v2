using System.Text;
using LinLib.LIN;

namespace LinLib.Processors;

/// <summary>
/// Handles dumping of a large set of files
/// </summary>
public static class DumpProcessor
{
    /// <summary>
    /// Dumps all .lin files in a directory into a single .txt file
    /// </summary>
    /// <param name="inPath">Path of the directory</param>
    /// <param name="outFile">Path of the resulting txt file</param>
    /// <param name="game">Danganronpa 1 or Danganronpa 2</param>
    public static void DumpDirectory(string inPath, string outFile, Game game = Game.DANGANRONPA1)
    {
        Console.WriteLine("Dumping files from " + inPath + " to " + outFile);
        var filePathsIn = Directory.GetFiles(inPath);
        var outFileWriter = new StreamWriter(outFile, false, Encoding.Unicode);

        foreach (var filePath in filePathsIn)
        {
            if (!filePath.EndsWith(".lin"))
                continue;
            Console.WriteLine("Processing " + filePath);
            outFileWriter.WriteLine("# [" + filePath + "]");

            try
            {
                var s = new Script(filePath, true, game);
                ScriptWrite.WriteSource(s, outFileWriter, game, true);
            }
            catch
            {
                outFileWriter.WriteLine("CRITICAL ERROR OCCURED WHILE EXTRACTING THE FILE");
            }

            outFileWriter.WriteLine("\n\n\n\n");
        }

        outFileWriter.Dispose();
        outFileWriter.Close();
    }
}