using AutoMapper;
using FShop.ProdutoApi.Models;

namespace FShop.ProdutoApi.DTOs.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();

        CreateMap<ProdutoDTO, Produto>();

        CreateMap<Produto, ProdutoDTO>()
            .ForMember(x => x.CategoriaName, opt => opt.MapFrom(src => src.Categoria.Nome));
    }
}
