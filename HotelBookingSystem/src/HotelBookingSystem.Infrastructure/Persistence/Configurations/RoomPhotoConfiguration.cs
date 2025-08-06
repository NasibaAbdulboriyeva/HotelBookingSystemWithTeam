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
    public class RoomPhotoConfiguration : IEntityTypeConfiguration<RoomPhoto>
    {
        public void Configure(EntityTypeBuilder<RoomPhoto> builder)
        {
            builder.ToTable("RoomPhotos");

            builder.HasKey(roomPhoto => roomPhoto.RoomPhotoId);

            builder.Property(roomPhoto => roomPhoto.RoomPhotoId).ValueGeneratedOnAdd();

            builder.HasIndex(roomPhoto => roomPhoto.PhotoName).IsUnique();
     

            builder.HasOne(roomPhoto => roomPhoto.Room)
                .WithMany(room => room.RoomPhotos)
                .HasForeignKey(roomPhoto => roomPhoto.RoomId)
                .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
