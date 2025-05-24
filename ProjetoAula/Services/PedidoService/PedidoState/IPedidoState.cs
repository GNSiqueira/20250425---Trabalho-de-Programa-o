namespace ProjetoAula.Services.PedidoState; 

public interface IPedidoState
{
    public void Pagar();
    public void Cancelar();
    public void Enviar();
}