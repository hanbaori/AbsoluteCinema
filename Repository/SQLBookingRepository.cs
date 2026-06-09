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

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _dbContext.Bookings
                .Include("Show")
                .Include("User")
                .ToListAsync();
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
