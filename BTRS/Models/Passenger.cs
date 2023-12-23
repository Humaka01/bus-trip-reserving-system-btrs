using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Models
{
    public enum Gender
    {
        Male,
        Female
        
    }


    public class Passenger
    {

        [Key]
        public int PassengerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = " Username Should Be insert")]
        [StringLength(50)]
        public string username { get; set; }
        [Required(ErrorMessage = "Phone Number Be insert")]
        [StringLength(50)]
        public string phonenumber { get; set; }
        [Required(ErrorMessage = "Password Should Be insert")]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Passenger_Trips> passenger_trips { set; get; }
    }
}
