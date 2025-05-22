    using System;
    using Microsoft.EntityFrameworkCore;
    using ProjetoAula.Objects.Enums;
    using ProjetoAula.Objects.Models;

    namespace ProjetoAula.Data.Builders;

    public class PedidoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(p => p.IdPedido);

                entity.Property(p => p.ValorPedido).IsRequired();

                entity.Property(p => p.StatusPedido).IsRequired();

                entity.Property(p => p.TipoFrete).IsRequired();

                entity.HasData(
                    new List<Pedido>
                    {
                        new Pedido(1, 13.99f, StatusPedido.AGUARDANDO_PAGAMENTO, TipoFrete.TERRESTRE),
                        new Pedido(2, 13.99f, StatusPedido.AGUARDANDO_PAGAMENTO, TipoFrete.AEREO),
                        new Pedido(3, 13.99f, StatusPedido.AGUARDANDO_PAGAMENTO, TipoFrete.TERRESTRE)
                    }
                );

            });

        }
    }
