using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace WebAPI.Data;

public class ToyContext : DbContext
{
    public DbSet<Child> Child { get; set; }
    public DbSet<Toy> Toy { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../WebApi/Database/Toys.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Child Entity
        modelBuilder.Entity<Child>()
            .HasKey(c => c.Name);

        modelBuilder.Entity<Child>().Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Child>().Property(c => c.Age)
            .IsRequired();
        modelBuilder.Entity<Child>().Property(c => c.Gender)
            .IsRequired();
        
        
        //Toy Entity
        modelBuilder.Entity<Toy>()
            .HasKey(t => t.Name);

        modelBuilder.Entity<Toy>().Property(toy => toy.Name)
            .IsRequired();

        modelBuilder.Entity<Toy>()
            .HasOne(t => t.child);

    }
}