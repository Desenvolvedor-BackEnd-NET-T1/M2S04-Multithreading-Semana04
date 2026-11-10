using Microsoft.EntityFrameworkCore;
using PizzariaByte.Api.Models;

namespace PizzariaByte.Api.Data;

public class PizzariaContext : DbContext
{
    public PizzariaContext(DbContextOptions<PizzariaContext> options)
        : base(options) { }

    public DbSet<Pizza> Pizzas => Set<Pizza>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>()
            .Property(p => p.Preco)
            .HasPrecision(8, 2);

        // Cardápio inicial
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza { Id = 1, Sabor = "Calabresa", Preco = 45.90m },
            new Pizza { Id = 2, Sabor = "Margherita", Preco = 42.90m },
            new Pizza { Id = 3, Sabor = "Portuguesa", Preco = 49.90m });
    }
}
