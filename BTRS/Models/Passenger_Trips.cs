using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Passenger_Trips
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("PassengerID")]
        public Passenger passenger { get; set; }

        [ForeignKey("TripID")]
        public Trip trip { get; set; }  
    }
}
