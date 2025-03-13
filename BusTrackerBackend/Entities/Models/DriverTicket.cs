using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DriverTicket
    {
        [Column("DriverTicketId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(CustomerBooking))]
        public Guid? CustomerBookingId { get; set; } // Link to CustomerBooking
        public CustomerBooking? CustomerBooking { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? AdminId { get; set; } // Admin who created the ticket
        public User? Admin { get; set; } // Admin who manages the ticket

        [ForeignKey(nameof(User))]
        public Guid? DriverId { get; set; } // Driver assigned to this ticket
        public User? Driver { get; set; } // Driver who views and updates the status

        [ForeignKey(nameof(Bus))]
        public Guid? BusId { get; set; }  // Bus assigned to the journey
        public string? BusRoute { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        // Status of the ticket
        public string? Status { get; set; } // "Pending", "Assigned", "Approved", "Completed"

        // Tracking the completion time of the journey
        public DateTime? CompletedAt { get; set; }
        public Bus? Bus { get; set; }
    }

}
