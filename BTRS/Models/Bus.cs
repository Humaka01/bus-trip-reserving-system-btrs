using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Bus
    {
        [Key]
        public int BusID { get; set; }
        [Required]
        public string CaptainName { get; set; }
        [Required]
        public int NumOfSeats { get; set; }

        [ForeignKey("TripID")]
        public Trip trip { get; set; }
      
        
    }
}
