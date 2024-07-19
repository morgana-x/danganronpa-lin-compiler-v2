using LIN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dr_lin
{
    public class BatchProcesser
    {
        public static void BatchProcessDirectory (string folder, bool decompile, Game game, string outFolder)
        {
            if (true || outFolder == null || outFolder == string.Empty)
            {
                outFolder = folder + "_" + (decompile ? "extracted" : "repacked") + "\\";
            }
            if (!Directory.Exists (folder)) 
            {
                return;
            }
            string[] files = Directory.GetFiles (folder);
            Console.WriteLine($"{(decompile ? "Decompiling" : "Recompiling")} {files.Length} files...");
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }
            foreach (string file in files) 
            {
      
                Script script = new Script(file, decompile, game);
                string outPath = outFolder + Path.GetFileNameWithoutExtension(file) + (decompile ? ".txt" : ".lin");
                Console.WriteLine(outPath);
                if (decompile)
                {
                    ScriptWrite.WriteSource(script, outPath, game);
                }
                else
                {
                    ScriptWrite.WriteCompiled(script, outPath, game);
                }

            }
            Console.WriteLine($"Finished {(decompile ? "Decompiling" : "Recompiling")} {files.Length} files!");
        }
    }
}
