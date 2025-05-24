using ProjetoAula.Objects.Enums;
using ProjetoAula.Objects.Models;

namespace ProjetoAula.Services.PedidoService.FretePedidoTemplate;

public class SetTemplateFretePedido
{
    public static AFreteTemplate setTemplate(Pedido pedido)
    {
        var pedidoFrete = pedido.TipoFrete;

        switch (pedidoFrete)
        {
            case TipoFrete.TERRESTRE:
                return new FreteTerrestreTemplate(pedido);
            case TipoFrete.AEREO:
                return new FreteAereoTemplate(pedido);
            default:
                throw new ArgumentException("Tipo de frete nao encontrado.");
        }
    }
}
