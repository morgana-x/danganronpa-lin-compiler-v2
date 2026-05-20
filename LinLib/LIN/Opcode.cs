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
                { 0x00, new Opcode("TextCount", [2]) { _endianLittle = true}},
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
                { 0x35, new CheckFlagSubOpcode("CheckFlagA", [1, 1, 1, 1]) }, // each check is 4 args
                { 0x36, new CheckFlagSubOpcode("CheckFlagB", [1, 1, 1, 2]) }, // each check is 5 args
                { 0x38, new CheckFlagRelationOpcode("CheckRelationA", [2, 1, 2]) },
                { 0x39, new CheckFlagRelationOpcode("CheckRelationB", [2, 1, 2]) },
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
                { 0x46, new CheckFlagSubOpcode("CheckFlagE", [1, 1, 1, 1])},
                { 0x47, new CheckFlagOpcode("CheckFlagF", [2, 1, 2])}, //new CheckFlagItemOpcode("CheckItem", [2, 1, 2]) },
                { 0x49, new CheckFlagSubOpcode("CheckFlagG",  [1, 1, 1, 2])},
                { 0x4A, new CheckFlagRelationOpcode("CheckRelationC",  [2, 1, 2])},
                { 0x4B, new Opcode("WaitInput", -1) },
                { 0x4C, new Opcode("WaitFrame", 0) },
                { 0x4D, new Opcode("If_FlagCheck", 0)}
            }
        }
    };

    private readonly string? _name;
    private readonly int _numArguments;
    
    private readonly int[] _argSizes;
    private readonly int[] _argSizesWithJoinerArg;

    private readonly bool _hasJoiner;

    public int NumArgs => _numArguments;
    
    public string? Name => _name;

    private bool _endianLittle = false;

    internal Opcode(string? name, int numargs)
    {
        _name = name;
        _numArguments = numargs;
        _hasJoiner = false;

        if (numargs <= 0)
        {
            _argSizes = [];
            return;
        }
        
        _argSizes = new int[numargs];
        
        for (int i = 0; i < numargs; i++)
            _argSizes[i] = 1;
    }

    internal Opcode(string? name, IEnumerable<int> argSizes, bool repeatable=false, bool hasJoinerArg=false)
    {
        _name = name;
        _numArguments = repeatable ? -1 : argSizes.Count();
        
        _argSizes = argSizes.ToArray();

        if (_argSizes.Length == 0)
            _numArguments = -1;
        
        _hasJoiner = hasJoinerArg;
        if (_hasJoiner)
        {
            var argsizesjoiner = _argSizes.ToList();
            argsizesjoiner.Add(1);
            _argSizesWithJoinerArg = argsizesjoiner.ToArray();
        }
    }

    int getArgSize(int i)
    {
        if (_argSizes.Length <= 0)
            return 1;
        
        if (_hasJoiner)
            return _argSizesWithJoinerArg[i % _argSizesWithJoinerArg.Length];
        
        if (i < _argSizes.Length)
            return _argSizes[i];
        
        return _argSizes[i % _argSizes.Length];
    }

    int getSegmentSize()
    {
        if (_argSizes.Length <= 0)
            return _numArguments;
        if (_hasJoiner)
            return _argSizesWithJoinerArg.Length;

        return _argSizes.Length;
    }

    internal int getSegementIndex(int i)
    {
        return i % getSegmentSize();
    }
    
    public virtual void WriteArgs(ref List<byte> file, int[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            var a = args[i];

            if (_argSizes.Length == 0)
            {
                file.Add((byte)(a));
                continue;
            }


            if (_endianLittle)
            {
                for (int j = 0; j < getArgSize(i); j++)
                    file.Add((byte)((a >> (8 * j)) & 0xFF));
            }
            else
            {
                for (int j = getArgSize(i) - 1; j >= 0; j--)
                    file.Add((byte)((a >> (8 * j)) & 0xFF));
            }


        }
    }
    
    public virtual int[] ReadArgs(byte[] file, ref int i)
    {
        var args = new List<int>();
        if (_numArguments == -1 && _argSizes.Length == 0)
        {
            while (file[i] != 0x70)
            {
                args.Add(file[i]);
                i++;
            }

            return args.ToArray();
        }

        int numargs = _numArguments;
        if (numargs == -1)
        {
            int peekIndex = 0;
            int argsizes = 0;
            numargs = 0;
            
            for (int b = 0; b < _argSizes.Length; b++)
                argsizes += _argSizes[b];
            
            while (i + peekIndex < file.Length && file[i + peekIndex] != 0x70)
            {
                int joiner = 0;
                
                int joinerIndex = i + peekIndex + (_hasJoiner  ? _argSizes.Length : 0 );
                
                if (_hasJoiner && numargs >= _argSizes.Length && joinerIndex < file.Length && file[joinerIndex] != 0x70 )
                    joiner = 1;
                
                peekIndex += argsizes + joiner;
                numargs += _argSizes.Length + joiner;
            }
            
        }
        
        for (int a = 0; a < numargs; a++)
        {
            if (getArgSize(a) == 1)
            {
                args.Add(file[i]);
                i++;
                continue;
            }

            args.Add(0);
            if (_endianLittle)
            {
                for (int j = 0; j < getArgSize(a); j++)
                {
                    args[a] += (file[i] & 0xFF) << (8 * j);
                    i++;
                }
            }
            else
            {
                for (int j = getArgSize(a) - 1; j >= 0; j--)
                {
                    args[a] += (file[i] & 0xFF) << (8 * j);
                    i++;
                }
            }
        }
        
        
        return args.ToArray();
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
}