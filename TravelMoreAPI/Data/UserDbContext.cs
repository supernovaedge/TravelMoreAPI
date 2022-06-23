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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GuestEntityConfiguration());

            modelBuilder.Entity<User>()
               .HasIndex(u => new { u.Email, u.UserName})
               .IsUnique();

        }
        

    }
 }

