using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelMoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
            
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.Include(u => u.UserPicture).Include(u => u.Apartment).FirstOrDefault(x => x.UserId == id);
        }

        public Profile? GetUserProfileById(Guid id)
        {
            var user = _context.Users.Include(x => x.UserPicture).FirstOrDefault(x => x.UserId == id);
            if (user == null) throw new Exception("User not found");

            var userProfile = new Profile();
            userProfile.ApartmentId = user.ApartmentId;
            userProfile.UserName =  user.UserName;
            userProfile.Email = user.Email;
            userProfile.UserPicture = user.UserPicture;

            return userProfile;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Apartment).Include(u => u.Booking).Include(u => u.Guest);
        }


        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User? GetUserByUsername(string userName)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public User? GetUserByApartmentID(Guid apartmentID)
        {
            return _context.Users.FirstOrDefault(x => x.ApartmentId == apartmentID);
        }

        public void DeleteGuest(Guest guestToRemove)
        {
            _context.Guests.Remove(guestToRemove);
        }
    }
}

