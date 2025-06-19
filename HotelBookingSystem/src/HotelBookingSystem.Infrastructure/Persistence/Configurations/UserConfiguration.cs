using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);


        builder.Property(u => u.Email).IsRequired().HasMaxLength(320);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);

        builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);

        builder.HasMany(c => c.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

        builder.HasMany(b => b.Bookings)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId);

        builder.HasMany(c => c.Cards)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

        builder.HasMany(c => c.Complaints)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId);
    }
}
