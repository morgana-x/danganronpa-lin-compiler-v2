<s>Dragontoppa</s> Danganronpa tools
====================================

Tools for translating Danganronpa (PC version).

## `lin_compiler`
### New Stuff!
This fork allows source / decompiled files to have:
+ Comments
+ Squiqqly Brackets {}

When decompiling it will automatically add indentation and {}s for readability

Also adds the --dump argument, 
+ write the decompiled contents of all the lin files in the in folder to the designated text document.

Example: `lin_compiler --dump infolder\ output.txt`

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

