using LinLib.LIN;

namespace LinLib.dr_lin;

internal abstract class Definition
{
    private static readonly Dictionary<Game, Dictionary<string, byte>> Definitions = new()
    {
        [Game.Danganronpa1] = new Dictionary<string, byte>(),
        [Game.Danganronpa2] = new Dictionary<string, byte>()
    };

    private static readonly Dictionary<string, byte> ScriptDefinedDefinitions = new();

    public static void LoadDefinitions()
    {
        ScriptDefinedDefinitions.Clear(); // Definitions that get set by the script, clear when reading new script

        // Only load this once when nessecary
        if (Definitions[Game.Base].Count != 0) return;

        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrFade));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrCamDir));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrFlag));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrSpriteState));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrFlagSystem));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrUi));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrTime));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrChapter));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrColour));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrFilter));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrFlagJoiner));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrFlagCompare));
        LoadDefinitonsFromEnum(Game.Base, typeof(Enums.DrArithmetic));

        LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.Dr1Char));
        LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.Dr1Bgm));
        LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.Dr1Skill));
        LoadDefinitonsFromEnum(Game.Danganronpa1, typeof(Enums.Dr1Item));

        LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.Dr2Char));
        LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.Dr2Bgm));
        LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.Dr2Skill));
        LoadDefinitonsFromEnum(Game.Danganronpa2, typeof(Enums.Dr2Item));
    }

    public static byte TryGetDefinitionValue(string name, Game game = Game.Base)
    {
        if (ScriptDefinedDefinitions.TryGetValue(name, out var scriptDefinedDefinition)) return scriptDefinedDefinition;
        if (Definitions[game].TryGetValue(name, out var gameDefinition)) return gameDefinition;
        return Definitions[Game.Base].TryGetValue(name, out var baseDefinition) ? baseDefinition : throw new Exception($"Tried to parse unknown definition {name}!");
    }

    // For scripts to define reusable values
    public static void ScriptDefineDefinition(string name, byte value)
    {
        ScriptDefinedDefinitions[name] = value;
    }

    private static void LoadDefinitonsFromEnum(Game game, Type e)
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