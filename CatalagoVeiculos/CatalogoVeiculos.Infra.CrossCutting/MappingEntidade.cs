using AutoMapper;
using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Infra.CrossCutting
{
    public class MappingEntidade : Profile
    {
        public MappingEntidade()
        {
            CreateMap<Veiculo, VeiculoDto>().ReverseMap();
            CreateMap<Modelo, ModeloDto>().ReverseMap();
            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
