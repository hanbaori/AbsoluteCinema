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
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            ITokenRepository tokenRepository,
            ILogger<AuthenticationController> logger)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _logger = logger;
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterUserDto requestRegisterUserDto)
        {
            _logger.LogInformation($"{nameof(Register)} called with username: {requestRegisterUserDto.Username}, email: {requestRegisterUserDto.UserEmail}");

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
                    if (newUser.Succeeded)
                    {
                        _logger.LogInformation($"{nameof(Register)} user registered successfully: {requestRegisterUserDto.Username}");
                        return Ok("User registered");
                    }
                }
            }

            _logger.LogWarning($"{nameof(Register)} failed to register user: {requestRegisterUserDto.Username}");
            return NotFound();
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginUserDTO requestLoginUserDTO)
        {
            _logger.LogInformation($"{nameof(Login)} called with email: {requestLoginUserDTO.UserEmail}");

            var logedUser = await _userManager.FindByEmailAsync(requestLoginUserDTO.UserEmail);
            if (logedUser != null)
            {
                var checkPassword = await _userManager.CheckPasswordAsync(logedUser, requestLoginUserDTO.Password);
                if (checkPassword)
                {
                    var roles = await _userManager.GetRolesAsync(logedUser);
                    if (roles != null)
                    {
                        var jwt = _tokenRepository.CreateToken(logedUser, roles.ToList());
                        var response = new LoginResponseDTO { jwtToken = jwt };
                        _logger.LogInformation($"{nameof(Login)} user logged in successfully: {requestLoginUserDTO.UserEmail}");
                        return Ok(response);
                    }
                }
            }

            _logger.LogWarning($"{nameof(Login)} failed login attempt for email: {requestLoginUserDTO.UserEmail}");
            return NotFound("Email or password incorrect");
        }
    }
}
