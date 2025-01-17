using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlQueryPractice.Models;

public partial class SqlPracticeContext : DbContext
{
    public SqlPracticeContext()
    {
    }

    public SqlPracticeContext(DbContextOptions<SqlPracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BatchStudent> BatchStudents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseBatch> CourseBatches { get; set; }

    public virtual DbSet<CourseModule> CourseModules { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FacultyAddress> FacultyAddresses { get; set; }

    public virtual DbSet<FacultyPhone> FacultyPhones { get; set; }

    public virtual DbSet<FacultyQualification> FacultyQualifications { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAddress> StudentAddresses { get; set; }

    public virtual DbSet<StudentCard> StudentCards { get; set; }

    public virtual DbSet<StudentOrder> StudentOrders { get; set; }

    public virtual DbSet<StudentPhone> StudentPhones { get; set; }

    public virtual DbSet<StudentQualification> StudentQualifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Nimap\\SQLEXPRESS;Initial Catalog=SqlPractice;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BatchStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__batch_st__3214EC273D3AC153");

            entity.ToTable("batch_students");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BatchId).HasColumnName("batchID");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Batch).WithMany(p => p.BatchStudents)
                .HasForeignKey(d => d.BatchId)
                .HasConstraintName("FK__batch_stu__batch__5FB337D6");

            entity.HasOne(d => d.Student).WithMany(p => p.BatchStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__batch_stu__stude__60A75C0F");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3214EC2703C0A134");

            entity.ToTable("course");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Summery)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("summery");
        });

        modelBuilder.Entity<CourseBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course_b__3214EC273AEEE2F3");

            entity.ToTable("course_batches");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.Endson).HasColumnName("endson");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Starton).HasColumnName("starton");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseBatches)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__course_ba__cours__5CD6CB2B");
        });

        modelBuilder.Entity<CourseModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course_m__3214EC27CAD7AC37");

            entity.ToTable("course_modules");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.ModuleId).HasColumnName("moduleID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseModules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__course_mo__cours__534D60F1");

            entity.HasOne(d => d.Module).WithMany(p => p.CourseModules)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__course_mo__modul__5441852A");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty__3214EC27AEE00C6F");

            entity.ToTable("faculty");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("emailID");
            entity.Property(e => e.Namefirst)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namefirst");
            entity.Property(e => e.Namelast)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namelast");
        });

        modelBuilder.Entity<FacultyAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty___3214EC276E69B6B3");

            entity.ToTable("faculty_address");

            entity.HasIndex(e => e.FacultyId, "UQ__faculty___DBBF6FD09A92D1CC").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");

            entity.HasOne(d => d.Faculty).WithOne(p => p.FacultyAddress)
                .HasForeignKey<FacultyAddress>(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__faculty_a__facul__4E88ABD4");
        });

        modelBuilder.Entity<FacultyPhone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty___3214EC270F550BE9");

            entity.ToTable("faculty_phone");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("number");

            entity.HasOne(d => d.Faculty).WithMany(p => p.FacultyPhones)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__faculty_p__facul__4AB81AF0");
        });

        modelBuilder.Entity<FacultyQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty___3214EC277254CDB1");

            entity.ToTable("faculty_qualifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.College)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("college");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.University)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("university");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Faculty).WithMany(p => p.FacultyQualifications)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__faculty_q__facul__59FA5E80");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__modules__3214EC27968C26B4");

            entity.ToTable("modules");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student__3214EC2772D1C919");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("emailID");
            entity.Property(e => e.Namefirst)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namefirst");
            entity.Property(e => e.Namelast)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namelast");
        });

        modelBuilder.Entity<StudentAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27014AC8EF");

            entity.ToTable("student_address");

            entity.HasIndex(e => e.StudentId, "UQ__student___4D11D65D17390ECE").IsUnique();

            entity.HasIndex(e => e.Address, "UQ__student___751C8E54B86F8BAE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithOne(p => p.StudentAddress)
                .HasForeignKey<StudentAddress>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_a__stude__45F365D3");
        });

        modelBuilder.Entity<StudentCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27E155FC3E");

            entity.ToTable("student_Cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCards)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_C__stude__412EB0B6");
        });

        modelBuilder.Entity<StudentOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27C343E54A");

            entity.ToTable("student_order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentOrders)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_o__stude__3B75D760");
        });

        modelBuilder.Entity<StudentPhone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27C37DEBE8");

            entity.ToTable("student_phone");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentPhones)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_p__stude__3E52440B");
        });

        modelBuilder.Entity<StudentQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27EB75C471");

            entity.ToTable("student_qualifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.College)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("college");
            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StudentId).HasColumnName("studentID");
            entity.Property(e => e.University)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("university");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentQualifications)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_q__stude__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
