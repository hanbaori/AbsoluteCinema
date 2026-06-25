using AbsoluteCinema.Models.DTO;
using AbsoluteCinema.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbsoluteCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthenticationController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterUserDto requestRegisterUserDto)
        {
            var identityUser = new IdentityUser
            {
                Email = requestRegisterUserDto.UserEmail,
                UserName = requestRegisterUserDto.Username
            };
            var newUser = await _userManager.CreateAsync(identityUser, requestRegisterUserDto.Password);

            if (newUser.Succeeded)
            {
                if (requestRegisterUserDto.Roles != null || requestRegisterUserDto.Roles.Any())
                {
                    newUser = await _userManager.AddToRolesAsync(identityUser, requestRegisterUserDto.Roles);
                    if(newUser.Succeeded)
                        return Ok("User registered");
                }
            }

            return NotFound();
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginUserDTO requestLoginUserDTO)
        {

            var logedUser = await _userManager.FindByEmailAsync(requestLoginUserDTO.UserEmail);

            if(logedUser != null)
            {
                var checkPassword = await _userManager.CheckPasswordAsync(logedUser, requestLoginUserDTO.Password);

                if(checkPassword)
                {
                    var roles = await _userManager.GetRolesAsync(logedUser);
                    if (roles != null)
                    {
                        var jwt = _tokenRepository.CreateToken(logedUser, roles.ToList());

                        var response = new LoginResponseDTO { jwtToken = jwt };
                        return Ok(response);
                    }
                }
            }

            return NotFound("Email or password incorrect");
        }

        
    }
}
