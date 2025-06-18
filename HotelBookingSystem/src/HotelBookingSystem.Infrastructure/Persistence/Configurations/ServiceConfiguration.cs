using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.ServiceId);

            builder.Property(s => s.ServiceName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Description)
                .IsRequired(false);

            builder.Property(s => s.IsAvailable)
                .IsRequired();

            builder.HasOne(s => s.Hotel)
                .WithMany(h => h.Services)
                .HasForeignKey(s => s.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
