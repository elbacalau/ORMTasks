using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Apellido { get; set; } = null!;

        public string? SegundoApellido { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!; 

        [Required]
        [MinLength(6)]
        public string Contrasena { get; set; } = null!; 

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Ciudad { get; set; } = null!;

        [Required]
        public string Poblacion { get; set; } = null!;

        [Required]
        [Phone]
        public string NumeroTelefono { get; set; } = null!; 
        public virtual ICollection<Tablero> Tableros { get; set; } = new List<Tablero>();
    }
}
