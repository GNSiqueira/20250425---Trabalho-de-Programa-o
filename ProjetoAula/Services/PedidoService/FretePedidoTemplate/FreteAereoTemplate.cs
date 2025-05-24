using ProjetoAula.Objects.Models;

namespace ProjetoAula.Services.PedidoService.FretePedidoTemplate;

public class FreteAereoTemplate : AFreteTemplate
{

    public FreteAereoTemplate(Pedido pedido)
    {
        base.valor = pedido.ValorPedido;
    }
    public override float CalcularFrete()
    {
        return valor * 0.1f;
    }

    public override string GetTipoFrete()
    {
        return "Aereo";
    }

}
