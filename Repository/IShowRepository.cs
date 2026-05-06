using AbsoluteCinema.Models.Domain;

namespace AbsoluteCinema.Repository
{
    public interface IShowRepository
    {
        Task<List<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(Guid id);
        Task<Show> CreateAsync(Show show);
        Task<Show?> UpdateAsync(Guid id, Show show);
        Task<Show?> DeleteAsync (Guid id);
    }
}
