using System.Globalization;

#pragma warning disable 1591

namespace LinLib.LIN;

public enum Game
{
    BASE,
    DANGANRONPA1 = BASE,
    DANGANRONPA2
}

public class ChangeUiOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrUi), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class SpeakerOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class FlagOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
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

public class CheckFlagOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
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

public class SpriteOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
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

public class VoiceOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrChapter), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class StudentEntryOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class GameStateOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 3 && args[0] == 0 && args[1] == 0 && args[2] == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrTime), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class ScreenFadeOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
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

public class PostProcessingEffectOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrFilter), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class SkillOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetSkillEnum(game), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class MusicOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetBgmEnum(game), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class PresentOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(Enums.GetPresentEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1)
        {
            var name = Enum.GetName(typeof(Enums.DrArithmetic), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

public class Opcode
{
    private static readonly Dictionary<Game, Dictionary<string, byte>> OpcodesByName = new();

    private static readonly Dictionary<Game, Dictionary<byte, Opcode>> Opcodes = new()
    {
        {
            Game.DANGANRONPA1, new Dictionary<byte, Opcode>
            {
                { 0x00, new Opcode(null, 2) },
                { 0x01, new Opcode("LoadSprite", 3) }, // Mostly Unknown 
                { 0x02, new Opcode("Text", 2) },
                {
                    0x03, new Opcode("TextboxFormat", 1)
                }, // Textbox format, 0 = other char speaking, 4 = player character speaking / thoughts
                { 0x04, new PostProcessingEffectOpcode("PostProcessingFilter", 4) }, // 0 No Filter, 1 Sepia Tone
                { 0x05, new Opcode("Movie", 2) },
                { 0x06, new Opcode("Animation", 8) },
                { 0x08, new VoiceOpcode("Voice", 5) },
                { 0x09, new MusicOpcode("Music", 3) },
                { 0x0A, new Opcode("Sound", 3) },
                { 0x0B, new Opcode("SoundB", 2) },
                { 0x0C, new Opcode("AddTruthBullets", 2) },
                { 0x0D, new PresentOpcode("AddPresents", 3) },
                { 0x0E, new SkillOpcode("UnlockSkill", 2) },
                { 0x0F, new StudentEntryOpcode("StudentTitleEntry", 3) },
                { 0x10, new StudentEntryOpcode("StudentReportInfo", 3) },
                { 0x11, new Opcode(null, 4) }, // Relationship setting?
                { 0x14, new Opcode("TrialCamera", 3) }, //Character, Motion, Position
                { 0x15, new Opcode("LoadMap", 3) }, // Room, State, Padding, Time of Day
                { 0x19, new Opcode("LoadScript", 3) },
                { 0x1A, new Opcode("StopScript", 0) },
                { 0x1B, new Opcode("RunScript", 3) },
                { 0x1C, new Opcode("RestartScript", 0) },
                { 0x1E, new SpriteOpcode("Sprite", 5) },
                { 0x1F, new Opcode("ScreenFlash", 7) },
                { 0x20, new Opcode("SpriteFlash", 5) },
                { 0x21, new SpeakerOpcode("Speaker", 1) },
                { 0x22, new ScreenFadeOpcode("ScreenFade", 3) },
                { 0x23, new Opcode("ObjectState", 5) },
                { 0x25, new ChangeUiOpcode("ChangeUi", 2) },
                {
                    0x26, new FlagOpcode("SetFlag", 3)
                }, // Argument 1 is the group, argument 2 is the ID, and argument 3 is the state.
                { 0x27, new Opcode("CheckCharacter", 1) },
                { 0x29, new Opcode("CheckObject", 1) },
                { 0x2A, new Opcode("SetLabel", 2) }, // Arguments 1 and 2 make up the label [ID] // See 0x34
                { 0x2B, new Opcode("SetOption", 1) }, // Choice??
                { 0x2C, new Opcode("EndOfJump", 2) },
                {
                    0x2D, new Opcode("CameraFlash", -1)
                }, // IF CAUSING ISSUE THIS IS THE PROBLEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                { 0x2E, new Opcode("CameraShake", 2) },
                { 0x2F, new Opcode(null, 10) },
                { 0x30, new Opcode("ShowBackground", 3) },
                { 0x32, new Opcode(null, 1) }, // Truth bullet / Choice?
                { 0x33, new GameStateOpcode("SetGameState", 4) },
                { 0x34, new Opcode("GotoLabel", 2) }, // Argument 1 and 2 make up the label [ID]. See 0x2A.
                { 0x35, new CheckFlagOpcode("CheckFlagA", -1) }, // each check is 4 args
                { 0x36, new CheckFlagOpcode("CheckFlagB", -1) }, // each check is 4 args
                { 0x38, new Opcode(null, -1) },
                { 0x39, new Opcode(null, 5) },
                { 0x3A, new Opcode("WaitInput", 0) },
                { 0x3B, new Opcode("WaitFrame", 0) },
                { 0x3C, new Opcode("If_FlagCheck", 0) },
                { 0x4B, new Opcode("WaitInputDR2", -1) },
                { 0x4C, new Opcode("WaitFrameDR2", 0) },
                { 0x4D, new Opcode(null, -1) }
            }
        },

        {
            Game.DANGANRONPA2, new Dictionary<byte, Opcode>
            {
                { 0x01, new Opcode(null, 4) },
                { 0x14, new Opcode(null, 6) },
                { 0x15, new Opcode(null, 4) },
                { 0x19, new Opcode("LoadScript", 5) },
                { 0x1B, new Opcode(null, 5) },
                { 0x29, new Opcode(null, 0xD) },
                { 0x2A, new Opcode(null, 0xC) },
                { 0x2E, new Opcode(null, 5) },
                { 0x30, new Opcode(null, 2) },
                { 0x34, new Opcode(null, 1) },
                { 0x3A, new Opcode("SetGameState", 4) },
                { 0x3B, new Opcode("StartJump", 2) },
                { 0x4B, new Opcode("WaitInput", -1) },
                { 0x4C, new Opcode("WaitFrame", 0) }
            }
        }
    };

    private readonly string? _name;
    private readonly int _numArguments;

    protected Opcode(string? name, int numargs)
    {
        _name = name;
        _numArguments = numargs;
    }

    public virtual string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        return argValue.ToString();
    }

    public static void GenerateOpcodeLookup()
    {
        // Generate opcode lookup dictionary
        foreach (var game in Opcodes.Keys)
        foreach (var op in Opcodes[game].Keys)
            if (Opcodes[game][op]._name != null)
            {
                if (!OpcodesByName.ContainsKey(game))
                    OpcodesByName[game] = new Dictionary<string, byte>();
                var name = Opcodes[game][op]._name;
                if (name != null) OpcodesByName[game][name] = op;
            }
    }

    public static string GetOpName(byte op, Game game = Game.BASE)
    {
        if (game != Game.BASE)
            if (Opcodes[game].ContainsKey(op))
            {
                var opName = Opcodes[game][op]._name;
                if (opName != null)
                    return opName;
            }

        if (Opcodes[Game.BASE].ContainsKey(op))
        {
            var opName = Opcodes[Game.BASE][op]._name;
            if (opName != null)
                return opName;
        }

        return "0x" + op.ToString("X2");
    }

    public static byte GetOpcodeByName(string name, Game game = Game.BASE)
    {
        if (game != Game.BASE)
            if (OpcodesByName[game].ContainsKey(name))
                return OpcodesByName[game][name];
        if (OpcodesByName[Game.BASE].ContainsKey(name))
            return OpcodesByName[Game.BASE][name];
        return byte.Parse(name.Substring(2), NumberStyles.HexNumber);
    }

    public static Opcode GetOpcodeById(byte op, Game game = Game.BASE)
    {
        if (game != Game.BASE)
            if (Opcodes[game].ContainsKey(op))
                return Opcodes[game][op];
        if (Opcodes[Game.BASE].ContainsKey(op))
            return Opcodes[Game.BASE][op];

        return new Opcode("0x" + op.ToString("X2"), -1);
    }

    public static int GetOpcodeArgCount(byte op, Game game = Game.BASE)
    {
        if (game != Game.BASE)
            if (Opcodes[game].ContainsKey(op))
                return Opcodes[game][op]._numArguments;
        if (Opcodes[Game.BASE].ContainsKey(op))
            return Opcodes[Game.BASE][op]._numArguments;
        return -1;
    }
}