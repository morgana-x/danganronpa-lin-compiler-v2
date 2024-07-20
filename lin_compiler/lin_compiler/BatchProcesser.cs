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
            if (outFolder == null || outFolder == string.Empty)
            {
                outFolder = folder + "_" + (decompile ? "extracted" : "repacked");
            }
            if (!outFolder.EndsWith("\\")) 
            {
                outFolder += "\\";
            }
            if (!Directory.Exists (folder)) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There is no folder existent at \"{folder}\"");
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
                try
                {
                    if (decompile)
                    {
                        ScriptWrite.WriteSource(script, outPath, game);
                    }
                    else
                    {
                        ScriptWrite.WriteCompiled(script, outPath, game);
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error occured while processing {file}. Error:\n{e.ToString()}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
            Console.WriteLine($"Finished {(decompile ? "Decompiling" : "Recompiling")} {files.Length} files!");
        }
    }
}
