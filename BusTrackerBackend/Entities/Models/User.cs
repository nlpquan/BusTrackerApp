using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation properties
        public ICollection<CustomerBooking>? CustomerBookings { get; set; }
        public ICollection<DriverTicket>? DriverTickets { get; set; }
    }

}
