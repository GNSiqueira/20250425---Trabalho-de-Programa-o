namespace ProjetoAula.Services.PedidoService.FretePedidoTemplate;

public abstract class AFreteTemplate
{
    protected float valor;

    public abstract float CalcularFrete();

    public abstract string GetTipoFrete();

    public float GetValorTotal()
    {
        return CalcularFrete() + valor;
    }
}
