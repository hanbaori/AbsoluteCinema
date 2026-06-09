using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Repository
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AbsoluteCinemaDbContext _dbContext;

        public SQLUserRepository(AbsoluteCinemaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await Save();
            return entity;
        }
        public async Task<User?> UpdateAsync(Guid id, User entity)
        {
            var exisitingEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingEntity == null)
            {
                return null;
            }

            exisitingEntity.Name = entity.Name;
            exisitingEntity.Role = entity.Role;
            exisitingEntity.Bookings = entity.Bookings;

            await Save();
            return entity;
        }
        public async Task<User?> DeleteAsync(Guid id)
        {
            var exisitingEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingEntity == null)
            {
                return null;
            }

            _dbContext.Users.Remove(exisitingEntity);
            await Save();
            return exisitingEntity;
        }
    }
}
