using Farmacia.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Pharmacy> Pharmacies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pharmacy>().HasData(
            new Pharmacy { Id = 1, Nome = "Farmacia do Bairro", Endereco = "Rua dos Abacaxis", Horario = "08:00 às 20:00"},
            new Pharmacy { Id = 2, Nome = "Farmacia Leve mais", Endereco = "Rua dos Abacates", Horario = "08:00 às 21:00" },
            new Pharmacy { Id = 3, Nome = "Farmacia Amiga", Endereco = "Ameixas", Horario = "07:00 às 21:00"}
    );
    }
}
