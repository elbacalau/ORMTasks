namespace ORMTasks.DTO
{
    public class TableroDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UserId { get; set; }
        public PropietarioTableroDto? Propietario { get; set; }
    }

    public class UserProfileTableroDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

}
