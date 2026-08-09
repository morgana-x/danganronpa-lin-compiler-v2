using System.Text;
using LinLib.LIN;

namespace LinLib.Processors;

/// <summary>
/// Handles dumping of a large set of files
/// </summary>
public class DumpProcessor : BaseProcessor
{ 
    StreamWriter dumpWriter;
    
    /// <summary>
    /// Dumps all .lin files in a directory into a single .txt file
    /// </summary>
    /// <param name="inPath">Path of the directory</param>
    /// <param name="outFile">Path of the resulting txt file</param>
    /// <param name="game">Danganronpa 1 or Danganronpa 2</param>
    public DumpProcessor(string inPath, string outPath, Game game = Game.DANGANRONPA1)
    {
        dumpWriter = new StreamWriter(outPath, false, Encoding.UTF8);
        
        processFolder(inPath, game, false);
        
        dumpWriter.Dispose();
        dumpWriter.Close();
    }
    
    public override void processScript(KeyValuePair<string, Script> s)
    {
        Console.WriteLine($"Processing {s.Key}");
        
        dumpWriter.WriteLine("# " + Path.GetFileNameWithoutExtension(s.Key) + ".lin");
        try
        {
            ScriptWrite.WriteSource(s.Value, dumpWriter, s.Value.Game, true);
        }
        catch(Exception e)
        {
            dumpWriter.WriteLine("CRITICAL ERROR OCCURED WHILE WRITING THE FILE");
            dumpWriter.WriteLine(e.ToString());
            dumpWriter.WriteLine("Last opcode: 0x" + s.Value.ScriptData.Last().Opcode.ToString("X"));
        }

        dumpWriter.WriteLine("\n\n\n\n");
    }
}