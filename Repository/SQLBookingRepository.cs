using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Repository
{
    public class SQLBookingRepository : IBookingRepository
    {
        private readonly AbsoluteCinemaDbContext _dbContext;
        public SQLBookingRepository(AbsoluteCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllAsync(
                    string? filterOn = null,
                    string? filterQuery = null,
                    string? sortBy = null,
                    bool ascending = true,
                    int pagNumber = IBookingRepository.PAGNUMBER,
                    int pagSize = IBookingRepository.PAGNSIZE)
        {
            var bookings = _dbContext.Bookings
                .Include("Show")
                .Include("User")
                .AsQueryable();

            if (!(string.IsNullOrWhiteSpace(filterOn)) && !(string.IsNullOrWhiteSpace(filterQuery)))
            {
                if (filterOn.Equals("ShowId", StringComparison.OrdinalIgnoreCase))
                {
                    if (Guid.TryParse(filterQuery, out var showId))
                        bookings = bookings.Where(x => x.ShowId == showId);
                }
                else if (filterOn.Equals("UserId", StringComparison.OrdinalIgnoreCase))
                {
                    if (Guid.TryParse(filterQuery, out var userId))
                        bookings = bookings.Where(x => x.UserId == userId);
                }
            }

            if (!(string.IsNullOrWhiteSpace(sortBy)))
            {
                if (sortBy.Equals("BookedSeats", StringComparison.OrdinalIgnoreCase))
                {
                    bookings = ascending ? bookings.OrderBy(x => x.BookedSeats) : bookings.OrderByDescending(x => x.BookedSeats);
                }
            }

            var skipPag = (pagNumber - 1) * pagSize;
            return await bookings.Skip(skipPag).Take(pagSize).ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Bookings
                .Include("Show")
                .Include("User")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Booking> CreateAsync(Booking entity)
        {
            await _dbContext.Bookings.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<Booking?> UpdateAsync(Guid id, Booking entity)
        {
            var exisitingEntity = await GetByIdAsync(id);
            if (exisitingEntity == null) 
                return null;
            exisitingEntity.User = entity.User;
            exisitingEntity.Show = entity.Show;
            exisitingEntity.BookedSeats = entity.BookedSeats;

            await Save();
            return exisitingEntity;
        }

        public async Task<Booking?> DeleteAsync(Guid id)
        {
            var exisitingEntity = await GetByIdAsync(id);
            if (exisitingEntity == null)
                return null;

            _dbContext.Bookings.Remove(exisitingEntity);
            await Save();
            return exisitingEntity;
        }
    }
}
