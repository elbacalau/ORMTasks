using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Nombre { get; set; }
        public required string Apellido { get; set; }

        public string? SegundoApellido { get; set; }
        public required string Email { get; set; }
        public required string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public required DateTime FechaNacimiento { get; set; }
        public required string Ciudad { get; set; }
        public required string Poblacion { get; set; }

        public required string NumeroTelefono { get; set; }
    }
}
