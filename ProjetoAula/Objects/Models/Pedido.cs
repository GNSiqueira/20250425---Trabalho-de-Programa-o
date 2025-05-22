using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoAula.Objects.Enums;

namespace ProjetoAula.Objects.Models;

[Table("pedido")]
public class Pedido
{
    [Key]
    [Column("id_pedido")]
    public int IdPedido { get; set; }

    [Column("valor_pedido")]
    public float ValorPedido { get; set; }

    [Column("status_pedido")]
    public StatusPedido StatusPedido { get; set; }

    [Column("tipo_frete")]
    public TipoFrete TipoFrete { get; set; }

    public Pedido() { }

    public Pedido(int idPedido, float valorPedido, StatusPedido statusPedido, TipoFrete tipoFrete)
    {
        IdPedido = idPedido;
        ValorPedido = valorPedido;
        StatusPedido = statusPedido;
        TipoFrete = tipoFrete;
    }

}
