namespace LinLib.LIN.Opcodes;

public class ChangeUiOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        string? name;
        if (argIndex == 0)
        {
            name = Enum.GetName(typeof(Enums.DrUi), argValue);
            if (name != null) 
                return name;
        }

        if (argIndex == 1)
        {
            if (args[0] == (byte)Enums.DrUi.UI_HUD)
            {
                name = Enum.GetName(typeof(Enums.DrUiHudAction), argValue);
                if (name != null)
                    return name;
            }
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}