namespace LinLib.LIN.Opcodes;

public class SetFlagOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 && args[0] == (byte)Enums.DrFlag.FLAG_CHR_DEAD)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 && args[0] == (byte)Enums.DrFlag.FLAG_SYSTEM)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagSystem), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}