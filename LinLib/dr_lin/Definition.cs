using LinLib.LIN;

namespace LinLib.dr_lin;

/// <summary>
/// Handles definitions used throughout the library, for use when reading the opcodes in the .lin file
/// </summary>
public static class Definition
{
    private static readonly Dictionary<Game, Dictionary<string, byte>> Definitions = new()
    {
        [Game.DANGANRONPA1] = new Dictionary<string, byte>(),
        [Game.DANGANRONPA2] = new Dictionary<string, byte>()
    };

    private static readonly Dictionary<string, byte> ScriptDefinedDefinitions = new();

    /// <summary>
    /// Loads definitions
    /// </summary>
    public static void LoadDefinitions()
    {
        ScriptDefinedDefinitions.Clear(); // Definitions that get set by the script, clear when reading new script

        // Only load this once when necessary
        if (Definitions[Game.BASE].Count != 0) return;

        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrFade));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrCamDir));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrFlag));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrSpriteState));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrFlagSystem));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrUi));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrTime));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrChapter));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrColour));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrFilter));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrFlagJoiner));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrFlagCompare));
        LoadDefinitionsFromEnum(Game.BASE, typeof(Enums.DrArithmetic));

        LoadDefinitionsFromEnum(Game.DANGANRONPA1, typeof(Enums.Dr1Char));
        LoadDefinitionsFromEnum(Game.DANGANRONPA1, typeof(Enums.Dr1Bgm));
        LoadDefinitionsFromEnum(Game.DANGANRONPA1, typeof(Enums.Dr1Skill));
        LoadDefinitionsFromEnum(Game.DANGANRONPA1, typeof(Enums.Dr1Item));

        LoadDefinitionsFromEnum(Game.DANGANRONPA2, typeof(Enums.Dr2Char));
        LoadDefinitionsFromEnum(Game.DANGANRONPA2, typeof(Enums.Dr2Bgm));
        LoadDefinitionsFromEnum(Game.DANGANRONPA2, typeof(Enums.Dr2Skill));
        LoadDefinitionsFromEnum(Game.DANGANRONPA2, typeof(Enums.Dr2Item));
    }

    /// <summary>
    /// Tries to get a definition from a value
    /// </summary>
    /// <param name="name">Name of the definition</param>
    /// <param name="game">The game associated with this definition. (DR1 or DR2)</param>
    /// <returns>The opcode associated with the definition</returns>
    /// <exception cref="Exception"></exception>
    public static byte TryGetDefinitionValue(string name, Game game = Game.BASE)
    {
        if (ScriptDefinedDefinitions.TryGetValue(name, out var value)) return value;
        if (Definitions[game].ContainsKey(name)) return Definitions[game][name];
        if (Definitions[Game.BASE].ContainsKey(name)) return Definitions[Game.BASE][name];
        throw new Exception($"Tried to parse unknown definition {name}!");
    }
    
    /// <summary>
    /// For scripts to define reusable values
    /// </summary>
    /// <param name="name">Name of the new definition</param>
    /// <param name="value">The value of the new definition</param>
    public static void ScriptDefineDefinition(string name, byte value)
    {
        ScriptDefinedDefinitions[name] = value;
    }

    private static void LoadDefinitionsFromEnum(Game game, Type e)
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