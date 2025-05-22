using ProjetoAula.Data.Interfaces;
using ProjetoAula.Objects.Models;

namespace ProjetoAula.Data.Repositories;

public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context) : base(context)
    {
        this._context = context;
    }
}
