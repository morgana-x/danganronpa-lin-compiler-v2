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
+ Squiqqly Brackets {}

There are also more Opcode translations

When decompiling it will automatically add indentation and {}s for readability

Also adds the --dump argument, 
+ write the decompiled contents of all the lin files in the in folder to the designated text document.

Example: `lin_compiler --dump infolder\ output.txt`

