using System.Collections.Generic; // Asegúrate de importar esta clase
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.Models;
using ORMTasks.DTO;

namespace ORMTasks.Server
{
    public class TablerService(ORMDbContext context)
    {
        private readonly ORMDbContext _context = context;

        public async Task<List<TableroDto>> GetTableros()
        {
            if (!await _context.Tableros.AnyAsync())
            {
                return [];
            }

            
            var tablerosDTO = await _context.Tableros
                .Include(t => t.Usuario) 
                .Select(tablero => new TableroDto
                {
                    Id = tablero.Id,
                    Titulo = tablero.Titulo,
                    Descripcion = tablero.Descripcion,
                    FechaCreacion = tablero.CreatedAt,
                    UserId = tablero.UserId,
                    Propietario = tablero.Usuario != null ? new PropietarioTableroDto
                    {
                        Id = tablero.Usuario.Id,
                        Nombre = tablero.Usuario.Nombre,
                        Apellido = tablero.Usuario.Apellido,
                        Email = tablero.Usuario.Email,
                        Ciudad = tablero.Usuario.Ciudad,
                        Poblacion = tablero.Usuario.Poblacion,
                        NumeroTelefono = tablero.Usuario.NumeroTelefono,
                    } : null
                })
                .ToListAsync();

            return tablerosDTO;
        }


        public async Task<TableroDto> GetTablero(int id)
        {
            var tablero = await _context.Tableros
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new KeyNotFoundException("Tablero no encontrado");

            var tableroDTO = new TableroDto
            {
                Id = tablero.Id,
                Titulo = tablero.Titulo,
                Descripcion = tablero.Descripcion,
                FechaCreacion = tablero.CreatedAt,
                UserId = tablero.UserId,
                Propietario = tablero.Usuario != null ? new PropietarioTableroDto
                {
                    Id = tablero.Usuario.Id,
                    Nombre = tablero.Usuario.Nombre,
                    Apellido = tablero.Usuario.Apellido,
                    Email = tablero.Usuario.Email,
                    Ciudad = tablero.Usuario.Ciudad,
                    Poblacion = tablero.Usuario.Poblacion,
                    NumeroTelefono = tablero.Usuario.NumeroTelefono,
                } : null
            };

            return tableroDTO;
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
