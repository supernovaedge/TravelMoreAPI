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
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Apartment);
        }

        public bool EmailValidation(string email)
        {
            var user = _context.Users.FirstOrDefault(m => m.Email == email);
            if (email == null)
            {
                return false;
            }
            return true;
        }

        public bool UsernameValidation(string username)
        {
            if (_context.Users.FirstOrDefault(x => x.Email == username) == null)
            {
                return false;
            }
            return true;
        }
    }
}

