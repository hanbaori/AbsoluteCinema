using System.Text.Json;
using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.DTO;
using AbsoluteCinema.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<BookingController> _logger;

    public BookingController(IMapper mapper,
        IBookingRepository bookingRepository,
        ILogger<BookingController> logger)
    {
        _mapper = mapper;
        _bookingRepository = bookingRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation($"{nameof(GetAll)} called");
        var bookingDomain = await _bookingRepository.GetAllAsync();
        _logger.LogInformation($"{nameof(GetAll)} returned {bookingDomain.Count} bookings");
        return Ok(_mapper.Map<List<BookingDTO>>(bookingDomain));
    }

    [HttpGet, Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        _logger.LogInformation($"{nameof(GetById)} called with id: {id}");
        var bookingDomain = await _bookingRepository.GetByIdAsync(id);
        if (bookingDomain == null)
        {
            _logger.LogWarning($"{nameof(GetById)} booking with id: {id} not found");
            return NotFound();
        }
        return Ok(_mapper.Map<BookingDTO>(bookingDomain));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] RequestBookingDTO requestBookingDTO)
    {
        _logger.LogInformation($"{nameof(CreateBooking)} called with data: {JsonSerializer.Serialize(requestBookingDTO)}");
        var bookingDomain = await _bookingRepository.CreateAsync(_mapper.Map<Booking>(requestBookingDTO));
        var bookingDTO = _mapper.Map<BookingDTO>(bookingDomain);
        return CreatedAtAction(nameof(GetById), new { id = bookingDTO.Id }, bookingDTO);
    }

    [HttpPut, Route("{id:Guid}")]
    public async Task<IActionResult> UpdateBooking([FromRoute] Guid id, [FromBody] RequestBookingDTO requestBookingDTO)
    {
        _logger.LogInformation($"{nameof(UpdateBooking)} called with id: {id} and data: {JsonSerializer.Serialize(requestBookingDTO)}");
        var bookingDomain = await _bookingRepository.UpdateAsync(id, _mapper.Map<Booking>(requestBookingDTO));
        if (bookingDomain == null)
        {
            _logger.LogWarning($"{nameof(UpdateBooking)} booking with id: {id} not found");
            return NotFound();
        }
        return Ok(_mapper.Map<BookingDTO>(bookingDomain));
    }

    [HttpDelete, Route("{id:Guid}")]
    public async Task<IActionResult> DeleteBooking([FromRoute] Guid id)
    {
        _logger.LogInformation($"{nameof(DeleteBooking)} called with id: {id}");
        var bookingDomain = await _bookingRepository.DeleteAsync(id);
        if (bookingDomain == null)
        {
            _logger.LogWarning($"{nameof(DeleteBooking)} booking with id: {id} not found");
            return NotFound();
        }
        return Ok(_mapper.Map<BookingDTO>(bookingDomain));
    }
}