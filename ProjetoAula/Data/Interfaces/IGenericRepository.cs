namespace ProjetoAula.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity, int id);
        Task Remove(int id);
        Task<bool> SaveChanges();
    }
}