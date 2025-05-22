using AutoMapper;
using ProjetoAula.Data.Interfaces;
using ProjetoAula.Objects.Models;
using ProjetoAula.Services.Interfaces;

namespace ProjetoAula.Services.Entities;

public class PedidoService : GenericService<Pedido>, IPedidoService
{
    private readonly IPedidoRepository _repository;
    private readonly IMapper _mapper;


    public PedidoService(IPedidoRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}
