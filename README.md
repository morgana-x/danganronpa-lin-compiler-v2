# Lin Compiler
====================================

Tool for compiling and decompiling Danganronpa LIN files

[Script Dumps](https://github.com/morgana-x/Danganronpa-Script-Dumps) that can help you find what script you want to edit.

[Wad Extractor](https://github.com/morgana-x/WadLib) that can help you extract only the script files you need by searching for them. (Rather than extract the whole archive)

## `lin_compiler`
### LIN script compiler / decompiler.

To compile a script file, simply supply the input file (and optionally an
output file). The compiler will spit out a .lin file, which you can add into
the game.  
Example: `lin_compiler input.txt output.lin`

Decompiling works exactly the same, except you supply a -d (or --decompile)
argument.  
Example: `lin_compiler -d input.lin output.txt`

If you are working with Danganronpa 2 script files, you should additionally
pass the `-dr2` (or `--danganronpa2`) argument.

### New Stuff!
This fork allows source / decompiled files to have:
+ Comments (Either using // or /**/, same as c language style commenting)
+ "Synatax", Decompiled files have psuedo indentations/bracketed blocks of code based on certain opcodes
+ Batch processing, allows folders to be supplied, Example: `lin_compiler infolder outfolder --decompile` /  `lin_compiler infolder outfolder`
+ More Opcode names
+ --dump argument, allows you to dump the decompiled contents of a folder of scripts into a singular file, Example: `lin_compiler --dump infolder\ output.txt`
+ Enums and definitions, decompiled files automatically add built-in enums to the file
+ Enums/Definitions can be overrided / created with the `#DEFINE VALUE_NAME VALUE` statement, Examples: `#DEFINE CHR_KAEDE 18`,`#DEFINE CHR_MAKOTO 100` `#DEFINE MY_DEFINITION 200`

