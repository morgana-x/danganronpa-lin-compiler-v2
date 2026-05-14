using System.Globalization;
using LinLib.LIN.Opcodes;

#pragma warning disable 1591

namespace LinLib.LIN;

public enum Game
{
    BASE,
    DANGANRONPA1 = BASE,
    DANGANRONPA2
}


public class Opcode
{
    private static readonly Dictionary<Game, Dictionary<string, byte>> OpcodesByName = new();

    private static readonly Dictionary<Game, Dictionary<byte, Opcode>> Opcodes = new()
    {
        {
            Game.DANGANRONPA1, new Dictionary<byte, Opcode>
            {
                { 0x00, new Opcode("TextCount", [2]) { EndianLittle = true}},
                { 0x01, new Opcode("LoadSprite", 3) }, // Mostly Unknown 
                { 0x02, new Opcode("Text", [2]) },
                {
                    0x03, new Opcode("TextboxFormat", 1)
                }, // Textbox format, 0 = other char speaking, 4 = player character speaking / thoughts
                { 0x04, new PostProcessingEffectOpcode("PostProcessingFilter", 4) }, // 0 No Filter, 1 Sepia Tone
                { 0x05, new Opcode("Movie", [1, 1]) },
                { 0x06, new Opcode("Animation", [2, 2, 2, 1, 1])  },
                { 0x08, new VoiceOpcode("Voice", [1, 1, 2, 1]) },
                { 0x09, new MusicOpcode("Music", 3) },
                { 0x0A, new Opcode("SoundA", [2, 1]) },
                { 0x0B, new Opcode("SoundB", 2) },
                { 0x0C, new Opcode("AddTruthBullets", 2) },
                { 0x0D, new PresentOpcode("AddPresents", 3) },
                { 0x0E, new SkillOpcode("UnlockSkill", 2) },
                { 0x0F, new StudentEntryOpcode("StudentTitleEntry", [1, 2]) },
                { 0x10, new StudentEntryOpcode("StudentReportInfo", [1, 2]) },
                { 0x11, new SetRelationOpcode("ChangeRelation", [1, 1, 2]) }, // Relationship setting?
                { 0x14, new TrialCameraOpcode("TrialCamera", [1, 2]) }, //Character, Motionr bshr, Motion, Position
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
                { 0x26, new SetFlagOpcode("SetFlag", 3) }, // Argument 1 is the group, argument 2 is the ID, and argument 3 is the state.
                { 0x27, new Opcode("CheckCharacter", 1) },
                { 0x29, new Opcode("CheckObject", 1) },
                { 0x2A, new Opcode("SetLabel", [2]) }, // Arguments 1 and 2 make up the label [ID] // See 0x34
                { 0x2B, new Opcode("SetOption", 1) }, // Choice??
       
                {
                    0x2D, new Opcode("CameraFlash", -1)
                }, // IF CAUSING ISSUE THIS IS THE PROBLEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                { 0x2E, new Opcode("CameraShake", 2) },
                { 0x2F, new Opcode(null, 10) },
                { 0x30, new Opcode("ShowBackground", 3) },
                { 0x32, new Opcode(null, 1) }, // Truth bullet / Choice?
                { 0x33, new GameStateOpcode("SetGameState", [1, 1, 2]) },
                { 0x34, new Opcode("GotoLabel", [2]) }, // Argument 1 and 2 make up the label [ID]. See 0x2A.
                { 0x35, new CheckFlagAOpcode("CheckFlagA", -1) }, // each check is 4 args
                { 0x36, new CheckFlagBOpcode("CheckFlagB", -1) }, // each check is 4 args
                { 0x38, new CheckFlagDOpcode("CheckFlagC", -1) },
                { 0x39, new CheckFlagDOpcode("CheckFlagD", -1) },
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
                { 0x0A, new Opcode("SoundA", [2, 1])},
                { 0x14, new TrialCameraOpcodeDr2("TrialCamera", [1, 2, 1, 1, 1]) },
                { 0x15, new Opcode(null, 4) },
                { 0x1A, new Opcode("StopScript", 0)},
                { 0x19, new Opcode("LoadScript", [1, 2, 2]) },
                { 0x1B, new Opcode("RunScript", [1, 2, 2]) },
                { 0x29, new Opcode(null, 0xD) },
                { 0x2A, new Opcode(null, 0xC) },
                { 0x2C, new Opcode("EndOfJump", [2]) },
                { 0x2D, new Opcode("CameraFlash", [1, 2, 2, 1, 1, 1, 1, 1, 1, 1])},
                { 0x2E, new Opcode(null, 5) },
                { 0x30, new Opcode(null, 2) },
                { 0x32, new Opcode("SelectOption", 1)},
                { 0x34, new Opcode(null, -1) },
                { 0x37, new Opcode("ShowCG", [1, 1, 1])},
                { 0x3A, new Opcode("SetGameState", [1, 1, 2]) },
                { 0x3B, new Opcode("StartJump", [2]) },
                { 0x3D, new ScreenEffectOpcode("ScreenEffect", [1, 1, 2, 1])},
                { 0x3E, new Opcode("Hangman", 2)},
                { 0x46, new CheckFlagAOpcode("CheckFlagG", -1)},
                { 0x49, new CheckFlagDOpcode("CheckFlagF", -1)},
                { 0x4A, new CheckFlagDOpcode("CheckFlagE", -1)},
                { 0x4B, new Opcode("WaitInput", -1) },
                { 0x4C, new Opcode("WaitFrame", 0) },
                { 0x4D, new Opcode("If_FlagCheck", 0)}
            }
        }
    };

    private readonly string? _name;
    private readonly int _numArguments;
    
    private int[] _argSizes;

    public int NumArgs
    {
        get { return _numArguments; }
    }
    
    public string Name
    {
        get { return _name; }
    }

    public bool EndianLittle = false;

    internal Opcode(string? name, int numargs)
    {
        _name = name;
        _numArguments = numargs;
        
        if (numargs < 0)
            numargs = 0;
        
        _argSizes = new int[numargs];
        
        for (int i = 0; i < numargs; i++)
            _argSizes[i] = 1;
    }

    internal Opcode(string? name, IEnumerable<int> argSizes)
    {
        _name = name;
        _numArguments = argSizes.Count();
        _argSizes = argSizes.ToArray();
        
    }
    
    
    public virtual void WriteArgs(ref List<byte> file, int[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            var a = args[i];

            if (_argSizes.Length == 0 || _numArguments == -1 || i >= _argSizes.Length)
            {
                file.Add((byte)(a));
                continue;
            }


            if (EndianLittle)
            {
                for (int j = 0; j < _argSizes[i]; j++)
                    file.Add((byte)((a >> (8 * j)) & 0xFF));
            }
            else
            {
                for (int j = _argSizes[i] - 1; j >= 0; j--)
                    file.Add((byte)((a >> (8 * j)) & 0xFF));
            }


        }
    }
    
    public virtual int[] ReadArgs(byte[] file, ref int i)
    {
       
        if (_numArguments == -1)
        {
            var vargs = new List<int>();
            while (file[i] != 0x70)
            {
                vargs.Add(file[i]);
                i++;
            }

            return vargs.ToArray();
        }
        
        int[] args = new int[_numArguments];
        
        for (int a = 0; a < _numArguments; a++)
        {
            if (EndianLittle)
            {
                for (int j = 0; j < _argSizes[a]; j++)
                {
                    args[a] += (file[i] & 0xFF) << (8 * j);
                    i++;
                }
            }
            else
            {
                for (int j = _argSizes[a] - 1; j >= 0; j--)
                {
                    args[a] += (file[i] & 0xFF) << (8 * j);
                    i++;
                }
            }
        }
        
        
        return args;
    }
    

    public virtual string DecompileArg(Game game, int[] args, int argIndex, int argValue)
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