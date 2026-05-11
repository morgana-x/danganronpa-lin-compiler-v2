namespace LinLib.LIN.Opcodes;

public class SpriteOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 1)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 3)
        {
            var name = Enum.GetName(typeof(Enums.DrSpriteState), argValue);
            if (name != null) return name;
        }

        if (argIndex == 4)
        {
            var name = Enum.GetName(typeof(Enums.DrCamDir), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}