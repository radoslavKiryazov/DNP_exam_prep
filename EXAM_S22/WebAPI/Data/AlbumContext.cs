using Microsoft.EntityFrameworkCore;
using Shared;

namespace WebAPI.Data;

public class AlbumContext : DbContext
{
    public DbSet<Album> albums { get; set; }
    public DbSet<Image> images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../WebAPI/Database/Albums.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Album Entity
        modelBuilder.Entity<Album>()
            .HasKey(a => a.Title);

        modelBuilder.Entity<Album>().Property(a => a.Title)
            .HasMaxLength(25)
            .IsRequired();

        modelBuilder.Entity<Album>().Property(a => a.Description)
            .HasMaxLength(150);
        
        modelBuilder.Entity<Album>().Property(a => a.CreatedBy)
            .IsRequired();

        modelBuilder.Entity<Album>()
            .HasMany(a => a.Images)
            .WithOne(i => i.Album);


        //Images
        modelBuilder.Entity<Image>()
            .HasKey(i => i.Title);

        modelBuilder.Entity<Image>()
            .HasOne(i => i.Album)
            .WithMany(a => a.Images);

        modelBuilder.Entity<Image>().Property(image => image.Title)
            .HasMaxLength(25)
            .IsRequired();
        
        modelBuilder.Entity<Image>().Property(image => image.Description)
            .IsRequired();
        
        modelBuilder.Entity<Image>().Property(image => image.URI)
            .IsRequired();

        modelBuilder.Entity<Image>().Property(image => image.Topic)
            .IsRequired();

    }
}