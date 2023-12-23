using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        [ForeignKey("Passenger")]
        public int PassengerID { get; set; }
        
        public ICollection<Passenger> Passenger { get; set; }
    }
}
