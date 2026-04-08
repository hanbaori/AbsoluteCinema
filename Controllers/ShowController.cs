using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.DTO;
using AbsoluteCinema.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly AbsoluteCinemaDbContext dbContext;

        private readonly IShowRepository showRepository;

        public ShowController(AbsoluteCinemaDbContext dbContext, IShowRepository showRepository)
        {
            this.dbContext = dbContext;
            this.showRepository = showRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var showsDomain = await showRepository.GetAllAsync();

            var showsDTO = new List<ShowDTO>();
            foreach (var show in showsDomain)
            {
                showsDTO.Add(new ShowDTO
                {
                    Id = show.Id,
                    Name = show.Name,
                    Description = show.Description,
                    ShowDate = show.ShowDate,
                    ShowImageUrl = show.ShowImageUrl
                });
            }


            
            return Ok(showsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var showDomain = await showRepository.GetByIdAsync(id);

            if (showDomain == null)
            {
                return NotFound();
            }

            var showsDTO = new ShowDTO
            {
                Name = showDomain.Name,
                Description = showDomain.Description,
                ShowDate = showDomain.ShowDate,
                ShowImageUrl = showDomain.ShowImageUrl
            };

            return Ok(showsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShow([FromBody] RequestShowDTO showRequestDTO)
        {
            var showDomain = new Show
            {
                Name = showRequestDTO.Name,
                Description = showRequestDTO.Description,
                ShowDate = showRequestDTO.ShowDate,
                ShowImageUrl = showRequestDTO.ShowImageUrl
            };
            
            showDomain = await showRepository.CreateAsync(showDomain);

            var showDTO = new ShowDTO
            {
                Id = showDomain.Id,
                Name = showDomain.Name,
                Description = showDomain.Description,
                ShowDate = showDomain.ShowDate,
                ShowImageUrl = showDomain.ShowImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = showDTO.Id }, showDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateShow([FromRoute] Guid id, [FromBody] RequestShowDTO showUpdateDTO)
        {
            var showDomain = new Show
            {
                Name = showUpdateDTO.Name,
                Description = showUpdateDTO.Description,
                ShowDate = showUpdateDTO.ShowDate,
                ShowImageUrl = showUpdateDTO.ShowImageUrl
            };

            showDomain = await showRepository.UpdateAsync(id, showDomain);

            if (showDomain == null)
            {
                return NotFound();
            }

            var showDTO = new ShowDTO
            {
                Id = showDomain.Id,
                Name = showDomain.Name,
                Description = showDomain.Description,
                ShowDate = showDomain.ShowDate,
                ShowImageUrl = showDomain.ShowImageUrl
            };

            return Ok(showDTO); 
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteShow([FromRoute] Guid id)
        {
            var showDomain = await showRepository.DeleteAsync(id);
            
            if (showDomain == null)
            {
                return NotFound();
            }

            var showDTO = new ShowDTO
            {
                Id = showDomain.Id,
                Name = showDomain.Name,
                Description = showDomain.Description,
                ShowDate = showDomain.ShowDate,
                ShowImageUrl = showDomain.ShowImageUrl
            };

            return Ok(showDTO);
        }
    }
}
