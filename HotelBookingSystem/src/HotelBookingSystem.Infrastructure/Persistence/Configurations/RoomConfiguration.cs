using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations;
public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(r => r.RoomId);

        builder.Property(r => r.RoomNumber).IsRequired().HasMaxLength(10);
        builder.HasIndex(r => r.RoomNumber).IsUnique();

        builder.Property(r => r.RoomType).IsRequired().HasMaxLength(10);

        builder.Property(r => r.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(r => r.IsAvailable).IsRequired();

        builder.HasOne(r => r.Hotel)
            .WithMany(h => h.Rooms)
            .HasForeignKey(r => r.HotelId);

        builder.HasMany(r => r.BookingRooms)
       .WithOne(br => br.Room)
       .HasForeignKey(br => br.RoomId);
    }
}
