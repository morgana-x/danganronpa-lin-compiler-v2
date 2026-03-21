using System.Globalization;

#pragma warning disable 1591

namespace LinLib.LIN;

public enum Game
{
    Base,
    Danganronpa1 = Base,
    Danganronpa2
}

internal class ChangeUiOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 0) return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(typeof(Enums.DrUi), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class SpeakerOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 0) return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class FlagOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex == 0)
        {
            var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 && args[0] == (byte)Enums.DrFlag.FlagChrDead)
        {
            var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
            if (name != null) return name;
        }

        if (argIndex == 1 && args[0] == (byte)Enums.DrFlag.FlagSystem)
        {
            var name = Enum.GetName(typeof(Enums.DrFlagSystem), argValue);
            if (name != null) return name;
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class CheckFlagOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        switch (argIndex)
        {
            case 0 or 5 or 10 or 15 or 20 or 25 or 30 or 35:
            {
                var name = Enum.GetName(typeof(Enums.DrFlag), argValue);
                if (name != null) return name;
                break;
            }
            case 1 or 6 or 11 or 16 or 21 or 26 or 31 or 36:
            {
                if (args[argIndex - 1] == (byte)Enums.DrFlag.FlagChrDead)
                {
                    var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
                    if (name != null) return name;
                }

                if (args[argIndex - 1] == (byte)Enums.DrFlag.FlagSystem)
                {
                    var name = Enum.GetName(typeof(Enums.DrFlagSystem), argValue);
                    if (name != null) return name;
                }

                break;
            }
            case 2 or 7 or 12 or 17 or 22 or 27 or 32 or 37:
            {
                var name = Enum.GetName(typeof(Enums.DrFlagCompare), argValue);
                if (name != null) return name;
                break;
            }
            case 4 or 9 or 14 or 19 or 24 or 29 or 34 or 39:
            {
                var name = Enum.GetName(typeof(Enums.DrFlagJoiner), argValue);
                if (name != null) return name;
                break;
            }
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class SpriteOpcode(string name, int numargs) : Opcode(name, numargs)
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

internal class VoiceOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        switch (argIndex)
        {
            case 0:
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
                if (name != null) return name;
                break;
            }
            case 1:
            {
                var name = Enum.GetName(typeof(Enums.DrChapter), argValue);
                if (name != null) return name;
                break;
            }
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class StudentEntryOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 0) return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(Enums.GetCharEnum(game), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class GameStateOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 3 || args[0] != 0 || args[1] != 0 || args[2] != 0)
            return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(typeof(Enums.DrTime), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class ScreenFadeOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        switch (argIndex)
        {
            case 0:
            {
                var name = Enum.GetName(typeof(Enums.DrFade), argValue);
                if (name != null) return name;
                break;
            }
            case 1:
            {
                var name = Enum.GetName(typeof(Enums.DrColour), argValue);
                if (name != null) return name;
                break;
            }
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class PostProcessingEffectOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 1) return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(typeof(Enums.DrFilter), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class SkillOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 0) return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(Enums.GetSkillEnum(game), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class MusicOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        if (argIndex != 0) return base.DecompileArg(game, args, argIndex, argValue);
        var name = Enum.GetName(Enums.GetBgmEnum(game), argValue);
        return name ?? base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class PresentOpcode(string name, int numargs) : Opcode(name, numargs)
{
    public override string DecompileArg(Game game, byte[] args, int argIndex, byte argValue)
    {
        switch (argIndex)
        {
            case 0:
            {
                var name = Enum.GetName(Enums.GetPresentEnum(game), argValue);
                if (name != null) return name;
                break;
            }
            case 1:
            {
                var name = Enum.GetName(typeof(Enums.DrArithmetic), argValue);
                if (name != null) return name;
                break;
            }
        }

        return base.DecompileArg(game, args, argIndex, argValue);
    }
}

internal class Opcode(string? name, int numargs)
{
    private static readonly Dictionary<Game, Dictionary<string, byte>> OpcodesByName = new();

    private static readonly Dictionary<Game, Dictionary<byte, Opcode>> Opcodes = new()
    {
        {
            Game.Danganronpa1, new Dictionary<byte, Opcode>
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
            Game.Danganronpa2, new Dictionary<byte, Opcode>
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

    private readonly string? _name = name;
    private readonly int _numArguments = numargs;

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

    public static string GetOpName(byte op, Game game = Game.Base)
    {
        if (game != Game.Base)
            if (Opcodes[Game.Base].TryGetValue(op, out var opcode))
            {
                var opName = opcode._name;
                if (opName != null)
                    return opName;
            }

        if (Opcodes[Game.Base].TryGetValue(op, out var opcodeBase))
        {
            var opName = opcodeBase._name;
            if (opName != null)
                return opName;
        }

        return "0x" + op.ToString("X2");
    }

    public static byte GetOpcodeByName(string name, Game game = Game.Base)
    {
        if (game != Game.Base)
            if (OpcodesByName[game].TryGetValue(name, out var opcode))
                return opcode;
        if (OpcodesByName[Game.Base].TryGetValue(name, out var opcodeBase))
            return opcodeBase;
        return byte.Parse(name[2..], NumberStyles.HexNumber);
    }

    public static Opcode GetOpcodeById(byte op, Game game = Game.Base)
    {
        if (game != Game.Base)
            if (Opcodes[game].TryGetValue(op, out var opcode))
                return opcode;
        if (Opcodes[Game.Base].TryGetValue(op, out var opcodeBase))
            return opcodeBase;

        return new Opcode("0x" + op.ToString("X2"), -1);
    }

    public static int GetOpcodeArgCount(byte op, Game game = Game.Base)
    {
        if (game != Game.Base)
            if (Opcodes[game].TryGetValue(op, out var opcode))
                return opcode._numArguments;
        if (Opcodes[Game.Base].TryGetValue(op, out var opcodeBase))
            return opcodeBase._numArguments;
        return -1;
    }
}