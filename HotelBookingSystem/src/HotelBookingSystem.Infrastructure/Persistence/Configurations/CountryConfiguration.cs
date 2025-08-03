using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.CountryId);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.PhoneCode)
                .HasMaxLength(10);

            builder.Property(c => c.Currency)
                .HasMaxLength(10);

            builder.Property(c => c.IsActive)
                .IsRequired();

            builder.HasMany(c => c.Cities)
                .WithOne(city => city.Country)
                .HasForeignKey(city => city.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
