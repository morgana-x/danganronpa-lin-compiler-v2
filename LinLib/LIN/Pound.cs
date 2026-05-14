namespace LinLib.LIN;

// Preaccessing token like in c / c++
public class Pound
{
    public static Dictionary<string, Action<Script, Game, string[]>> Pounds = new Dictionary<string, Action<Script, Game, string[]>>()
    {
        ["define"] = ( script,  game, args) =>
        {
                if (args.Length < 2)
                    throw new ArgumentException("#define missing arguments! Usage: #define NAME 123");
                
                if (!int.TryParse(args[1], out  int value))
                    throw new ArgumentException($"#DEFINE Could not parse \"{args[1]}\" as a number!");
                
                script.Definitions.ScriptDefineDefinition(args[0], value);
        },
        
        ["include"] = (script, game, args) =>
        {
            if (args.Length < 1)
                throw new ArgumentException("#include missing filepath! EG: #include \"script.txt\"");

            if (!File.Exists(args[0]))
                throw new Exception($"Couldn't find file: {args[0]}!");
            try
            {
                script.Include(args[0]);
            }
            catch (ArgumentException e)
            {
                throw (new Exception($"Error occured trying to include script {args[0]}!"));
            }
        }
    };

    public static bool TryGetPound(string name, out Action<Script, Game, string[]>? pound)
    {
        return Pounds.TryGetValue(name.ToLower(), out pound);
    }
    


}