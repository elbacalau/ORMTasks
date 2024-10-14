using Microsoft.EntityFrameworkCore;
using ORM.Models;

public class ORMDbContext : DbContext
{
    public ORMDbContext(DbContextOptions<ORMDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().ToTable("usuarios");
    }

    public DbSet<Usuario> Usuarios { get; set; }
}