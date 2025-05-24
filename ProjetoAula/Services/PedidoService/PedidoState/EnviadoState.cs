using ProjetoAula.Objects.Models;
using ProjetoAula.Services.PedidoState;

namespace ProjetoAula.Services.PedidoService.PedidoState;

public class EnviadoState : IPedidoState
{
    private Pedido _pedido;

    public EnviadoState(Pedido pedido)
    {
        this._pedido = pedido;
    }

    public void Cancelar()
    {
        throw new ArgumentException("O pedido não pode ser cancelado. Pedido já enviado.");
    }

    public void Enviar()
    {
        throw new ArgumentException("O pedido não pode ser enviado novamente. Pedido já enviado.");
    }
    public void Pagar()
    {
        throw new ArgumentException("O pedido não pode ser pago novamente. Pedido já pago.");
    }


}