using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BusLocation
    {
        [Column("LocationId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Bus))]
        public Guid BusId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public Bus? Bus { get; set; }
    }
}
