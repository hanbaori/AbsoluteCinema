using AbsoluteCinema.Models.Domain;

namespace AbsoluteCinema.Repository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<List<Booking>> GetAllAsync();
    }
}
