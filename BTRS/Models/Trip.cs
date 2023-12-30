using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Models
{
    [Index(nameof(BusNumber), IsUnique = true)]
    public class Trip
    {
        [Key]
       
        public int TripID { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int BusNumber { get; set; }

        [ForeignKey("AdminID")]
        public Admin Admin { get; set; }


        public int? SelectedSeats { get; set; }

        // Navigation properties
        public ICollection<Bus> Buses { get; set; }
        public ICollection<Passenger_Trips> PassengerTrips { get; set; }
    }
}
