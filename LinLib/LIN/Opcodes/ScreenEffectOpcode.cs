namespace LinLib.LIN.Opcodes;

public class ScreenEffectOpcode : Opcode
{
    internal ScreenEffectOpcode(string? name, int numargs) : base(name, numargs)
    {
    }

    internal ScreenEffectOpcode(string? name, IEnumerable<int> argSizes) : base(name, argSizes)
    {
    }

    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrScreenEffect), args[0]);
            if (name != null)
                return name;
        }
        return base.DecompileArg(game, args, argIndex, argValue);
    }
}