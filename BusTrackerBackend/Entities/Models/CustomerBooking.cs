using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entities.Models
{
    public class CustomerBooking
    {
        [Column("CustomerBookingId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? CustomerId { get; set; }  // Foreign key to the User (Customer)
        public User? Customer { get; set; }

        public int Capacity { get; set; }
        public string? Destination { get; set; }
        public DateTime BookingDate { get; set; }
        public string? Status { get; set; }  // "Pending", "Approved", "Completed"
        public string? CustomerMessage { get; set; } // Message to notify customer
        public ICollection<DriverTicket>? DriverTickets { get; set; }
    }

}
