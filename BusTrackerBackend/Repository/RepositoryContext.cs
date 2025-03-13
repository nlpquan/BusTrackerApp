using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply the custom configurations for your entities
            modelBuilder.ApplyConfiguration(new BusConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerBookingConfiguration());
            modelBuilder.ApplyConfiguration(new DriverTicketConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // Explicitly configure relationships
            modelBuilder.Entity<DriverTicket>()
                .HasOne(dt => dt.Admin)  // DriverTicket has one Admin
                .WithMany()  // Admin does not have a collection of DriverTickets (One-to-Many)
                .HasForeignKey(dt => dt.AdminId)  // Foreign key in DriverTicket table
                .OnDelete(DeleteBehavior.Restrict);  // You can choose the delete behavior

            modelBuilder.Entity<DriverTicket>()
                .HasOne(dt => dt.Driver)  // DriverTicket has one Driver
                .WithMany()  // Driver does not have a collection of DriverTickets (One-to-Many)
                .HasForeignKey(dt => dt.DriverId)  // Foreign key in DriverTicket table
                .OnDelete(DeleteBehavior.Restrict);  // You can choose the delete behavior

            modelBuilder.Entity<DriverTicket>()
                .HasOne(dt => dt.CustomerBooking)  // DriverTicket has one CustomerBooking
                .WithMany(cb => cb.DriverTickets)  // CustomerBooking has many DriverTickets
                .HasForeignKey(dt => dt.CustomerBookingId)  // Foreign key in DriverTicket table
                .OnDelete(DeleteBehavior.Cascade);  // If CustomerBooking is deleted, the associated DriverTicket should be deleted

            modelBuilder.Entity<DriverTicket>()
                .HasOne(dt => dt.Bus)  // DriverTicket has one Bus
                .WithMany()  // Bus does not have a collection of DriverTickets (One-to-Many)
                .HasForeignKey(dt => dt.BusId)  // Foreign key in DriverTicket table
                .OnDelete(DeleteBehavior.Restrict);  // You can choose the delete behavior
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<CustomerBooking> CustomerBookings { get; set; }
        public DbSet<DriverTicket> DriverTickets { get; set; }
    }

}
