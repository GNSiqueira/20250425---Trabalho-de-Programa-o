using ProjetoAula.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ProjetoAula.Data.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var pedido = await _dbSet.FindAsync(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido nao encontrado");
            return pedido;
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Update(T entity, int id)
        {
            var existente = await _dbSet.FindAsync(id);
            if (existente == null)
                throw new KeyNotFoundException("Pedido não encontrado.");

            _context.Entry(existente).CurrentValues.SetValues(entity);

            var sucesso = await SaveChanges();
            if (!sucesso)
                throw new Exception("Erro ao salvar as alterações.");
        }

        public async Task Remove(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new ArgumentException("Pedido nao encontrado");

            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}