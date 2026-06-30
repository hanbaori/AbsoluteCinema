using AbsoluteCinema.Models.Domain;

namespace AbsoluteCinema.Repository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        const int PAGNUMBER = 1;
        const int PAGNSIZE = 5;

        Task<List<Booking>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool ascending = true,
            int pagNumber = PAGNUMBER,
            int pagSize = PAGNSIZE);
    }
}
