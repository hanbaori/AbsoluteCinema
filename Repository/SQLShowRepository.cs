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
        public async Task<Show> CreateAsync(Show show)
        {
            await _dbContext.Shows.AddAsync(show);
            Save();
            return show;
        }
        public async Task<Show?> UpdateAsync(Guid id, Show show)
        {
            var exisitingShow = await _dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingShow == null)
            {
                return null;
            }

            exisitingShow.Name = show.Name;
            exisitingShow.Description = show.Description;
            exisitingShow.ShowDate = show.ShowDate;
            exisitingShow.ShowImageUrl = show.ShowImageUrl;

            Save();
            return show;
        }
        public async Task<Show?> DeleteAsync(Guid id)
        {
            var exisitingShow = await _dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingShow == null)
            {
                return null;
            }

            _dbContext.Shows.Remove(exisitingShow);
            Save();
            return exisitingShow;
        }
    }
}
