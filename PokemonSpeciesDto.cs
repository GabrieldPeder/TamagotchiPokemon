using System.Collections.Generic;
using System.Text.Json.Serialization;

// DTO - Data Transfer Object para a espécie de Pokémon vinda da API
public class PokemonSpeciesDto
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("abilities")]
    public List<PokemonAbilityDto>? Abilities { get; set; }
}

public class PokemonAbilityDto
{
    [JsonPropertyName("ability")]
    public AbilityDetailDto? Ability { get; set; }
}

public class AbilityDetailDto
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}