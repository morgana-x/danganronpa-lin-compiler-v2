using LIN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dr_lin
{
    public static class Dumper
    {
        public static void DumpDirectory(string in_path, string out_file, Game game = Game.Danganronpa1)
        {
            Console.WriteLine("Dumping files from " + in_path + " to " + out_file);
            string[] FilePathsIn = Directory.GetFiles(in_path);
            System.IO.StreamWriter OutFileWriter = new System.IO.StreamWriter(out_file, false, Encoding.Unicode);

            foreach (string filePath in FilePathsIn) 
            {
                if (!filePath.EndsWith(".lin"))
                    continue;
                Console.WriteLine("Processing " + filePath);
                OutFileWriter.WriteLine( "# [" + filePath + "]");
       
                try
                {
                    Script s = new Script(filePath, true, game);
                    ScriptWrite.WriteSource(s, OutFileWriter, game, true);
                }
                catch
                {
                    OutFileWriter.WriteLine("CRITICAL ERROR OCCURED WHILE EXTRACTING THE FILE");
                }
                OutFileWriter.WriteLine("\n\n\n\n");
            }
            OutFileWriter.Dispose();
            OutFileWriter.Close();
        }
    }
}
