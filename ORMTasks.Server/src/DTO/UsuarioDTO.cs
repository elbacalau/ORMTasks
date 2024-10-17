namespace ORMTasks.DTO
{
    public class UsuarioDto
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public string? SegundoApellido { get; set; }
    public required string Email { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public required string Ciudad { get; set; }
    public required string Poblacion { get; set; }
    public required string NumeroTelefono { get; set; }
}

}