using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rail_Booking_System.Models
{
    [Table("Station")]
    public class Station
    {
        [Key]
        public int StationId { get; set; }

        [Required, MaxLength(30)]
        public string StationName { get; set; }

        [Required, MaxLength(30)]
        public string City { get; set; }

        [Required, MaxLength(30)]

        public string Country { get; set; }
        public ICollection<Rail> Rails { get; set; }
    }
}