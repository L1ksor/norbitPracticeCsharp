using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCRUDTask5.Models;

public partial class AirlinesDbContext : DbContext
{
    public AirlinesDbContext()
    {
    }

    public AirlinesDbContext(DbContextOptions<AirlinesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<PassInTrip> PassInTrips { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AirlinesDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC07AD2076A7");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<PassInTrip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pass_in___3214EC074BCC1BFB");

            entity.ToTable("Pass_in_trip");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Place).HasMaxLength(10);

            entity.HasOne(d => d.Passenger).WithMany(p => p.PassInTrips)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PassInTrip_Passenger");

            entity.HasOne(d => d.Trip).WithMany(p => p.PassInTrips)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PassInTrip_Trip");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Passenge__3214EC07926A719B");

            entity.ToTable("Passenger");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trip__3214EC074ADE7B76");

            entity.ToTable("Trip");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Plane).HasMaxLength(50);
            entity.Property(e => e.TownFrom).HasMaxLength(100);
            entity.Property(e => e.TownTo).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip_Company");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
