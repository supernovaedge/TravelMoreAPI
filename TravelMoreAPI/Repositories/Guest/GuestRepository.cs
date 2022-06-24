using Microsoft.EntityFrameworkCore;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly UserDbContext _context;

        public GuestRepository(UserDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Guest> GetGuests()
        {
            return _context.Guests;
        }

        public void AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);

            _context.SaveChanges();
        }

        public List<Guest>? GetGuestsById(Guid id)
        {
            var user = _context.Users.Include(u => u.Guest).FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            var guests = user.Guest;
            if (guests == null)
            {
                throw new Exception("user has no guests");
            }
            return guests;

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
