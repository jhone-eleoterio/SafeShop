using Microsoft.AspNetCore.Mvc;
using SafeShopAPI.Domain.Interfaces;
using SafeShopAPI.Domain.Models;
using SafeShopAPI.Services.Interfaces;

namespace SafeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _repository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ILogger<AuthController> logger,
            IUserRepository repository,
            ITokenService tokenService,
            IConfiguration configuration
        )
        {
            _logger = logger;
            _repository = repository;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userInDB = await _repository.FindByEmailAsync(viewModel.Email);

            if (userInDB is null)
                return NotFound("userNotFound");

            var token = _tokenService.GenerateToken($"{userInDB.Password}");

            if (token is null)
                return Unauthorized();
            else
                return Ok(new { token });
        }
    }
}
