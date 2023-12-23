using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BTRS.Models
{
    [Index(nameof(Admin.username), IsUnique = true)]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string AdminFullName { get; set; }
        [Required]

        public string username { set; get; }
        [Required]
        public string password { set; get; }

        public ICollection<Trip> Trips { get; set; }
    }
}
