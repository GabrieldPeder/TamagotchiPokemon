using AutoMapper;

// O Perfil de Mapeamento ensina ao AutoMapper como converter um tipo em outro.
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeia de PokemonSpeciesDto para Mascote
        CreateMap<PokemonSpeciesDto, Mascote>();
        
        // Mapeia as classes aninhadas também
        CreateMap<PokemonAbilityDto, PokemonAbility>();
        CreateMap<AbilityDetailDto, AbilityDetail>();
    }
}