using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BusStop
    {
        [Column("BusStopId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public ICollection<RouteStop>? RouteStops { get; set; }
    }
}
