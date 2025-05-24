using ProjetoAula.Objects.Enums;
using ProjetoAula.Objects.Models;
using ProjetoAula.Services.PedidoService.PedidoState;

namespace ProjetoAula.Services.PedidoState;

public static class SetStatePedido
{
    public static IPedidoState SetState(Pedido pedido)
    {
        var state = pedido.StatusPedido;

        switch (state)
        {
            case StatusPedido.AGUARDANDO_PAGAMENTO:
                return new AguardandoPagamentoState(pedido);
            case StatusPedido.PAGO:
                return new PagoState(pedido);
            case StatusPedido.ENVIADO: 
                return new EnviadoState(pedido);
            case StatusPedido.CANCELADO:
                return new CanceladoState(pedido);
            default:
                return new AguardandoPagamentoState(pedido);
        }
    }
}
