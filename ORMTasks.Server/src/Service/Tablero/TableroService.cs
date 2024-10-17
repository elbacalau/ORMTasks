using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ORM.Models;
using ORMTasks.Server.Migrations;

namespace ORMTasks.Server
{
    public class TablerService(ORMDbContext context)
    {
        private readonly ORMDbContext _context = context;


        public async Task<List<Tablero>> GetTableros()
        {
            if (!await _context.Tableros.AnyAsync())
            {
                return [];
            }

            return await _context.Tableros.ToListAsync();

        }

        public async Task<Tablero> GetTablero(int id)
        {
            
            var tablero = await _context.Tableros.SingleOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("No se ha encontrado el tablero");

            
            return tablero;
        }

    }
}