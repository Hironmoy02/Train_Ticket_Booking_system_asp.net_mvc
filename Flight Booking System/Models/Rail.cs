using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rail_Booking_System.Models
{
    [Table("Rails")]
    public class Rail
    {
        [Key]

        public int RailId { get; set; }

        [ForeignKey("Train")]

        public int TrainId { get; set; }

        [ForeignKey("Station")]
        public int StationId { get; set; }

        [Required]

        public string From { get; set; }

        [Required]

        public string To { get; set; }
        public string FromCode { get; set; }
        public string ToCode { get; set; }

        [Required]
        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; }

        [Required]
        [Display(Name = "Departure Time")]
        public string DepartureTime { get; set; }
        //[Display(Name = "Rail Date")]
        //[DataType(DataType.Date)]
        //public DateTime RailDate { get; set; }
        [Required]
        public int TotalSeatsCapacity { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public Train Train { get; set; }   
        public Station Station { get; set; }
    }
}