using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Models;
using ORMTasks.Server;

namespace ORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableroController : ControllerBase
    {
        private readonly ORMDbContext _context;
        private readonly TablerService _tableroService;

        public TableroController(ORMDbContext context, TablerService tableroService)
        {
            _context = context;
            _tableroService = tableroService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTableros()
        {
            var tableros = await _tableroService.GetTableros();
            return Ok(tableros);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTablero(int id)
        {
            try
            {
                var tableroDTO = await _tableroService.GetTablero(id);
                return Ok(tableroDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocurrio un error: ", ex.Message });
            }
        }

        [Authorize]
        [HttpPost("crear")]
        [ProducesResponseType(typeof(Tablero), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearTablero([FromBody] TableroRequest request)
        {
            
            if (request == null)
            {
                return BadRequest(new { error = "Los datos del tablero son requeridos" });
            }

            // Obtener el ID del usuario autenticado desde las claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest(new { error = "No se pudo obtener el ID del usuario autenticado" });
            }

            
            try
            {
                var tablero = await _tableroService.CrearTablero(
                    userId: userId,
                    titulo: request.Titulo,
                    descripcion: request.Descripcion
                );

                return CreatedAtAction(nameof(GetTablero), new { id = tablero.Id }, tablero);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> BorrarTableros()
        {
            try
            {
                return await _tableroService.BorrarTableros()
                ? NoContent()
                : NotFound(new { error = "No hay tableros" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocurrio un error: ", ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarTablero(int id)
        {
            try
            {
                return await _tableroService.BorrarTablero(id)
                ? Ok("Borrado con exito")
                : NotFound(new { error = "No se ha encontrado el tablero" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocurrio un error: ", ex.Message });
            }
        }

        // DTO para el request del tablero
        public class TableroRequest
        {
            [Required]
            public required string Titulo { get; set; }

            [Required]
            public required string Descripcion { get; set; }
        }
    }
}
