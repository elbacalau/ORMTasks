using System.Collections.Generic; // Asegúrate de importar esta clase
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORMTasks.Server
{
    public class TablerService
    {
        private readonly ORMDbContext _context;

        // Constructor corregido
        public TablerService(ORMDbContext context)
        {
            _context = context;
        }

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
            var tablero = await _context.Tableros.SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new KeyNotFoundException("No se ha encontrado el tablero");

            return tablero;
        }

        public async Task<Tablero> CrearTablero(int userId, string titulo, string descripcion)
        {

            if (await _context.Tableros.AnyAsync(t => t.Titulo == titulo && t.UserId == userId))
            {
                throw new Exception("Ya existe un tablero con este título para el usuario");
            }


            var tablero = new Tablero
            {
                UserId = userId,
                Titulo = titulo,
                Descripcion = descripcion
            };


            _context.Tableros.Add(tablero);
            await _context.SaveChangesAsync();

            return tablero;
        }


        public async Task<bool> BorrarTableros()
        {

            if (!_context.Tableros.Any())
            {
                return false;
            }

            var tablero = await _context.Tableros.ToListAsync();

            _context.Tableros.RemoveRange(tablero);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BorrarTablero(int id)
        {
            // encontrar el tablero
            var tablero = await _context.Tableros.FindAsync(id);

            if (tablero == null)
            {
                return false;

            }
            _context.Tableros.Remove(tablero);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
