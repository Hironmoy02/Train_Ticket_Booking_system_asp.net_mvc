using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Rail_Booking_System.Models
{
    [Table ("UserLogin")]
    public class UserLogin
    {
        [Key]
        [Required]public int UserID { get; set; }

        [Required(ErrorMessage ="First Name Required")]
        [Display(Name = "First Name")]
        [MaxLength(40, ErrorMessage ="Max 40 characters allowed"), MinLength(3, ErrorMessage ="Minimum 3 characters required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Requird")]
        [Display(Name = "Last Name")]
        [MaxLength(40, ErrorMessage = "Max 40 characters allowed"), MinLength(3, ErrorMessage = "Minimum 3 characters required.")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage ="Email ID required.")]
        [MaxLength(20, ErrorMessage ="Maximum 20 characters allowed"),MinLength(3, ErrorMessage ="Minimum 3 characters required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Role { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "6 Minimum  characters required."), MaxLength(16, ErrorMessage = "Maximum 16 characters allowed.")]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [DataType (DataType.Password)]
        [Compare("Password",ErrorMessage ="Incorrect Password")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required."), MaxLength(16, ErrorMessage = "Maximum 16 characters allowed.")]
        public string ConfirmPassword { get; set; }

      

        [Required(ErrorMessage ="Age Required.")]
        [Range(18, 120,ErrorMessage ="Minimum 18 years to book the rail.")]
        public int Age { get; set; }

        [Display(Name ="Phone Number")]
        [Required(ErrorMessage ="Phone Number Required")]

        public string PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Payment> Payments { get; set; }



    }
}