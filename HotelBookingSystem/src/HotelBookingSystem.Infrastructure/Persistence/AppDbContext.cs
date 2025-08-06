using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<RoomPhoto> RoomPhotos { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }


    }
}
