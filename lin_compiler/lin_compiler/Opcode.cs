using dr_lin;
using System;
using System.Collections.Generic;

namespace LIN
{
    public enum Game
    {
        Base,
        Danganronpa1 = Base,
        Danganronpa2,
    }

    public class ChangeUIOpcode : Opcode
    {
        public ChangeUIOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 0)
            {
                var name = Enum.GetName(typeof(Enums.DR_UI), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }

    public class SpeakerOpcode : Opcode
    {
        public SpeakerOpcode(string name, int numargs) : base(name, numargs) { }

        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 0)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), ArgValue);
                if (name != null) return name;
            }
            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }


    public class FlagOpcode : Opcode
    {
        public FlagOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game,  byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 0)
            {
                var name = Enum.GetName(typeof(Enums.DR_FLAG), ArgValue);
                if (name != null) return name;
            }

           /* if (ArgIndex == 1 && args[0] == (byte)Enums.DR_FLAG.FLAG_CHR_SPEAK || args[1] == (byte)Enums.DR_FLAG.FLAG_CHR_DEAD)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), ArgValue);
                if (name != null) return name;
            }*/

            if (ArgIndex == 1 && args[0] == (byte)Enums.DR_FLAG.FLAG_SYSTEM)
            {
                var name = Enum.GetName(typeof(Enums.DR_FLAG_SYSTEM), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game,args, ArgIndex, ArgValue);
        }
    }
    public class SpriteOpcode : Opcode
    {
        public SpriteOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 1)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), ArgValue);
                if (name != null) return name;
            }
            if (ArgIndex == 3)
            {
                var name = Enum.GetName(typeof(Enums.DR_SPRITE_STATE), ArgValue);
                if (name != null) return name;
            }
            if (ArgIndex == 4)
            {
                var name = Enum.GetName(typeof(Enums.DR_CAM_DIR), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }

    public class VoiceOpcode : Opcode
    {
        public VoiceOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 0)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), ArgValue);
                if (name != null) return name;
            }

            if (ArgIndex == 1)
            {
                var name = Enum.GetName(typeof(Enums.DR_CHAPTER), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }

    public class StudentEntryOpcode : Opcode
    {
        public StudentEntryOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex== 0)
            {
                var name = Enum.GetName(Enums.GetCharEnum(game), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }

    public class GameStateOpcode : Opcode
    {
        public GameStateOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 3 && args[0] == 0 && args[1] == 0 && args[2] == 0)
            {
                var name = Enum.GetName(typeof(Enums.DR_TIME), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }


    public class ScreenFadeOpcode : Opcode
    {
        public ScreenFadeOpcode(string name, int numargs) : base(name, numargs) { }
        public override string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            if (ArgIndex == 0)
            {
                var name = Enum.GetName(typeof(Enums.DR_FADE), ArgValue);
                if (name != null) return name;
            }

            return base.DecompileArg(game, args, ArgIndex, ArgValue);
        }
    }


    public class Opcode
    {
        public Opcode() { }
        public Opcode(string name, int numargs)
        {
            Name = name;
            NumArguments = numargs;
        }
        public string Name;
        public int NumArguments;
        public virtual string DecompileArg(Game game, byte[] args, int ArgIndex, byte ArgValue)
        {
            return ArgValue.ToString();
        }

     
        private static Dictionary<Game, Dictionary<string, byte>> OpcodesByName = new Dictionary<Game, Dictionary<string, byte>>();
        private static Dictionary<Game, Dictionary<byte, Opcode>> Opcodes = new Dictionary<Game, Dictionary<byte, Opcode>>
        {
            { Game.Danganronpa1, new Dictionary<byte, Opcode>
            {
                { 0x00, new Opcode(null, 2) },
                { 0x01, new Opcode("LoadSprite", 3) }, // Mostly Unknown 
                { 0x02, new Opcode("Text", 2) },
                { 0x03, new Opcode("TextboxFormat", 1) }, // Textbox format, 0 = other char speaking, 4 = player character speaking / thoughts
                { 0x04, new Opcode("PostProcessingFilter", 4) }, // 0 No Filter, 1 Sepia Tone
                { 0x05, new Opcode("Movie", 2) },
                { 0x06, new Opcode("Animation", 8) },
                { 0x08, new VoiceOpcode("Voice", 5) },
                { 0x09, new Opcode("Music", 3) },
                { 0x0A, new Opcode("Sound", 3) },
                { 0x0B, new Opcode("SoundB", 2) },
                { 0x0C, new Opcode("AddTruthBullets", 2) },
                { 0x0D, new Opcode("AddPresents", 3) },
                { 0x0E, new Opcode("UnlockSkill", 2) },
                { 0x0F, new StudentEntryOpcode("StudentTitleEntry", 3) },
                { 0x10, new StudentEntryOpcode("StudentReportInfo", 3) },
                { 0x11, new Opcode(null, 4) }, // Relationship setting?
                { 0x14, new Opcode("TrialCamera", 3) }, //Character, Motion, Position
                { 0x15, new Opcode("LoadMap", 3) }, // Room, State, Padding, Time of Day
                { 0x19, new Opcode("LoadScript", 3) },
                { 0x1A, new Opcode("StopScript", 0) },
                { 0x1B, new Opcode("RunScript", 3) },
                { 0x1C, new Opcode(null, 0) },
                { 0x1E, new SpriteOpcode("Sprite", 5) },
                { 0x1F, new Opcode("ScreenFlash", 7) },
                { 0x20, new Opcode("SpriteFlash", 5) },
                { 0x21, new SpeakerOpcode("Speaker", 1) },
                { 0x22, new ScreenFadeOpcode("ScreenFade", 3) },
                { 0x23, new Opcode("ObjectState", 5) },
                { 0x25, new ChangeUIOpcode("ChangeUi", 2) },
                { 0x26, new FlagOpcode("SetFlag", 3) }, // Argument 1 is the group, argument 2 is the ID, and argument 3 is the state.
                { 0x27, new Opcode("CheckCharacter", 1) },
                { 0x29, new Opcode("CheckObject", 1) },
                { 0x2A, new Opcode("SetLabel", 2) }, // Arguments 1 and 2 make up the label [ID] // See 0x34
                { 0x2B, new Opcode("SetChoiceText", 1) }, // Choice??
                { 0x2C, new Opcode("EndOfJump", 2) },
                { 0x2D, new Opcode("CameraFlash",-1) },// IF CAUSING ISSUE THIS IS THE PROBLEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                { 0x2E, new Opcode("CameraShake", 2) },
                { 0x2F, new Opcode(null, 10) },
                { 0x30, new Opcode("ShowBackground", 3) },
                { 0x32, new Opcode(null, 1) }, // Truth bullet / Choice?
                { 0x33, new GameStateOpcode("SetGameState", 4) },
                { 0x34, new Opcode("GotoLabel", 2) }, // Argument 1 and 2 make up the label [ID]. See 0x2A.
                { 0x35, new FlagOpcode("CheckFlagA", -1) }, // each check is 4 args
                { 0x36, new FlagOpcode("CheckFlagB", -1) }, // each check is 4 args
                { 0x38, new Opcode(null, -1) },
                { 0x39, new Opcode(null, 5) },
                { 0x3A, new Opcode("WaitInput", 0) },
                { 0x3B, new Opcode("WaitFrame", 0) },
                { 0x3C, new Opcode("If_FlagCheck", 0) },
                { 0x4B, new Opcode("WaitInputDR2", -1) },
                { 0x4C, new Opcode("WaitFrameDR2", 0) },
                { 0x4D, new Opcode(null, -1) },
            } },

            { Game.Danganronpa2, new Dictionary<byte, Opcode>
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
                { 0x4C, new Opcode("WaitFrame", 0) },
            } }
        };

        public static void GenerateOpcodeLookup()
        {
            // Generate opcode lookup dictionary
            foreach (Game game in Opcodes.Keys)
            {
                foreach (byte op in Opcodes[game].Keys)
                {
                    if (Opcodes[game][op].Name != null)
                    {
                        if (!OpcodesByName.ContainsKey(game))
                            OpcodesByName[game] = new Dictionary<string, byte>();
                        OpcodesByName[game][Opcodes[game][op].Name] = op;
                    }
                }
            }
        }

        public static string GetOpName(byte op, Game game = Game.Base)
        {
            if (game != Game.Base)
            {
                if (Opcodes[game].ContainsKey(op) && Opcodes[game][op].Name != null)
                    return Opcodes[game][op].Name;
            }
            if (Opcodes[Game.Base].ContainsKey(op) && Opcodes[Game.Base][op].Name != null)
                return Opcodes[Game.Base][op].Name;

            return "0x" + op.ToString("X2");
        }

        public static byte GetOpcodeByName(string name, Game game = Game.Base)
        {
            if (game != Game.Base)
            {
                if (OpcodesByName[game].ContainsKey(name))
                    return OpcodesByName[game][name];
            }
            if (OpcodesByName[Game.Base].ContainsKey(name))
                return OpcodesByName[Game.Base][name];
            return byte.Parse(name.Substring(2), System.Globalization.NumberStyles.HexNumber);
        }

        public static Opcode GetOpcodeByID(byte op, Game game = Game.Base)
        {
            if (game != Game.Base)
            {
                if (Opcodes[game].ContainsKey(op))
                    return Opcodes[game][op];
            }
            if (Opcodes[Game.Base].ContainsKey(op))
                return Opcodes[Game.Base][op];

            return new Opcode("0x" + op.ToString("X2"), -1);
        }

        public static int GetOpcodeArgCount(byte op, Game game = Game.Base)
        {
            if (game != Game.Base)
            {
                if (Opcodes[game].ContainsKey(op))
                    return Opcodes[game][op].NumArguments;
            }
            if (Opcodes[Game.Base].ContainsKey(op))
                return Opcodes[Game.Base][op].NumArguments;
            return -1;
        }
    }
}
