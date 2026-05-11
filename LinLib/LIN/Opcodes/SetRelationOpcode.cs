namespace LinLib.LIN.Opcodes;

public class SetRelationOpcode : Opcode
{
    internal SetRelationOpcode(string? name, int numargs) : base(name, numargs)
    {
    }

    internal SetRelationOpcode(string? name, IEnumerable<int> argSizes) : base(name, argSizes)
    {
    }

    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrArithmetic), argValue);
            if (name != null) return name;
        }
        return base.DecompileArg(game, args, argIndex, argValue);
    }

}