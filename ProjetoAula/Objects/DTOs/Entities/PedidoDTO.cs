using System;
using ProjetoAula.Objects.Enums;

namespace ProjetoAula.Objects.DTOs;

public class PedidoDTO
{
    public int IdPedido {get; set;}
    public float ValorPedido {get; set;}
    public StatusPedido StatusPedido {get; set;}
    public TipoFrete TipoFrete {get; set;}
}
