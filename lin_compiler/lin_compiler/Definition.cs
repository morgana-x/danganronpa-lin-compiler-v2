using LIN;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static void LoadDefinitions()
        {
            Definitions[Game.Base].Clear();

            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FADE));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_CAM_DIR));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FLAG));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_SPRITE_STATE));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_FLAG_HANDBOOK));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_UI));
            LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DR_TIME));

            Definitions[Game.Danganronpa1] = Definitions[Game.Base].ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
            Definitions[Game.Danganronpa2] = Definitions[Game.Base].ToDictionary(entry => entry.Key,
                                               entry => entry.Value);

            LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.DR1_CHAR));
            LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.DR2_CHAR));
        }

        public static byte TryGetDefinitionValue(string name, Game game = Game.Base)
        {
            if (Definitions[game].ContainsKey(name)) return Definitions[game][name];
            throw (new Exception($"Tried to parse unknown definition {name}!"));
            return 0;
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
