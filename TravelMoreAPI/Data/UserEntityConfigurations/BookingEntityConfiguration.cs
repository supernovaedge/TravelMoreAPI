using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelMoreAPI.Entities;

public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(u => u.BookingId);

        builder.Property(u => u.City)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.HostFrom)
            .IsRequired();
        
        builder.Property(u => u.HostTo)
            .IsRequired();
        
        builder.Property(u => u.GuestId)
            .IsRequired();
        
        builder.Property(u => u.ApartmentId)
            .IsRequired();

    }
}