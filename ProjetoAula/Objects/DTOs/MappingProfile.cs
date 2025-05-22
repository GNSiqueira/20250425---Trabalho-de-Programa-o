using AutoMapper;
using ProjetoAula.Objects.Models;

namespace ProjetoAula.Objects.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PedidoDTO, Pedido>().ReverseMap();
        CreateMap<Pedido, PedidoDTO>();
    }
}
