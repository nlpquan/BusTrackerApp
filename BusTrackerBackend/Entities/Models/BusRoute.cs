using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BusRoute
    {
        [Column("RouteId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "StartPoint is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the StartPoint is 60 characters.")]
        public string? StartPoint { get; set; }

        [Required(ErrorMessage = "EndPoint is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the EndPoint is 60 characters.")]
        public string? EndPoint { get; set; }

        public ICollection<BusStop>? Stops { get; set; }
    }
}
