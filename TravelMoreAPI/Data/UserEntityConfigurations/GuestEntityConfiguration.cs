using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TravelMoreAPI.Entities;

public class GuestEntityConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(u => u.GuestId);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.HostFrom)
            .IsRequired();
        
        builder.Property(u => u.HostTo)
            .IsRequired();

        builder.Property(u => u.UserId)
            .IsRequired();
    }
}