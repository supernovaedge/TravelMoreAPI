using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TravelMoreAPI.Entities;

public class ApartmentEntityConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.HasKey(u => u.ApartmentId);

        builder.Property(u => u.City)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Address)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.DistanceToCenter)
            .IsRequired();

        builder.Property(u => u.BedsNumber)
            .IsRequired();

        //builder.Property(u => u.ImageBase64)
           // .IsRequired();

    }
}