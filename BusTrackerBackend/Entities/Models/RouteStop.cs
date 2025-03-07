using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RouteStop
    {
        [Column("RouteStopId")]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Route))]
        public Guid RouteId { get; set; }

        [ForeignKey(nameof(BusStop))]
        public Guid BusStopId { get; set; }
        public int BusStopOrder { get; set; }
        public Route? Routes { get; set; }
        public BusStop? BusStops { get; set; }
    }
}
