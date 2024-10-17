using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Tablero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(25)]
        public required string Titulo { get; set; }

        public required string Descripcion { get; set; }
        public int UserId {get; set;}

        [ForeignKey("UserId")]
        public Usuario? Usuario {get; set;}
    }
}