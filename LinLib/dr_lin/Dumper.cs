using System.Text;
using LinLib.LIN;

namespace LinLib.dr_lin;

internal static class Dumper
{
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