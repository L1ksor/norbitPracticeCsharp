using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinallyTask.Models;

public partial class WorktimeDbContext : DbContext
{
    public WorktimeDbContext()
    {
    }

    public WorktimeDbContext(DbContextOptions<WorktimeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Worklog> Worklogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.1.197;Port=5432;Database=worktime_db;Username=postgres;Password=200620;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("project_pkey");

            entity.ToTable("project");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_pkey");

            entity.ToTable("task");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CodeProject)
                .HasMaxLength(100)
                .HasColumnName("code_project");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");

            entity.HasOne(d => d.CodeProjectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CodeProject)
                .HasConstraintName("task_project_fk");
        });

        modelBuilder.Entity<Worklog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("worklog_pkey");

            entity.ToTable("worklog");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Hours)
                .HasPrecision(4, 2)
                .HasColumnName("hours");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.WorkDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("work_date");

            entity.HasOne(d => d.Task).WithMany(p => p.Worklogs)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("worklog_task_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
