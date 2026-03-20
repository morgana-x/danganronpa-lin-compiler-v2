using LinLib.LIN;

namespace LinLib.dr_lin;

internal class Definition
{
    public static Dictionary<Game, Dictionary<string, byte>> Definitions = new()
    {
        [Game.DANGANRONPA1] = new Dictionary<string, byte>(),
        [Game.DANGANRONPA2] = new Dictionary<string, byte>()
    };

    public static Dictionary<string, byte> ScriptDefinedDefinitions = new();

    public static void LoadDefinitions()
    {
        ScriptDefinedDefinitions.Clear(); // Definitions that get set by the script, clear when reading new script

        // Only load this once when nessecary
        if (Definitions[Game.BASE].Count != 0) return;

        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_FADE));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_CAM_DIR));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_FLAG));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_SPRITE_STATE));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_FLAG_SYSTEM));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_UI));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_TIME));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_CHAPTER));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_COLOUR));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_FILTER));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_FLAG_JOINER));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_FLAG_COMPARE));
        LoadDefinitonsFromEnum(Game.BASE, typeof(Enums.DR_ARITHMETIC));

        LoadDefinitonsFromEnum(Game.DANGANRONPA1, typeof(Enums.DR1_CHAR));
        LoadDefinitonsFromEnum(Game.DANGANRONPA1, typeof(Enums.DR1_BGM));
        LoadDefinitonsFromEnum(Game.DANGANRONPA1, typeof(Enums.DR1_SKILL));
        LoadDefinitonsFromEnum(Game.DANGANRONPA1, typeof(Enums.DR1_ITEM));

        LoadDefinitonsFromEnum(Game.DANGANRONPA2, typeof(Enums.DR2_CHAR));
        LoadDefinitonsFromEnum(Game.DANGANRONPA2, typeof(Enums.DR2_BGM));
        LoadDefinitonsFromEnum(Game.DANGANRONPA2, typeof(Enums.DR2_SKILL));
        LoadDefinitonsFromEnum(Game.DANGANRONPA2, typeof(Enums.DR2_ITEM));
    }

    public static byte TryGetDefinitionValue(string name, Game game = Game.BASE)
    {
        if (ScriptDefinedDefinitions.ContainsKey(name)) return ScriptDefinedDefinitions[name];
        if (Definitions[game].ContainsKey(name)) return Definitions[game][name];
        if (Definitions[Game.BASE].ContainsKey(name)) return Definitions[Game.BASE][name];
        throw new Exception($"Tried to parse unknown definition {name}!");
    }

    // For scripts to define reusable values
    public static void ScriptDefineDefinition(string name, byte value)
    {
        ScriptDefinedDefinitions[name] = value;
    }

    public static void LoadDefinitonsFromEnum(Game game, Type e)
    {
        var names = Enum.GetNames(e);
        var values = (int[])Enum.GetValues(e);

        for (var i = 0; i < names.Length; i++)
        {
            if (Definitions[game].ContainsKey(names[i])) continue;
            Definitions[game].Add(names[i], (byte)values[i]);
        }
    }
}