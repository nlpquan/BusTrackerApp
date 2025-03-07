using Entities.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bus>? Buses { get; set; }
        public DbSet<Route>? Routes { get; set; }
        public DbSet<TrackingHistory>? TrackingHistories { get; set; }
        public DbSet<BusStop>? BusStops { get; set; }
        public DbSet<RouteStop>? RouteStops { get; set; }

    }
}
