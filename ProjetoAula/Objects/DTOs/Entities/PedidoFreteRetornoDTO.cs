namespace ProjetoAula.Objects.DTOs.Entities;

public class PedidoFreteRetornoDTO
{
    public string TipoFrete { get; set; }
    public float ValorFrete { get; set; }
    public float ValorTotal { get; set; }

    public PedidoFreteRetornoDTO(string tipoFrete, float valorFrete, float valorTotal)
    {
        TipoFrete = tipoFrete;
        ValorFrete = valorFrete;
        ValorTotal = valorTotal;
    }
}
