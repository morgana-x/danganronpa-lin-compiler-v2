namespace LinLib.LIN.Opcodes;

public class CheckFlagAOpcode(string name, int[] argsizes, bool repeatable=true, bool joiner=true) : Opcode(name, argsizes, repeatable, joiner)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if ( getSegementIndex(argIndex) == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
            if (name != null) return name;
        }

        if ( getSegementIndex(argIndex) == 1)
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

        if ( getSegementIndex(argIndex) == 2)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
            if (name != null) return name;
        }

        if ( getSegementIndex(argIndex) == 4)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagJoiner), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class CheckFlagBOpcode(string name, int[] argsizes, bool repeatable=true, bool joiner=true) : Opcode(name, argsizes, repeatable, joiner)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if ( (getSegementIndex(argIndex) == 0))
        {
            var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
            if (name != null) return name;
        }

        if ( getSegementIndex(argIndex) == 1)
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

        if ( getSegementIndex(argIndex) == 2)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
            if (name != null) return name;
        }

        if ( getSegementIndex(argIndex) == 4)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagJoiner), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}




public class CheckFlagDOpcode(string name, int[] argsizes, bool repeatable=true) : Opcode(name, argsizes, repeatable)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if ( getSegementIndex(argIndex) == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagD), argValue);
            if (name != null) return name;
        }

        if ( (getSegementIndex(argIndex) == 1) && (args[argIndex - 1] == (byte)Enums.DrFlagD.FLAG_RELATION))
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if ( getSegementIndex(argIndex) == 2)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
            if (name != null) return name;
        }
        
        if ( getSegementIndex(argIndex) == 4)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagJoiner), argValue);
            if (name != null) return name;
        }
        return base.DecompileArg(game, args, argIndex, argValue);
    }
}