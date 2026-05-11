namespace LinLib.LIN.Opcodes;

public class TrialCameraOpcode : Opcode
{
    internal TrialCameraOpcode(string? name, int numargs) : base(name, numargs) { }
    internal TrialCameraOpcode(string? name, IEnumerable<int> argSizes) : base(name, argSizes) { }

    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrCamMotion), argValue);
            if (name != null) return name;
        }
        return base.DecompileArg(game, args, argIndex, argValue);
    }

}

public class TrialCameraOpcodeDr2(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }
        
        /* // For now it's best to refer to https://docs.google.com/spreadsheets/d/1ewULVgmZAZ9urdq1nZHiRvUlW3bEwXk-6QgYqUSlKsM/edit?gid=0#gid=0
         // For DR2
        if (argIndex == 2)
        {
            var name = Enum.GetName(typeof(Enums.DrCamMotion), argValue);
            if (name != null) return name;
        }*/
        return base.DecompileArg(game, args, argIndex, argValue);
    }

}