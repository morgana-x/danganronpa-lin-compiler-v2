namespace LinLib.LIN.Opcodes;

public class CheckFlagAOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0 || argIndex == 5 || argIndex == 10 || argIndex == 15 || argIndex == 20 || argIndex == 25 ||
            argIndex == 30 || argIndex == 35)
        {
            var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 || argIndex == 6 || argIndex == 11 || argIndex == 16 || argIndex == 21 || argIndex == 26 ||
            argIndex == 31 || argIndex == 36)
        {
            if (args[argIndex - 1] == (byte)Enums.DrFlag.FLAG_CHR_DEAD)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
                if (name != null) return name;
            }

            if (args[argIndex - 1] == (byte)Enums.DrFlag.FLAG_SYSTEM)
            {
                var name = Enum.GetName(typeof(Enums.DrFlagSystem), argValue);
                if (name != null) return name;
            }
        }

        if (argIndex == 2 || argIndex == 7 || argIndex == 12 || argIndex == 17 || argIndex == 22 || argIndex == 27 ||
            argIndex == 32 || argIndex == 37)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
            if (name != null) return name;
        }

        if (argIndex == 4 || argIndex == 9 || argIndex == 14 || argIndex == 19 || argIndex == 24 || argIndex == 29 ||
            argIndex == 34 || argIndex == 39)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagJoiner), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class CheckFlagBOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0 || argIndex == 5 || argIndex == 10 || argIndex == 15 || argIndex == 20 || argIndex == 25 ||
            argIndex == 30 || argIndex == 35)
        {
            var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 || argIndex == 6 || argIndex == 11 || argIndex == 16 || argIndex == 21 || argIndex == 26 ||
            argIndex == 31 || argIndex == 36)
        {
            if (args[argIndex - 1] == (byte)Enums.DrFlag.FLAG_CHR_DEAD)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
                if (name != null) return name;
            }

            if (args[argIndex - 1] == (byte)Enums.DrFlag.FLAG_SYSTEM)
            {
                var name = Enum.GetName(typeof(Enums.DrFlagSystem), argValue);
                if (name != null) return name;
            }
        }

        if (argIndex == 2 || argIndex == 7 || argIndex == 12 || argIndex == 17 || argIndex == 22 || argIndex == 27 ||
            argIndex == 32 || argIndex == 37)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
            if (name != null) return name;
        }

        if (argIndex == 4 || argIndex == 9 || argIndex == 14 || argIndex == 19 || argIndex == 24 || argIndex == 29 ||
            argIndex == 34 || argIndex == 39)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagJoiner), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}




public class CheckFlagDOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagD), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 && (args[0] == (byte)Enums.DrFlagD.FLAG_RELATION))
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 2)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}