namespace LinLib.LIN.Opcodes;

public class ScreenFadeOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrFade), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrColour), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}