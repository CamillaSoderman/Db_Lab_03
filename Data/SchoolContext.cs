using System;
using System.Collections.Generic;
using Db_Lab_03.Models;
using Microsoft.EntityFrameworkCore;

namespace Db_Lab_03.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Enrolment> Enrolments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__9526E27678735AB8");

            entity.ToTable("Course");
            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.CourseName).HasMaxLength(50);
            
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__9158E42B9791316A");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpFirstName).HasMaxLength(50);
            entity.Property(e => e.EmpLastName).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasMaxLength(50);
            entity.Property(e => e.EmploymentDate).HasColumnType("datetime");
        });


        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B9938FE5694");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.Sadress)
                .HasMaxLength(50)
                .HasColumnName("SAdress");

            entity.Property(e => e.SfirstName)
                .HasMaxLength(50)
                .HasColumnName("SFirstName");

            entity.Property(e => e.SlastName)
                .HasMaxLength(50)
                .HasColumnName("SLastName");

            entity.Property(e => e.StudentNsn)
                .HasMaxLength(50)
                .HasColumnName("StudentNSN");
        });

        modelBuilder.Entity<Enrolment>(entity =>
        {
            entity.HasKey(e => e.EnrolmentId).HasName("PK__Enrolmen__C3B4DFFA3A3D3A3D");
            entity.ToTable("Enrolment");
            entity.Property(e => e.EnrolmentId).ValueGeneratedNever();
            entity.Property(e => e.CourseId).HasMaxLength(50);
            entity.Property(e => e.StudentId).HasMaxLength(50);
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.GradeDate).HasColumnType("datetime");
            entity.Property(e => e.Grade).HasMaxLength(2);


            
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A3A3D3A3D");
            entity.ToTable("Roles");
            entity.Property(e => e.RoleId).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });



        OnModelCreatingPartial(modelBuilder);
    }

   

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    // Used this method to double check that all migrations were applied
    //public class MigrationChecker
    //{
    //    public static void CheckPendingMigrations(SchoolContext context)
    //    {
    //        var pendingMigrations = context.Database.GetPendingMigrations();
    //        if (pendingMigrations.Any())
    //        {
    //            Console.WriteLine("There are pending migrations:");
    //            foreach (var migration in pendingMigrations)
    //            {
    //                Console.WriteLine(migration);
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("All migrations are applied.");
    //        }
    //    }
    //}
}
