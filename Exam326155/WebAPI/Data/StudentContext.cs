using Microsoft.EntityFrameworkCore;
using Shared;
using WebAPI.Controllers;

namespace WebAPI.Data;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<GradeInCourse> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../WebAPI/Student.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //Student Table
        modelBuilder.Entity<Student>().HasKey(student => student.Id);
        
        modelBuilder.Entity<Student>().Property(student => student.Name)
            .IsRequired()
            .HasMaxLength(25);
        
        modelBuilder.Entity<Student>().Property(student => student.Programme)
            .IsRequired();

        
        //Grades
        modelBuilder.Entity<GradeInCourse>().HasKey(course => course.Id);
        
        modelBuilder.Entity<GradeInCourse>().Property(course => course.CourseCode)
            .IsRequired()
            .HasMaxLength(4);
        
        modelBuilder.Entity<GradeInCourse>().Property(course => course.Grade)
            .IsRequired();
    }
}