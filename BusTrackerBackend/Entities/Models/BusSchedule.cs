using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BusSchedule
    {
        [Column("ScheduleId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Bus))]
        public Guid BusId { get; set; }

        [ForeignKey(nameof(BusRoute))]
        public Guid RouteId { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public Bus? Bus { get; set; }
        public BusRoute? Route { get; set; }
    }
}
