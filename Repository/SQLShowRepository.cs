using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Repository
{
    public class SQLShowRepository : IShowRepository
    {
        private readonly AbsoluteCinemaDbContext _dbContext;

        public SQLShowRepository(AbsoluteCinemaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async void Save()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Show>> GetAllAsync()
        {
            return await _dbContext.Shows.ToListAsync();
        }
        public async Task<Show?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Show> CreateAsync(Show entity)
        {
            await _dbContext.Shows.AddAsync(entity);
            Save();
            return entity;
        }
        public async Task<Show?> UpdateAsync(Guid id, Show entity)
        {
            var exisitingEntity = await _dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingEntity == null)
            {
                return null;
            }

            exisitingEntity.Name = entity.Name;
            exisitingEntity.Description = entity.Description;
            exisitingEntity.ShowDate = entity.ShowDate;
            exisitingEntity.ShowImageUrl = entity.ShowImageUrl;

            Save();
            return entity;
        }
        public async Task<Show?> DeleteAsync(Guid id)
        {
            var exisitingEntity = await _dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingEntity == null)
            {
                return null;
            }

            _dbContext.Shows.Remove(exisitingEntity);
            Save();
            return exisitingEntity;
        }
    }
}
