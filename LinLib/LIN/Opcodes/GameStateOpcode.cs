namespace LinLib.LIN.Opcodes;
using LinLib.LIN.Opcodes;


public class GameStateOpcode : Opcode
{
    internal GameStateOpcode(string? name, int numargs) : base(name, numargs)
    {
    }

    internal GameStateOpcode(string? name, IEnumerable<int> argSizes) : base(name, argSizes)
    {
    }

    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrGamestate), argValue);
            if (name != null) return name;
        }
        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrArithmetic), argValue);
            if (name != null) return name;
        }
    
        if (argIndex == 2 && args[0] == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrTime), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}
