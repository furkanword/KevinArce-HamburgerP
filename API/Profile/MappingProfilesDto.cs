
using API.Dtos;
using AutoMapper;
using Dominio.Entities;


namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoriasDto, Categorias>().ReverseMap();
        CreateMap<ChefsDto , Chefs>().ReverseMap();
        CreateMap<Hamburguesa_ingradientesDto, Hamburguesa_ingredientes>().ReverseMap();
        CreateMap<HamburguesaDto , Hamburguesas>().ReverseMap();
        CreateMap<IngredientesDto , Ingredientes>().ReverseMap();
    }
}