
using BTRS.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballGame.Date
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Passenger> passenger { set; get; }
        public DbSet<Trip> trip { set; get; }
        public DbSet<Admin> admin { set; get; }

        public DbSet<Booking> booking { set; get; }
        public DbSet<Bus> bus { set; get; }
        public DbSet<Passenger_Trips> passenger_trips { set; get; }
     



    }
}
