using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TrackingHistory
    {
        [Column("TrackingId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Bus))]
        public Guid BusId { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }
        public Bus? Buses { get; set; }
    }
}
