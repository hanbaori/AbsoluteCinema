using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Repository
{
    public class SQLShowRepository : IShowRepository
    {
        private readonly AbsoluteCinemaDbContext dbContext;

        public SQLShowRepository(AbsoluteCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Show>> GetAllAsync()
        {
            return await dbContext.Shows.ToListAsync();
        }
        public async Task<Show?> GetByIdAsync(Guid id)
        {
            return await dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Show> CreateAsync(Show show)
        {
            await dbContext.Shows.AddAsync(show);
            await dbContext.SaveChangesAsync();
            return show;
        }
        public async Task<Show?> UpdateAsync(Guid id, Show show)
        {
            var exisitingShow = await dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingShow == null)
            {
                return null;
            }

            exisitingShow.Name = show.Name;
            exisitingShow.Description = show.Description;
            exisitingShow.ShowDate = show.ShowDate;
            exisitingShow.ShowImageUrl = show.ShowImageUrl;

            await dbContext.SaveChangesAsync();
            return show;
        }
        public async Task<Show?> DeleteAsync(Guid id)
        {
            var exisitingShow = await dbContext.Shows.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingShow == null)
            {
                return null;
            }

            dbContext.Shows.Remove(exisitingShow);
            await dbContext.SaveChangesAsync();
            return exisitingShow;
        }
    }
}
