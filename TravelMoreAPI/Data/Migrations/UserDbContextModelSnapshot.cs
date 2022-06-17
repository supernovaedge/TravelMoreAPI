﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelMoreAPI.Data;

#nullable disable

namespace TravelMoreAPI.Data.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelMoreAPI.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StayFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StayTo")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("TravelMoreAPI.Entities.Guest", b =>
                {
                    b.Property<Guid>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HostFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HostTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GuestId");

                    b.HasIndex("UserId");

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("TravelMoreAPI.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.HasIndex("Email", "UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("73d73af1-053e-4562-ba24-84bfd2148af1"),
                            Email = "n_gurchiani@cu.edu.ge",
                            FirstName = "Nicolas",
                            LastName = "Gurchiani",
                            PasswordHash = new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 },
                            PasswordSalt = new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 },
                            UserName = "vbaar"
                        },
                        new
                        {
                            UserId = new Guid("27b6885d-55a5-4e30-8acf-08b9c94681fb"),
                            Email = "test@user.co",
                            FirstName = "Test",
                            LastName = "User",
                            PasswordHash = new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 },
                            PasswordSalt = new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 },
                            UserName = "testuser"
                        },
                        new
                        {
                            UserId = new Guid("f000d5fa-8d40-4dc6-926d-490ee97e59ff"),
                            Email = "tuga@in.pl",
                            FirstName = "Alex",
                            LastName = "Salvado",
                            PasswordHash = new byte[] { 235, 35, 132, 76, 45, 217, 38, 64, 185, 254, 50, 60, 219, 138, 180, 254, 9, 73, 251, 118, 49, 210, 187, 48, 151, 164, 197, 12, 150, 246, 61, 120, 146, 152, 64, 17, 69, 48, 11, 180, 221, 161, 203, 128, 206, 110, 220, 189, 218, 78, 105, 125, 187, 177, 101, 51, 174, 182, 237, 10, 40, 61, 250, 150 },
                            PasswordSalt = new byte[] { 223, 72, 245, 22, 70, 21, 4, 137, 155, 23, 236, 183, 121, 193, 120, 78, 101, 88, 217, 189, 230, 216, 245, 88, 23, 123, 121, 244, 142, 169, 177, 17, 89, 99, 81, 157, 192, 249, 178, 230, 45, 75, 17, 36, 212, 179, 208, 67, 155, 7, 41, 103, 75, 38, 99, 203, 92, 8, 50, 247, 229, 147, 126, 146, 119, 160, 5, 127, 35, 184, 199, 174, 40, 203, 146, 102, 194, 159, 171, 238, 154, 168, 59, 231, 158, 188, 74, 228, 109, 109, 239, 153, 206, 191, 248, 145, 246, 49, 104, 23, 67, 195, 33, 107, 163, 99, 47, 156, 155, 169, 41, 48, 37, 99, 117, 41, 241, 90, 207, 145, 221, 44, 91, 136, 137, 167, 213, 29 },
                            UserName = "tuga"
                        });
                });

            modelBuilder.Entity("TravelMoreAPI.Entities.Booking", b =>
                {
                    b.HasOne("TravelMoreAPI.Entities.User", null)
                        .WithMany("Booking")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelMoreAPI.Entities.Guest", b =>
                {
                    b.HasOne("TravelMoreAPI.Entities.User", null)
                        .WithMany("Guest")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelMoreAPI.Entities.User", b =>
                {
                    b.OwnsOne("TravelMoreAPI.Entities.Apartment", "Apartment", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("ApartmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("BedsNumber")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("DistanceToCenter")
                                .HasColumnType("int");

                            b1.Property<string>("ImageBase64")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Apartments");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("208faa1b-22a9-48c5-8a64-3f6153d8eb2c"),
                                    Address = "panaskerteli 7",
                                    ApartmentId = new Guid("94afc61e-6ea9-4331-8ce7-f6cb16be7792"),
                                    BedsNumber = 3,
                                    City = "Tbilisi",
                                    DistanceToCenter = 2
                                });
                        });

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("TravelMoreAPI.Entities.User", b =>
                {
                    b.Navigation("Booking");

                    b.Navigation("Guest");
                });
#pragma warning restore 612, 618
        }
    }
}
