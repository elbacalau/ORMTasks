using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ORM.Models;
using ORM.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ORMDbContext _context;
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(ORMDbContext context, UserService userService, IConfiguration configuration)
        {
            _context = context;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _userService.Login(request.Email, request.Contrasena);
            if (usuario == null)
            {
                return Unauthorized(new { error = "Email o contraseña incorrectos" });
            }

            var token = GenerateJwtToken(usuario);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsers()
        {
            return await _context.Usuarios.ToListAsync();
        }

        
        [HttpPost("crear")]
        public IActionResult CrearUsuario([FromBody] CrearUsuarioRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { error = "Los datos no pueden ser nulos" });
            }

            try
            {
                var nuevoUsuario = _userService.CrearUsuario(
                    request.Nombre,
                    request.Apellido,
                    request.SegundoApellido,  
                    request.Contrasena, 
                    request.FechaNacimiento,
                    request.Email,
                    request.Ciudad,
                    request.Poblacion,
                    request.NumeroTelefono
                );
                return Ok(nuevoUsuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("eliminarUsuario/{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var resultado = await _userService.EliminarUsuarioPorId(id);

            if (!resultado)
            {
                return NotFound(new { error = "Usuario no encontrado" });
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("eliminarUsuarios")]
        public async Task<IActionResult> EliminarUsuarios()
        {
            return await _userService.EliminarTodosUsuarios()
                ? NoContent()
                : NotFound(new { error = "No hay usuarios" });
        }

        public class CrearUsuarioRequest
        {
            public required string Nombre { get; set; }
            public required string Apellido { get; set; }
            public string? SegundoApellido { get; set; }
            public required string Email { get; set; }
            public required string Contrasena { get; set; }
            public required DateTime FechaNacimiento { get; set; }
            public required string Ciudad { get; set; }
            public required string Poblacion { get; set; }
            public required string NumeroTelefono { get; set; }
        }

        public class LoginRequest
        {
            public required string Email { get; set; }
            public required string Contrasena { get; set; }
        }
    }
}