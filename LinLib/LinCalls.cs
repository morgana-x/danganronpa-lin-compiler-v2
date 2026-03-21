using LinLib.dr_lin;
using LinLib.LIN;

namespace LinLib;

/// <summary>
///     Main Class of linlib
/// </summary>
public static class LinCalls
{
    /// <summary>
    ///     Dumps entire directory into a single text file
    /// </summary>
    /// <param name="input">Directory with the .lin files</param>
    /// <param name="output">Path to generate the final .txt file in</param>
    /// <param name="game">DR1 = 0, DR2 = 1</param>
    public static void DumpDirectory(string input, string output, int game)
    {
        Opcode.GenerateOpcodeLookup();
        Dumper.DumpDirectory(input, output, (Game)game);
    }

    /// <summary>
    ///     Converts every .lin file in a folder into a .txt file
    /// </summary>
    /// <param name="input">Directory with the .lin files</param>
    /// <param name="output">Path to generate the final .txt files in</param>
    /// <param name="game">DR1 = 0, DR2 = 1</param>
    public static void BatchDecompileDirectory(string input, string output, int game)
    {
        Opcode.GenerateOpcodeLookup();
        BatchProcesser.BatchProcessDirectory(input, true, (Game)game, output);
    }

    /// <summary>
    ///     Converts every .txt file in a folder into a .lin file
    /// </summary>
    /// <param name="input">Directory with the .txt files</param>
    /// <param name="output">Path to generate the final .lin files in</param>
    /// <param name="game">DR1 = 0, DR2 = 1</param>
    public static void BatchCompileDirectory(string input, string output, int game)
    {
        Opcode.GenerateOpcodeLookup();
        BatchProcesser.BatchProcessDirectory(input, false, (Game)game, output);
    }

    /// <summary>
    ///     Decompiles a .lin file to a readable .txt file
    /// </summary>
    /// <param name="input">Path to .lin file</param>
    /// <param name="output">Directory to .txt output</param>
    /// <param name="game">DR1 = 0, DR2 = 1</param>
    public static void DecompileLin(string input, string output, int game)
    {
        Opcode.GenerateOpcodeLookup();
        var script = new Script(input, true, (Game)game);
        ScriptWrite.WriteSource(script, output, (Game)game);
    }

    /// <summary>
    ///     Recompiles a .lin file from a .txt file
    /// </summary>
    /// <param name="input">Path to .txt file</param>
    /// <param name="output">Path to .lin output</param>
    /// <param name="game">DR1 = 0, DR2 = 1</param>
    public static void CompileLin(string input, string output, int game)
    {
        Opcode.GenerateOpcodeLookup();
        var script = new Script(input, false, (Game)game);
        ScriptWrite.WriteCompiled(script, output);
    }
}