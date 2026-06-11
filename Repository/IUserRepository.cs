using AbsoluteCinema.Models.Domain;

namespace AbsoluteCinema.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllAsync();
    }
}
