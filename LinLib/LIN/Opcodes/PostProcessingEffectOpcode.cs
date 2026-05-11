namespace LinLib.LIN.Opcodes;

public class PostProcessingEffectOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, int[] args, int argIndex, int argValue)
    {
        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrFilter), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}