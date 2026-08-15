using Microsoft.EntityFrameworkCore;

namespace DatabaseCRUDTask5.Models
{
    public class AirlinesDbContext : DbContext
    {
        private readonly string _connectionString;

        public AirlinesDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Company> Companies { get; set; } = null;
        public DbSet<Passenger> Passengers { get; set; } = null;
        public DbSet<Trip> Trips { get; set; } = null;
        public DbSet<PassInTrip> PassInTrips { get; set; } = null;
        public DbSet<Plane> Planes { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Passenger>().ToTable("Passenger");
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<PassInTrip>().ToTable("PassInTrip");
            modelBuilder.Entity<Plane>().ToTable("Plane");

        }
    }
}
