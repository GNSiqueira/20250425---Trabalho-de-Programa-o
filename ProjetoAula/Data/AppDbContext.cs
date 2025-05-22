// using AkariBeauty.Data.Builders;
// using AkariBeauty.Objects.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoAula.Data.Builders;
using ProjetoAula.Objects.Models;

namespace ProjetoAula.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configura os modelos e o banco de dados aqui
        PedidoBuilder.Build(modelBuilder);

    }
}

