using ProjetoAula.Objects.DTOs;
using ProjetoAula.Objects.DTOs.Entities;

namespace ProjetoAula.Services.Interfaces;

public interface IPedidoService
{
    Task Create(PedidoDTO pedidoDTO);
    Task Update(PedidoDTO pedidoDTO);
    Task Remove(int id);
    Task<IEnumerable<PedidoDTO>> GetAll();
    Task<PedidoDTO> GetById(int id);

    Task Pagar(int id);
    Task Cancelar(int id);
    Task Enviar(int id);

    Task<PedidoFreteRetornoDTO> GetInfoFrete(int id);
}