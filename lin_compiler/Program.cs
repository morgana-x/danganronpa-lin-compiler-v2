using CommandLine;
using LinLib;
using LinLib.LIN;
using LinLib.Processors;

namespace lin_compiler
{
    public static class Program
    {
        public class Options
        {
            [Value(0)]
            public IEnumerable<string> Props
            {
                get;
                set;
            }
            
            // Need duplicate dr2 / danganronpa2 options for work around with library + backwards compatibility with old args
            [Option( "dr2", Required = false, HelpText = "Danganronpa 2 Mode")]
            public bool Danganronpa2 { get; set; }
            
            [Option("danganronpa2", Required = false, HelpText = "Danganronpa 2 Mode (Longer name backwards compatibility)")]
            public bool Danganronpa2Other { get; set; }
            
            [Option('s', "silent", Required = false, HelpText = "Silent mode")]
            public bool Silent { get; set; }
            
            [Option('a', "async", Required = false, HelpText = "Async mode")]
            public bool Async { get; set; }
            
            [Option('d', "decompile", Required = false, HelpText = "Decompile mode")]
            public bool Decompile { get; set; }
            
            [Option('b', "dump", Required = false, HelpText = "Dump mode")]
            public bool Dump { get; set; }
            
            [Option('r', "replace", Required = false, HelpText = "Strings to replace")]
            public IEnumerable<string> Replacements { get; set; }
        }

        static string TrimExtension(string path)
        {
            int len = path.LastIndexOf('.');
            return len == -1 ? path : path.Substring(0, len);
        }


        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(Run);
        }

        static void Run(Options o)
        {
            // Combine the "dr2" / "danganronpa2" args
            o.Danganronpa2 = o.Danganronpa2 || o.Danganronpa2Other;
            
            Game game = Game.BASE;

            if (o.Danganronpa2)
                game = Game.DANGANRONPA2;
 
            string input, output;
           
            if (o.Props.Count() < 1)
            {
                throw new Exception("error: incorrect arguments.");
            }
            else
            {
                input = o.Props.ElementAt(0);
                output =  o.Props.Count() >= 2 ? o.Props.ElementAt(1) : TrimExtension(input) + (o.Decompile ? ".txt" : ".lin");
            }

            // Generate opcode name lookup
            Opcode.GenerateOpcodeLookup();

            if (o.Dump)
            {
                Console.WriteLine("Dumping files to \"" + output + "\"...");
                LinApi.DumpDirectory(input, output, game);
                return;
            }

            Dictionary<string, string> replacements = new Dictionary<string, string>();
            if (o.Replacements.Any())
            {
                for (int i = 0; i < o.Replacements.Count() - 1; i += 2)
                    replacements[o.Replacements.ElementAt(i)] = o.Replacements.ElementAt(i + 1);
            }

            if (Directory.Exists(input))
            {
                if (o.Replacements.Any())
                {
                    new ReplaceProcessor(input, o.Props.Count() >= 2 ? o.Props.ElementAt(1) : string.Empty, game, replacements,  o.Decompile, o.Async);
                    return;
                }

                new BatchProcessor(input, o.Props.Count() >= 2 ? o.Props.ElementAt(1) : string.Empty, game, o.Decompile, o.Async);
                return;

            }

            // Execute desired functionality
            Script s = new Script(input, o.Decompile, game);

            if (o.Replacements.Any())
                ReplaceProcessor.DoReplace(s, replacements);
            
            if (o.Decompile)
            {
                ScriptWrite.WriteSource(s, output, game);
            }
            else
            {
                ScriptWrite.WriteCompiled(s, output, game);
            }
        }
    }
}