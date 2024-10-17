using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Security;
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
        [HttpGet("/tablero/{id}")]
        public async Task<IActionResult> GetTablero(int id)
        {
            try
            {
                var tablero = await _tableroService.GetTablero(id);
                return Ok(tablero);
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


        // TODO: metodo para crear tablero


    }
}