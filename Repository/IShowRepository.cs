using AbsoluteCinema.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AbsoluteCinema.Repository
{
    public interface IShowRepository : IRepository<Show>
    {
        const int PAGNUMBER = 1;
        const int PAGNSIZE = 1;

        Task<List<Show>> GetAllAsync(
            string? filterOn = null, 
            string? filterQuery = null, 
            string? sortBy = null, 
            bool ascending = true, 
            int pagNumber = PAGNUMBER, 
            int pagSize = PAGNSIZE);
    }
}
