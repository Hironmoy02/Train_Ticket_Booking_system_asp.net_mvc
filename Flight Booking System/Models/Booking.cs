using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rail_Booking_System.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "From Required")]
        [Display(Name = "From")]

        [ForeignKey("UserLogin")]
        public  int UserID { get; set; }
        public string From { get; set; }


        [Required(ErrorMessage = "To Required")]
        [Display(Name = "To")]
        public string To { get; set; }

        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
        public int NumberOfPassengers { get; set; }

        [ForeignKey("Rail")]
        public int RailId { get; set; }
        
        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public Rail Rail { get; set; }
        public UserLogin UserLogin { get; set; }
        public Schedule Schedule { get; set; }



    }
}