using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("GetUser/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }
        private string GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var id = "";
            if (identity != null)
            {
                var userClaims = identity.Claims;
                id = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
            }
            return id;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult> Register([FromBody] RegistrationRequestDto request)
        {
            if (ModelState.IsValid)
            {
                // Check email for matches
                var userExist = await _userManager.FindByEmailAsync(request.Email);
                if (userExist != null)
                    return BadRequest(new AuthResult() { 
                        Result = false,
                        Errors = new List<string>() { "Email already exist" }
                    });

                if (request.Password == request.PasswordConfirm)
                {
                    // Create new user
                    ApplicationUser createUser = new ApplicationUser()
                    {
                        UserName = request.Email,
                        Email = request.Email
                    };
                    var isCreated = await _userManager.CreateAsync(createUser, request.Password);

                    if (isCreated.Succeeded)
                    {
                        // Generate the token
                        var jwtToken = GenerateJwtToken(createUser);
                        return Ok(new AuthResult()
                        {
                            Result = true,
                            Token = jwtToken
                        });
                    }
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>() { "Server error" }
                    });
                }             
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(loginRequest.Email);
                if (existingUser == null)
                    return BadRequest(new AuthResult() { 
                        Result = false,
                        Errors = new List<string>() { "Invalid payload" }
                    });

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginRequest.Password);
                if (!isCorrect)
                    return BadRequest(new AuthResult() { 
                        Result = false,
                        Errors = new List<string>() { "Invalid Credantials" }
                    });

                var jwtToken = GenerateJwtToken(existingUser);
                return Ok(new AuthResult() {
                    Id = existingUser.Id,
                    Result = true,
                    Token = jwtToken
                });

            }

            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>() { "Invalid payload" }
            });
        }


        private string GenerateJwtToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            // Create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    //new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
