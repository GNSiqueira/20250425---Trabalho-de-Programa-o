using ProjetoAula.Objects.Enums;
using ProjetoAula.Objects.Models;
using ProjetoAula.Services.PedidoState;

namespace ProjetoAula.Services.PedidoService.PedidoState;

public class AguardandoPagamentoState : IPedidoState
{
    private Pedido _pedido;

    public AguardandoPagamentoState(Pedido pedido)
    {
        this._pedido = pedido;
    }

    public void Cancelar()
    {
        _pedido.StatusPedido = StatusPedido.CANCELADO;
    }

    public void Enviar()
    {
        throw new ArgumentException("O pedido nao pode ser enviado. Pedido não pago.");
    }
    public void Pagar()
    {
        _pedido.StatusPedido = StatusPedido.PAGO;
    }

}