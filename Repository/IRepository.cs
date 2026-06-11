using AbsoluteCinema.Models.Domain;

namespace AbsoluteCinema.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(Guid id, T entity);
        Task<T?> DeleteAsync(Guid id);
    }
}
