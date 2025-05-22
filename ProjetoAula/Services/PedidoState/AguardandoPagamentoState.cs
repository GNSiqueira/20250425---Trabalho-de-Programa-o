using ProjetoAula.Objects.DTOs;
using ProjetoAula.Objects.Models;

namespace ProjetoAula.Services.PedidoState;

public class AgaurdandoPagamentoState : IPedidoState
{
    private Pedido pedido;

    public AgaurdandoPagamentoState(PedidoDTO pedidoDTO)
    {

    }

    public void Cancelar()
    {
        throw new NotImplementedException();
    }

    public void Enviar()
    {
        throw new NotImplementedException();
    }
    public void Pagar()
    {
        throw new NotImplementedException();
    }

    public int GetEnum()
    {
        throw new NotImplementedException();
    }

}