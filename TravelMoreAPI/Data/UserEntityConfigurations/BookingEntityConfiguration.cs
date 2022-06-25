using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TravelMoreAPI.Entities;

public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(u => u.ApartmentId);

        builder.Property(u => u.City)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.StayFrom)
            .IsRequired();
        
        builder.Property(u => u.StayTo)
            .IsRequired();

        builder.Property(u => u.UserId)
            .IsRequired();
    }
}