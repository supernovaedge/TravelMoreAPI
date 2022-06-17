using Microsoft.EntityFrameworkCore;
using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        private void SeedUser(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Nicolas",
                    LastName = "Gurchiani",
                    UserName = "vbaar",
                    Email = "n_gurchiani@cu.edu.ge",
                    PasswordHash = Convert.FromBase64String("6yOETC3ZJkC5/jI824q0/glJ+3Yx0rswl6TFDJb2PXiSmEARRTALtN2hy4DObty92k5pfbuxZTOutu0KKD36lg=="),
                    PasswordSalt = Convert.FromBase64String("30j1FkYVBImbF+y3ecF4TmVY2b3m2PVYF3t59I6psRFZY1GdwPmy5i1LESTUs9BDmwcpZ0smY8tcCDL35ZN+knegBX8juMeuKMuSZsKfq+6aqDvnnrxK5G1t75nOv/iR9jFoF0PDIWujYy+cm6kpMCVjdSnxWs+R3SxbiImn1R0="),
                    ApartmentId = Guid.NewGuid(),
                });
                b.OwnsOne(e => e.Apartment).HasData(new
                {
                                ApartmentId = Guid.NewGuid(),
                                City = "Tbilisi",
                                Address = "panaskerteli 7",
                                DistanceToCenter = 2,
                                BedsNumber = 3,
                });
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.Entity<User>()
               .HasIndex(u => new { u.Email, u.UserName})
               .IsUnique();


            modelBuilder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    //UserId = Guid.NewGuid(),
                    FirstName = "Nicolas",
                    LastName = "Gurchiani",
                    UserName = "vbaar",
                    Email = "n_gurchiani@cu.edu.ge",
                    PasswordHash = Convert.FromBase64String("6yOETC3ZJkC5/jI824q0/glJ+3Yx0rswl6TFDJb2PXiSmEARRTALtN2hy4DObty92k5pfbuxZTOutu0KKD36lg=="),
                    PasswordSalt = Convert.FromBase64String("30j1FkYVBImbF+y3ecF4TmVY2b3m2PVYF3t59I6psRFZY1GdwPmy5i1LESTUs9BDmwcpZ0smY8tcCDL35ZN+knegBX8juMeuKMuSZsKfq+6aqDvnnrxK5G1t75nOv/iR9jFoF0PDIWujYy+cm6kpMCVjdSnxWs+R3SxbiImn1R0="),
                    //ApartmentId = Guid.NewGuid(),
                });
                b.OwnsOne(e => e.Apartment).HasData(new
                {
                    UserId = Guid.NewGuid(),
                    ApartmentId = Guid.NewGuid(),
                    City = "Tbilisi",
                    Address = "panaskerteli 7",
                    DistanceToCenter = 2,
                    BedsNumber = 3,
                });
            });

            modelBuilder.Entity<User>().HasData(

            new User
            {

                UserId = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                UserName = "testuser",
                Email = "test@user.co",
                PasswordHash = Convert.FromBase64String("6yOETC3ZJkC5/jI824q0/glJ+3Yx0rswl6TFDJb2PXiSmEARRTALtN2hy4DObty92k5pfbuxZTOutu0KKD36lg=="),
                PasswordSalt = Convert.FromBase64String("30j1FkYVBImbF+y3ecF4TmVY2b3m2PVYF3t59I6psRFZY1GdwPmy5i1LESTUs9BDmwcpZ0smY8tcCDL35ZN+knegBX8juMeuKMuSZsKfq+6aqDvnnrxK5G1t75nOv/iR9jFoF0PDIWujYy+cm6kpMCVjdSnxWs+R3SxbiImn1R0="),
                ApartmentId = null,
                Apartment = null,
                Guest = null,
                Booking = null

            },

            new User
            {

                UserId = Guid.NewGuid(),
                FirstName = "Alex",
                LastName = "Salvado",
                UserName = "tuga",
                Email = "tuga@in.pl",
                PasswordHash = Convert.FromBase64String("6yOETC3ZJkC5/jI824q0/glJ+3Yx0rswl6TFDJb2PXiSmEARRTALtN2hy4DObty92k5pfbuxZTOutu0KKD36lg=="),
                PasswordSalt = Convert.FromBase64String("30j1FkYVBImbF+y3ecF4TmVY2b3m2PVYF3t59I6psRFZY1GdwPmy5i1LESTUs9BDmwcpZ0smY8tcCDL35ZN+knegBX8juMeuKMuSZsKfq+6aqDvnnrxK5G1t75nOv/iR9jFoF0PDIWujYy+cm6kpMCVjdSnxWs+R3SxbiImn1R0="),
                ApartmentId = null,
                Apartment = null,
                Guest = null,
                Booking = null

            }
             );
        }
            
    }
 }

