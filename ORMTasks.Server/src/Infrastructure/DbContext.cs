using Microsoft.EntityFrameworkCore;
using ORM.Models;

public class ORMDbContext : DbContext
{
    public ORMDbContext(DbContextOptions<ORMDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tablero>().ToTable("Tableros");
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tablero> Tableros { get; set; }
}