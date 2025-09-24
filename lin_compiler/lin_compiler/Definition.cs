using LIN;
using System;
using System.Collections.Generic;

namespace dr_lin
{
    public class Definition
    {
        public string Name;
        public byte Value;

        public static Dictionary<Game, Dictionary<string, byte>> Definitions = new Dictionary<Game, Dictionary<string, byte>>()
        {
            [Game.Base] = new Dictionary<string, byte>(),
            [Game.Danganronpa1] = new Dictionary<string, byte>(),
            [Game.Danganronpa2] = new Dictionary<string, byte>(),
        };

        public static Dictionary<string, byte> ScriptDefinedDefinitions = new Dictionary<string, byte>();
        public static void LoadDefinitions()
        {
            ScriptDefinedDefinitions.Clear(); // Definitions that get set by the script, clear when reading new script

            // Only load this once when nessecary
            if (Definitions[Game.Base].Count != 0) return;

            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FADE));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_CAM_DIR));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FLAG));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_SPRITE_STATE));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FLAG_SYSTEM));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_UI));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_TIME));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_CHAPTER));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_COLOUR));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FILTER));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FLAG_JOINER));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FLAG_COMPARE));

            LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.DR1_CHAR));
            LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.DR1_BGM));
            LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.DR1_SKILL));

            LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.DR2_CHAR));
            LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.DR2_BGM));
            LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.DR2_SKILL));
        }

        public static byte TryGetDefinitionValue(string name, Game game = Game.Base)
        {
            if (ScriptDefinedDefinitions.ContainsKey(name)) return ScriptDefinedDefinitions[name];
            if (Definitions[game].ContainsKey(name)) return Definitions[game][name];
            if (Definitions[Game.Base].ContainsKey(name)) return Definitions[Game.Base][name];
            throw (new Exception($"Tried to parse unknown definition {name}!"));
        }

        // For scripts to define reusable values
        public static void ScriptDefineDefinition(string name, byte value)
        {
            ScriptDefinedDefinitions[name] = value;
        }

        public static void LoadDefinitonsFromEnum(Game game, Type e)
        {
            var names = Enum.GetNames(e);
            int[] values = (int[])Enum.GetValues(e);

            for (int i=0;i<names.Length;i++)
            {
                if (Definitions[game].ContainsKey(names[i])) continue;
                Definitions[game].Add(names[i], (byte)values[i]);
            }
        }
    }
}
