using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations
{
    public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.HasKey(c => c.ComplaintId);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.User)
                .WithMany(u => u.Complaints)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Hotel)
                .WithMany(h => h.Complaints)
                .HasForeignKey(c => c.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Booking)
                .WithMany(b => b.Complaints)
                .HasForeignKey(c => c.BookingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
