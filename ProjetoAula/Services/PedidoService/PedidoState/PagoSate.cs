using ProjetoAula.Objects.Enums;
using ProjetoAula.Objects.Models;
using ProjetoAula.Services.PedidoState;

namespace ProjetoAula.Services.PedidoService.PedidoState;

public class PagoState : IPedidoState
{
    private Pedido _pedido;

    public PagoState(Pedido pedido)
    {
        this._pedido = pedido;
    }

    public void Cancelar()
    {
        _pedido.StatusPedido = StatusPedido.CANCELADO;
    }

    public void Enviar()
    {
        _pedido.StatusPedido = StatusPedido.ENVIADO;
    }
    public void Pagar()
    {
        throw new ArgumentException("O pedido não pode ser pago novamente. Pedido já pago.");
    }

}