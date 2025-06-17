using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations;
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(p => p.PaymentId);

        builder.Property(p => p.PaidAmount).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(p => p.Status).IsRequired();

        builder.Property(p => p.PaymentMethod).IsRequired();

        builder.Property(p => p.PaidAt).IsRequired().HasColumnType("datetime");

        builder.HasOne(p => p.Booking)
          .WithOne(b => b.Payment)
          .HasForeignKey<Payment>(p => p.BookingId);
    }
}

