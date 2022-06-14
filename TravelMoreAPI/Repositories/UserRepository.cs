using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;

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

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}

