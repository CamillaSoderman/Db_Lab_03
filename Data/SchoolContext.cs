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

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseName).HasName("PK__Course__9526E27678735AB8");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);

            entity.HasOne(d => d.EmployeeNameNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.EmployeeName)
                .HasConstraintName("FK__Course__Employee__3D5E1FD2");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeName).HasName("PK__Employee__9158E42B9791316A");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A5775C9BEFF");

            entity.Property(e => e.GradeId).ValueGeneratedNever();
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.Grade1)
                .HasMaxLength(2)
                .HasColumnName("Grade");
            entity.Property(e => e.ReportDate).HasColumnName("Report_Date");
            entity.Property(e => e.SfirstName)
                .HasMaxLength(50)
                .HasColumnName("SFirstName");
            entity.Property(e => e.SlastName)
                .HasMaxLength(50)
                .HasColumnName("SLastName");

            entity.HasOne(d => d.CourseNameNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.CourseName)
                .HasConstraintName("FK__Grades__CourseNa__403A8C7D");

            entity.HasOne(d => d.EmployeeNameNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.EmployeeName)
                .HasConstraintName("FK__Grades__Employee__412EB0B6");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
