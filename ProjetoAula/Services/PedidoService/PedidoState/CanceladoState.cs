using ProjetoAula.Objects.Models;
using ProjetoAula.Services.PedidoState;

namespace ProjetoAula.Services.PedidoService.PedidoState;

public class CanceladoState : IPedidoState
{
    private Pedido _pedido;

    public CanceladoState(Pedido pedido)
    {
        this._pedido = pedido;
    }

    public void Cancelar()
    {
        throw new ArgumentException("O pedido nao pode ser cancelado. Pedido ja cancelado.");
    }

    public void Enviar()
    {
        throw new ArgumentException("O pedido nao pode ser enviado. Pedido ja cancelado.");
    }
    public void Pagar()
    {
        throw new ArgumentException("O pedido nao pode ser pago. Pedido ja cancelado.");
    }

}