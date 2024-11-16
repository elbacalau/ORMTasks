using ORM.Models;

namespace ORMTasks.DTO
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Ciudad { get; set; }
        public string? Poblacion { get; set; }
        public string? NumeroTelefono { get; set; }

        public List<UserProfileTableroDto>? Tableros { get; set; } = [];
    }


    public class PropietarioTableroDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Ciudad { get; set; }
        public string? Poblacion { get; set; }
        public string? NumeroTelefono { get; set; }
    }

}