using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.DTO;
using AbsoluteCinema.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;
        private readonly IMapper _mapper;

        public ShowController(IShowRepository showRepository, IMapper mapper)
        {
            _showRepository = showRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var showsDomain = await _showRepository.GetAllAsync();
            return Ok(_mapper.Map<List<ShowDTO>>(showsDomain));
        }

        [HttpGet, Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var showDomain = await _showRepository.GetByIdAsync(id);

            if (showDomain == null)
                return NotFound();

            return Ok(_mapper.Map<ShowDTO>(showDomain));
        }

        [HttpPost]
        public async Task<IActionResult> CreateShow([FromBody] RequestShowDTO showRequestDTO)
        {
            var showDomain = await _showRepository.CreateAsync(_mapper.Map<Show>(showRequestDTO));

            var showDTO = _mapper.Map<ShowDTO>(showDomain);

            return CreatedAtAction(nameof(GetById), new { id = showDTO.Id }, showDTO);
        }

        [HttpPut, Route("{id:Guid}")]
        public async Task<IActionResult> UpdateShow([FromRoute] Guid id, [FromBody] RequestShowDTO showUpdateDTO)
        {
            var showDomain = await _showRepository.UpdateAsync(id, _mapper.Map<Show>(showUpdateDTO));

            if (showDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ShowDTO>(showDomain)); 
        }

        [HttpDelete, Route("{id:Guid}")]
        public async Task<IActionResult> DeleteShow([FromRoute] Guid id)
        {
            var showDomain = await _showRepository.DeleteAsync(id);
            
            if (showDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ShowDTO>(showDomain));
        }
    }
}
