using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rail_Booking_System.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        
        public string From { get; set; }
        public string To { get; set; }

        [Display(Name = "Rail Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RailDate { get; set; }
        public string ArrivalTime { get; set;}
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "Price Required")]
        [Display(Name = "Price")]
        public float Price { get; set; }
        public Rail Rail { get; set; }
       
        [ForeignKey("Rail")]
        public int RailId { get; set; }
        public Train Train { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        
    }
}