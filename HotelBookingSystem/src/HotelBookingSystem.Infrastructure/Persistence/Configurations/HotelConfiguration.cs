using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations;
public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotels");
        builder.HasKey(h => h.HotelId);

        builder.Property(h => h.HotelName).IsRequired().HasMaxLength(100);

        builder.Property(h => h.Location).IsRequired().HasMaxLength(200);

        builder.Property(h => h.PhoneNumber).IsRequired().HasMaxLength(15);

        builder.Property(h => h.Description).IsRequired(false).HasMaxLength(500);

        builder.Property(h => h.TotalRooms).IsRequired();

        builder.Property(h => h.StarRating).IsRequired().HasAnnotation("Range", "0,5");

        builder.HasMany(h => h.Rooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId);

        builder.HasMany(h => h.Services)
            .WithOne(s => s.Hotel)
            .HasForeignKey(s => s.HotelId);

        builder.HasMany(h => h.Reviews)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId);

        builder.HasMany(h => h.Roles)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId);

        builder.HasMany(h => h.Complaints)
            .WithOne(c => c.Hotel)
            .HasForeignKey(c => c.HotelId);
    }
}

