using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Bus
    {
        [Column("BusId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Plate number is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the PlateNumber is 60 characters.")]
        public string? PlateNumber { get; set; }

        [Required(ErrorMessage = "Model is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Model is 60 characters.")]
        public string? Model { get; set; }

        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BusRoute>? Routes { get; set; }
        public BusLocation? Location { get; set; }
    }
}
