using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.DTO;
using AbsoluteCinema.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbsoluteCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper,
            IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookingDomain = await _bookingRepository.GetAllAsync();
            return Ok(_mapper.Map<List<BookingDTO>>(bookingDomain));
        }

        [HttpGet, Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var bookingDomain = await _bookingRepository.GetByIdAsync(id);

            if (bookingDomain == null)
                return NotFound();

            return Ok(_mapper.Map<BookingDTO>(bookingDomain));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(
            [FromBody] RequestBookingDTO requestBookingDTO)
        {
            var bookingDomain = await _bookingRepository.CreateAsync(
                _mapper.Map<Booking>(requestBookingDTO));

            var bookingDTO = _mapper.Map<BookingDTO>(bookingDomain);

            return CreatedAtAction(
                nameof(GetById), new { id = bookingDTO.Id }, bookingDTO);
        }

        [HttpPut, Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBooking(
            [FromRoute] Guid id, [FromBody] RequestBookingDTO requestBookingDTO)
        {
            var bookingDomain = await _bookingRepository.UpdateAsync(
                id, _mapper.Map<Booking>(requestBookingDTO));

            if (bookingDomain == null)
                return NotFound();

            return Ok(_mapper.Map<BookingDTO>(bookingDomain));
        }

        [HttpDelete, Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] Guid id)
        {
            var bookingDomain = await _bookingRepository.DeleteAsync(id);

            if (bookingDomain == null)
                return NotFound();

            return Ok(_mapper.Map<BookingDTO>(bookingDomain));
        }
    }
}
