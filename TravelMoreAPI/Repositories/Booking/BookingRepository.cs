using Microsoft.EntityFrameworkCore;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly UserDbContext _context;

        public BookingRepository(UserDbContext context)
        {
            _context = context;
        }


        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
        }

        public IEnumerable<Booking> GetApartments()
        {
            return _context.Bookings;
        }

        public List<Booking>? GetBookingsById(Guid id)
        {
            var user = _context.Users.Include(u => u.Booking).FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            var bookings = user.Booking;
            if (bookings == null)
            {
                throw new Exception("user has no guests");
            }
            return bookings;

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public Booking GuestToBooking(Guest guest)
        {
            var booking = new Booking()
            {
            
            };
            return booking;
        }
    }
}
