using LinLib.LIN;

namespace LinLib.dr_lin;

/// <summary>
/// Handles definitions used throughout the library, for use when reading the opcodes in the .lin file
/// </summary>
public class Definition
{
    private readonly Dictionary<Game, Dictionary<string, byte>> _definitions = new()
    {
        [Game.DANGANRONPA1] = new Dictionary<string, byte>(),
        [Game.DANGANRONPA2] = new Dictionary<string, byte>()
    };

    private readonly Dictionary<string, byte> _scriptDefinedDefinitions = new();

    /// <summary>
    /// Loads definitions
    /// </summary>
    public void LoadDefinitions()
    {
        _scriptDefinedDefinitions.Clear(); // Definitions that get set by the script, clear when reading new script

        // Only load this once when necessary
        if (_definitions[Game.BASE].Count != 0) return;

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
    public byte TryGetDefinitionValue(string name, Game game = Game.BASE)
    {
        if (_scriptDefinedDefinitions.TryGetValue(name, out var value)) return value;
        if (_definitions[game].ContainsKey(name)) return _definitions[game][name];
        if (_definitions[Game.BASE].ContainsKey(name)) return _definitions[Game.BASE][name];
        throw new Exception($"Tried to parse unknown definition {name}!");
    }
    
    /// <summary>
    /// For scripts to define reusable values
    /// </summary>
    /// <param name="name">Name of the new definition</param>
    /// <param name="value">The value of the new definition</param>
    public void ScriptDefineDefinition(string name, byte value)
    {
        _scriptDefinedDefinitions[name] = value;
    }

    private void LoadDefinitionsFromEnum(Game game, Type e)
    {
        var names = Enum.GetNames(e);
        var values = (int[])Enum.GetValues(e);

        for (var i = 0; i < names.Length; i++)
        {
            if (_definitions[game].ContainsKey(names[i])) continue;
            _definitions[game].Add(names[i], (byte)values[i]);
        }
    }
}