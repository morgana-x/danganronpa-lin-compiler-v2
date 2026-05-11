namespace LinLib.LIN.Opcodes;

public class StudentEntryOpcode : Opcode
{
    internal StudentEntryOpcode(string? name, int numargs) : base(name, numargs)
    {
    }

    internal StudentEntryOpcode(string? name, IEnumerable<int> argSizes) : base(name, argSizes)
    {
    }

    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}