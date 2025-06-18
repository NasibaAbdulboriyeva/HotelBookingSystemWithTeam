using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations;
public class EmployeeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.RoleId);

        builder.Property(r => r.RoleName).IsRequired().HasMaxLength(100);

        builder.Property(r => r.Description).IsRequired(false).HasMaxLength(500);

        builder.Property(r => r.IsActive).IsRequired().HasDefaultValue(true);

        builder.HasOne(r => r.Hotel)
            .WithMany(h => h.Roles)
            .HasForeignKey(r => r.HotelId);
    }
}
