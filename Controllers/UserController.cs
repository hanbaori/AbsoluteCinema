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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usersDomain = await _userRepository.GetAllAsync();
            return Ok(_mapper.Map<List<UserDTO>>(usersDomain));
        }

        [HttpGet, Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userDomain = await _userRepository.GetByIdAsync(id);

            if (userDomain == null) 
                return NotFound();

            return Ok(_mapper.Map<UserDTO>(userDomain));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RequestUserDTO userRequestDTO)
        {
            var userDomain = await _userRepository.CreateAsync(_mapper.Map<User>(userRequestDTO));

            var userDTO = _mapper.Map<UserDTO>(userDomain);

            return CreatedAtAction(nameof(GetById), new { id = userDTO.Id }, userDTO);
        }

        [HttpPut, Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] RequestUserDTO userUpdateDTO)
        {
            var userDomain = await _userRepository.UpdateAsync(id, _mapper.Map<User>(userUpdateDTO));

            if (userDomain == null)
                return NotFound();

            return Ok(_mapper.Map<UserDTO>(userDomain));
        }

        [HttpDelete, Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var userDomain = await _userRepository.DeleteAsync(id);

            if (userDomain == null)
                return NotFound();

            return Ok(_mapper.Map<UserDTO>(userDomain));
        }
    }
}
