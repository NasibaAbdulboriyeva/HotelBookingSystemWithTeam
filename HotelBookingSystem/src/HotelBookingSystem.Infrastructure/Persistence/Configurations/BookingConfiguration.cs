using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations;
public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => b.BookingId);

        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();

        builder.Property(b => b.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(b => b.Status).IsRequired();

        builder.Property(b => b.IsActive).IsRequired().HasDefaultValue(true);

        builder.HasOne(b => b.Payment)
            .WithOne(p => p.Booking)
            .HasForeignKey<Payment>(p => p.BookingId);
    

        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);


        builder.HasMany(r => r.BookingRooms)
           .WithOne(br => br.Booking)
           .HasForeignKey(br => br.BookingId);
    }
}
