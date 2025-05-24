using ProjetoAula.Objects.Models;

namespace ProjetoAula.Services.PedidoService.FretePedidoTemplate;

public class FreteTerrestreTemplate : AFreteTemplate
{
    public FreteTerrestreTemplate(Pedido pedido)
    {
        base.valor = pedido.ValorPedido;
    }
    public override float CalcularFrete()
    {
        return valor * 0.05f;
    }

    public override string GetTipoFrete()
    {
        return "Terrestre";
    }
}
