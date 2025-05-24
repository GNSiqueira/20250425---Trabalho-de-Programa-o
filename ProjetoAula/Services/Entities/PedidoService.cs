using AutoMapper;
using ProjetoAula.Data.Interfaces;
using ProjetoAula.Objects.DTOs;
using ProjetoAula.Objects.DTOs.Entities;
using ProjetoAula.Objects.Enums;
using ProjetoAula.Objects.Models;
using ProjetoAula.Services.Interfaces;
using ProjetoAula.Services.PedidoService.FretePedidoTemplate;
using ProjetoAula.Services.PedidoState;

namespace ProjetoAula.Services.Entities;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    # region CRUD
    public async Task Create(PedidoDTO pedidoDTO)
    {
        pedidoDTO.IdPedido = 0;
        
        if (!Enum.IsDefined(typeof(TipoFrete), pedidoDTO.TipoFrete))
            throw new ArgumentException("Tipo de frete nao encontrado.");

        if (pedidoDTO.StatusPedido != StatusPedido.AGUARDANDO_PAGAMENTO)
            throw new ArgumentException("StatusPedido inválido.");

        Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);

        await _repository.Add(pedido);
    }

    public async Task<IEnumerable<PedidoDTO>> GetAll()
    {
        var pedidos = await _repository.Get();
        return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);
    }

    public async Task<PedidoDTO> GetById(int id)
    {
        var pedido = await _repository.GetById(id);
        return _mapper.Map<PedidoDTO>(pedido);
    }

    public async Task Update(PedidoDTO pedidoDTO)
    {
        // Valida se existe antes (opcional)
        var existente = await _repository.GetById(pedidoDTO.IdPedido);
        if (existente == null)
            throw new KeyNotFoundException("Pedido não encontrado.");

        var pedido = _mapper.Map<Pedido>(pedidoDTO);
        await _repository.Update(pedido, pedidoDTO.IdPedido);
    }

    public async Task Remove(int id)
    {
        await _repository.Remove(id);
    }
    #endregion

    # region States
    public async Task Pagar(int id)
    {
        Pedido pedido = await _repository.GetById(id);
        var pedidoState = SetStatePedido.SetState(pedido);
        pedidoState.Pagar();
        await _repository.Update(pedido, id);
    }

    public async Task Enviar(int id)
    {
        Pedido pedido = await _repository.GetById(id);
        var pedidoState = SetStatePedido.SetState(pedido);
        pedidoState.Enviar();
        await _repository.Update(pedido, id);
    }

    public async Task Cancelar(int id)
    {
        Pedido pedido = await _repository.GetById(id);
        var pedidoState = SetStatePedido.SetState(pedido);
        pedidoState.Cancelar();
        await _repository.Update(pedido, id);
    }
    #endregion

    #region Frete
    public async Task<PedidoFreteRetornoDTO> GetInfoFrete(int id)
    {
        // Tipo, valor, valor total
        Pedido pedido = await _repository.GetById(id);

        var frete = SetTemplateFretePedido.setTemplate(pedido);

        string tipo = frete.GetTipoFrete();
        float freteValor = frete.CalcularFrete();
        float freteTotal = frete.GetValorTotal();

        var infoFrete = new PedidoFreteRetornoDTO(
            tipo,
            freteValor,
            freteTotal
        );
        return infoFrete;
    }
    #endregion
}
