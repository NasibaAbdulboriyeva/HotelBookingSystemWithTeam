using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace HotelBookingSystem.Infrastructure.Persistence.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");

            builder.HasKey(c => c.CardId);

            builder.Property(c => c.CardNumberMasked)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.CardHolderName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.ExpiryMonth)
                .IsRequired();

            builder.Property(c => c.ExpiryYear)
                .IsRequired();

            builder.Property(c => c.CVV)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(c => c.SelectedForPayment)
                .IsRequired()
                .HasDefaultValue(false);


            builder.Property(c => c.Type)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(u => u.Cards)
                .HasForeignKey(c => c.UserId);
            
        }

    }
}