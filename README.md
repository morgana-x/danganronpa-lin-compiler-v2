# Lin Compiler (library)
====================================

Fork of lin_compiler that converts the program to a library.

[Script Dumps](https://github.com/morgana-x/Danganronpa-Script-Dumps) that can help you find what script you want to edit.

[Wad Extractor](https://github.com/morgana-x/WadLib) that can help you extract only the script files you need by searching for them. (Rather than extract the whole archive)

## LinLib
### LIN script compiler / decompiler.

To use the library, simply initialize a LinLib class, and call one of the following methods:

Note: Every time a method asks for an `int game`, 0 = Danganronpa 1 and 1 = Danganronpa 2

- `DumpDirectory(string input, string output, int game)` - Takes in the path of a directory, and dumps the contents of all lin files to a single .txt file.
- `BatchDecompileDirectory(string input, string output, int game)` - Takes in the path of a directory and converts every .lin file to separate .txt files in `output`.
- `BatchCompileDirectory(string input, string output, int game)` - Takes in the path of a directory and converts every .txt file to separate .lin files in `output`.
- `DecompileLin(string input, string output, int game)` - Takes in the path of a .lin file and converts it to a .txt file in `output` (must include name of output file).
- `CompileLin(string input, string output, int game)`- Takes in the path of a .txt file and converts it to a .lin file in `output` (must include name of output file).

### Please refer to the original repo for more information.