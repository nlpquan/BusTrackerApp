using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusConfiguration());
            modelBuilder.ApplyConfiguration(new BusStopConfiguration());
            modelBuilder.ApplyConfiguration(new BusRouteConfiguration());
            modelBuilder.ApplyConfiguration(new BusScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new BusLocationConfiguration());
        }
        public DbSet<Bus>? Buses { get; set; }
        public DbSet<BusRoute>? BusRoutes { get; set; }
        public DbSet<BusSchedule>? BusSchedules { get; set; }
        public DbSet<BusStop>? BusStops { get; set; }
        public DbSet<BusLocation>? BusLocations { get; set; }

    }
}
