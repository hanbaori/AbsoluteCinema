using System.Text.Json;
using AbsoluteCinema.Data;
using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.DTO;
using AbsoluteCinema.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger _logger;

        public ShowController(IShowRepository showRepository, 
            IMapper mapper,
            ILogger<ShowController> logger)
        {
            _showRepository = showRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool ascending,
            [FromQuery] int pagNumber,
            [FromQuery] int pagSize
            )
        {
            _logger.LogInformation($"{nameof(GetAll)} called with filterOn: " +
                $"{filterOn}, filterQuery: {filterQuery}, " +
                $"sortBy: {sortBy}, ascending: {ascending}, " +
                $"pagNumber: {pagNumber}, pagSize: {pagSize}");

            var showsDomain = await _showRepository.GetAllAsync(filterOn, filterQuery, sortBy, ascending, pagNumber, pagSize);
            return Ok(_mapper.Map<List<ShowDTO>>(showsDomain));
        }

        [HttpGet, Route("{id:Guid}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            _logger.LogInformation($"{nameof(GetById)} request with id: {id}");
            var showDomain = await _showRepository.GetByIdAsync(id);

            if (showDomain == null)
            {
                _logger.LogWarning($"{nameof(GetById)} show with id: {id} not found");
                return NotFound();
            }

            return Ok(_mapper.Map<ShowDTO>(showDomain));
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateShow([FromBody] RequestShowDTO showRequestDTO)
        {
            _logger.LogInformation($"{nameof(CreateShow)} request with data: {JsonSerializer.Serialize(showRequestDTO)}");
            var showDomain = await _showRepository.CreateAsync(_mapper.Map<Show>(showRequestDTO));

            var showDTO = _mapper.Map<ShowDTO>(showDomain);

            return CreatedAtAction(nameof(GetById), new { id = showDTO.Id }, showDTO);
        }

        [HttpPut, Route("{id:Guid}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateShow([FromRoute] Guid id, [FromBody] RequestShowDTO showUpdateDTO)
        {
            _logger.LogInformation($"{nameof(UpdateShow)} called with id: {id} and data: {JsonSerializer.Serialize(showUpdateDTO)}");
            var showDomain = await _showRepository.UpdateAsync(id, _mapper.Map<Show>(showUpdateDTO));

            if (showDomain == null)
            {
                _logger.LogWarning($"{nameof(UpdateShow)} show with id: {id} not found");
                return NotFound();
            }

            return Ok(_mapper.Map<ShowDTO>(showDomain)); 
        }

        [HttpDelete, Route("{id:Guid}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteShow([FromRoute] Guid id)
        {
            _logger.LogInformation($"{nameof(DeleteShow)} called with id: {id}");
            var showDomain = await _showRepository.DeleteAsync(id);
            
            if (showDomain == null)
            {
                _logger.LogWarning($"{nameof(DeleteShow)} show with id: {id} not found");
                return NotFound();
            }

            return Ok(_mapper.Map<ShowDTO>(showDomain));
        }
    }
}
