using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Tablero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Titulo { get; set; }

        public required string Descripcion { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }
    }
}
