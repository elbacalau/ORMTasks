using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ORM.Models;
using ORMTasks.DTO;
using System.Threading.Tasks;

namespace ORM.Services
{
    public class UserService
    {
        private readonly ORMDbContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UserService(ORMDbContext context, IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public Usuario CrearUsuario(string nombre, string apellido, string? segundoApellido, string contrasena, DateTime fechaNacimiento, string email, string ciudad, string poblacion, string numeroTelefono)
        {
            var usuarioExistente = _context.Usuarios.SingleOrDefault(u => u.Email == email);
            if (usuarioExistente != null)
            {
                throw new Exception("El email ya está en uso");
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                SegundoApellido = segundoApellido,
                Email = email,
                Contrasena = BCrypt.Net.BCrypt.HashPassword(contrasena),
                FechaRegistro = DateTime.Now,
                FechaNacimiento = fechaNacimiento,
                Ciudad = ciudad,
                Poblacion = poblacion,
                NumeroTelefono = numeroTelefono,
            };

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();

            return nuevoUsuario;
        }

        public async Task<Usuario?> Login(string email, string contrasena)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {

                return null;
            }



            var password = "test";
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine($"Hash generado: {hash}");


            if (!BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena))
            {

                return null;
            }

            return usuario;
        }


        public async Task<bool> EliminarTodosUsuarios()
        {
            if (!_context.Usuarios.Any())
            {
                return false;
            }

            var usuarios = await _context.Usuarios.ToListAsync();

            _context.Usuarios.RemoveRange(usuarios);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarUsuarioPorId(int userId)
        {
            var usuario = await _context.Usuarios.FindAsync(userId);

            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioDto?> GetUserByIdAsnyc(int userId) 
        {
            var user = await _context.Usuarios
                .Include(u => u.Tableros)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return null;

            return new UsuarioDto
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                SegundoApellido = user.SegundoApellido,
                Email = user.Email,
                FechaRegistro = user.FechaRegistro,
                FechaNacimiento = user.FechaNacimiento,
                Ciudad = user.Ciudad,
                Poblacion = user.Poblacion,
                NumeroTelefono = user.NumeroTelefono,
                Tableros = user.Tableros.Select(t => new TableroDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descripcion = t.Descripcion
                }).ToList()
            };
        }



    }
}
