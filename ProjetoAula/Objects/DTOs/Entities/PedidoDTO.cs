using System;
using ProjetoAula.Objects.Enums;

namespace ProjetoAula.Objects.DTOs;

public class PedidoDTO
{
    public int id {get; set;}
    public float valorPedido {get; set;}
    public StatusPedido statusPedido {get; set;}
    public TipoFrete tipoFrete {get; set;}
}
