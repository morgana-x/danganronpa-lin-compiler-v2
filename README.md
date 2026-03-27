# LinLib
====================================

C# library for compiling and decompiling Danganronpa LIN script files

[Script Dumps](https://github.com/morgana-x/Danganronpa-Script-Dumps) that can help you find what script you want to edit.

[Wad Extractor](https://github.com/morgana-x/WadLib) that can help you extract only the script files you need by searching for them. (Rather than extract the whole archive)

Every exposed method is documented through XML comments. 

## `LinAPI`
### API for the library

For ease of use, an API is included with the library. This static class includes the following calls.

Note: Every time a method asks for an `int game`, 0 = Danganronpa 1 and 1 = Danganronpa 2

- `DumpDirectory(string input, string output, int game)` - Takes in the path of a directory, and dumps the contents of all lin files to a single .txt file.
- `BatchDecompileDirectory(string input, string output, int game)` - Takes in the path of a directory and converts every .lin file to separate .txt files in `output`.
- `BatchDecompileDirectoryAsync(string input, string output, int game)` - Asynchronous overload of BatchDecompileDirectory
- `BatchCompileDirectory(string input, string output, int game)` - Takes in the path of a directory and converts every .txt file to separate .lin files in `output`.
- `BatchCompileDirectoryAsync(string input, string output, int game)` - Asynchronous overload of BatchCompileDirectory
- `DecompileLin(string input, string output, int game)` - Takes in the path of a .lin file and converts it to a .txt file in `output` (must include name of output file).
- `CompileLin(string input, string output, int game)`- Takes in the path of a .txt file and converts it to a .lin file in `output` (must include name of output file).


## `lin_compiler`
### LIN script compiler / decompiler.

LinLib also includes the original lin_compiler command line executable. The following is taken from the original README.md

To compile a script file, simply supply the input file (and optionally an
output file). The compiler will spit out a .lin file, which you can add into
the game.  
Example: `lin_compiler input.txt output.lin`

Decompiling works exactly the same, except you supply a -d (or --decompile)
argument.  
Example: `lin_compiler -d input.lin output.txt`

If you are working with Danganronpa 2 script files, you should additionally
pass the `-dr2` (or `--danganronpa2`) argument.

#### New Stuff!
This fork allows source / decompiled files to have:
+ Comments (Either using // or /**/, same as c language style commenting)
+ "Syntax", Decompiled files have psuedo indentations/bracketed blocks of code based on certain opcodes
+ Batch processing, allows folders to be supplied, Example: `lin_compiler infolder outfolder --decompile` /  `lin_compiler infolder outfolder`
+ More names assigned to Opcodes
+ --dump argument, allows you to dump the decompiled contents of a folder of scripts into a singular file, Example: `lin_compiler --dump infolder\ output.txt`
+ Enums and definitions, decompiled files automatically add built-in enums to specific decompiled opcodes and detect them when compiling
+ Enums/Definitions can be overrided / created with the `#DEFINE VALUE_NAME VALUE` statement, Examples: `#DEFINE CHR_KAEDE 18`,`#DEFINE CHR_MAKOTO 100` `#DEFINE MY_DEFINITION 200`
