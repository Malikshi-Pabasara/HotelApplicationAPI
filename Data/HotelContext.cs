using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) //pass options
        { 
        }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<PropertyInfo> Properties { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        
    }
}
