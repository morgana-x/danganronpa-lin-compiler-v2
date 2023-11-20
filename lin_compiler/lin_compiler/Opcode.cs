using System.Collections.Generic;

namespace LIN
{
    public enum Game
    {
        Base,
        Danganronpa1 = Base,
        Danganronpa2,
    }

    class Opcode
    {
        private static Dictionary<Game, Dictionary<string, byte>> OpcodesByName = new Dictionary<Game, Dictionary<string, byte>>();
        private static Dictionary<Game, Dictionary<byte, KeyValuePair<string, int>>> Opcodes = new Dictionary<Game, Dictionary<byte, KeyValuePair<string, int>>>
        {
            { Game.Danganronpa1, new Dictionary<byte, KeyValuePair<string, int>>
            {
                { 0x00, new KeyValuePair<string, int>(null, 2) },
                { 0x01, new KeyValuePair<string, int>("LoadSprite", 3) }, // Mostly Unknown 
                { 0x02, new KeyValuePair<string, int>("Text", 2) },
                { 0x03, new KeyValuePair<string, int>("TextboxFormat", 1) }, // Textbox format, 0 = other char speaking, 4 = player character speaking / thoughts
                { 0x04, new KeyValuePair<string, int>("PostProcessingFilter", 4) }, // 0 No Filter, 1 Sepia Tone
                { 0x05, new KeyValuePair<string, int>("Movie", 2) },
                { 0x06, new KeyValuePair<string, int>("Animation", 8) },
                { 0x08, new KeyValuePair<string, int>("Voice", 5) },
                { 0x09, new KeyValuePair<string, int>("Music", 3) },
                { 0x0A, new KeyValuePair<string, int>("Sound", 3) },
                { 0x0B, new KeyValuePair<string, int>("SoundB", 2) },
                { 0x0C, new KeyValuePair<string, int>("AddTruthBullets", 2) },
                { 0x0D, new KeyValuePair<string, int>("AddPresents", 3) },
                { 0x0E, new KeyValuePair<string, int>("UnlockSkill", 2) },
                { 0x0F, new KeyValuePair<string, int>("StudentTitleEntry", 3) },
                { 0x10, new KeyValuePair<string, int>("StudentReportInfo", 3) },
                { 0x11, new KeyValuePair<string, int>(null, 4) }, // Relationship setting?
                { 0x14, new KeyValuePair<string, int>("TrialCamera", 3) }, //Character, Motion, Position
                { 0x15, new KeyValuePair<string, int>("LoadMap", 3) }, // Room, State, Padding, Time of Day
                { 0x19, new KeyValuePair<string, int>("LoadScript", 3) },
                { 0x1A, new KeyValuePair<string, int>("ExecuteScript", 0) },
                { 0x1B, new KeyValuePair<string, int>(null, 3) },
                { 0x1C, new KeyValuePair<string, int>(null, 0) },
                { 0x1E, new KeyValuePair<string, int>("Sprite", 5) },
                { 0x1F, new KeyValuePair<string, int>("ScreenFlash", 7) },
                { 0x20, new KeyValuePair<string, int>("SpriteFlash", 5) },
                { 0x21, new KeyValuePair<string, int>("Speaker", 1) },
                { 0x22, new KeyValuePair<string, int>("ScreenFade", 3) },
                { 0x23, new KeyValuePair<string, int>("ObjectState", 5) },
                { 0x25, new KeyValuePair<string, int>("ChangeUi", 2) },
                { 0x26, new KeyValuePair<string, int>("SetFlag", 3) },
                { 0x27, new KeyValuePair<string, int>("CheckCharacter", 1) },
                { 0x29, new KeyValuePair<string, int>("CheckObject", 1) },
                { 0x2A, new KeyValuePair<string, int>("SetLabel", 2) },
                { 0x2B, new KeyValuePair<string, int>(null, 1) }, // Choice??
                { 0x2C, new KeyValuePair<string, int>("EndOfJump", 2) },
                { 0x2D, new KeyValuePair<string, int>("CameraFlash",1) },// IF CAUSING ISSUE THIS IS THE PROBLEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                { 0x2E, new KeyValuePair<string, int>("CameraShake", 2) },
                { 0x2F, new KeyValuePair<string, int>(null, 10) },
                { 0x30, new KeyValuePair<string, int>("ShowBackground", 3) },
                { 0x32, new KeyValuePair<string, int>(null, 1) }, // Truth bullet / Choice?
                { 0x33, new KeyValuePair<string, int>(null, 4) },
                { 0x34, new KeyValuePair<string, int>("GotoLabel", 2) },
                { 0x38, new KeyValuePair<string, int>(null, -1) },
                { 0x39, new KeyValuePair<string, int>(null, 5) },
                { 0x3A, new KeyValuePair<string, int>("WaitInput", 0) },
                { 0x3B, new KeyValuePair<string, int>("WaitFrame", 0) },
                { 0x3C, new KeyValuePair<string, int>(null, 0) },
                { 0x4B, new KeyValuePair<string, int>("WaitInputDR2", -1) },
                { 0x4C, new KeyValuePair<string, int>("WaitFrameDR2", 0) },
                { 0x4D, new KeyValuePair<string, int>(null, -1) },
            } },

            { Game.Danganronpa2, new Dictionary<byte, KeyValuePair<string, int>>
            {
                { 0x01, new KeyValuePair<string, int>(null, 4) },
                { 0x14, new KeyValuePair<string, int>(null, 6) },
                { 0x15, new KeyValuePair<string, int>(null, 4) },
                { 0x19, new KeyValuePair<string, int>("LoadScript", 5) },
                { 0x1B, new KeyValuePair<string, int>(null, 5) },
                { 0x29, new KeyValuePair<string, int>(null, 0xD) },
                { 0x2A, new KeyValuePair<string, int>(null, 0xC) },
                { 0x2E, new KeyValuePair<string, int>(null, 5) },
                { 0x30, new KeyValuePair<string, int>(null, 2) },
                { 0x34, new KeyValuePair<string, int>(null, 1) },
                { 0x3A, new KeyValuePair<string, int>("WaitInputDR1", 4) },
                { 0x3B, new KeyValuePair<string, int>("WaitFrameDR1", 2) },
                { 0x4B, new KeyValuePair<string, int>("WaitInput", -1) },
                { 0x4C, new KeyValuePair<string, int>("WaitFrame", 0) },
            } }
        };

        public static void GenerateOpcodeLookup()
        {
            // Generate opcode lookup dictionary
            foreach (Game game in Opcodes.Keys)
            {
                foreach (byte op in Opcodes[game].Keys)
                {
                    if (Opcodes[game][op].Key != null)
                    {
                        if (!OpcodesByName.ContainsKey(game))
                            OpcodesByName[game] = new Dictionary<string, byte>();
                        OpcodesByName[game][Opcodes[game][op].Key] = op;
                    }
                }
            }
        }

        public static string GetOpName(byte op, Game game = Game.Base)
        {
            if (game != Game.Base)
            {
                if (Opcodes[game].ContainsKey(op) && Opcodes[game][op].Key != null)
                    return Opcodes[game][op].Key;
            }
            if (Opcodes[Game.Base].ContainsKey(op) && Opcodes[Game.Base][op].Key != null)
                return Opcodes[Game.Base][op].Key;
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

        public static int GetOpcodeArgCount(byte op, Game game = Game.Base)
        {
            if (game != Game.Base)
            {
                if (Opcodes[game].ContainsKey(op))
                    return Opcodes[game][op].Value;
            }
            if (Opcodes[Game.Base].ContainsKey(op))
                return Opcodes[Game.Base][op].Value;
            return -1;
        }
    }
}
