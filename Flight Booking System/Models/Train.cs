using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rail_Booking_System.Models
{
    [Table("Train")]
    public class Train
    {
        [Key]
        public int TrainId { get; set; }

        [Display(Name ="Train Name")]
        [Required(ErrorMessage ="Train Name Required.")]
        [MaxLength(30, ErrorMessage ="Maximum 30 characters"),MinLength(3, ErrorMessage ="Minimum 3 characters allowed")]
        public string TrainName { get; set; }

        [Required(ErrorMessage ="Capacity Required")]
        [Display(Name ="Seating Capacity")]
        public int SeatingCapacity { get; set; }
        public ICollection<Rail> Rails { get; set; }
        

    }
}