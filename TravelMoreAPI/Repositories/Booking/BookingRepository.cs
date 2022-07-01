using Microsoft.EntityFrameworkCore;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;


namespace TravelMoreAPI.Repositories.BookingT
{
    public class BookingRepository : IBookingRepository
    {
        private readonly UserDbContext _context;

        public BookingRepository(UserDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings;
        }
        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public Booking? GetBookingById(Guid id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.BookingId == id);
            return booking;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<BookingProfile> GetBookingProfile(Guid id)
        {
            var list = 
                from booking in _context.Bookings
                where booking.GuestId == id
                select booking;
            var bookingProfile = new List<BookingProfile>();
            
            foreach (Booking booking in list)
            {
                var profile = ConvertBookingProfile(booking);
                bookingProfile.Add(profile);
            }
            
            return bookingProfile;
        }


        public void DeleteBooking(Booking booking)
        {
            _context.Remove(booking);
            _context.SaveChanges();
        }

        List<GuestProfile> IBookingRepository.GetGuestProfile(Guid id)
        {
            var list =
                from booking in _context.Bookings
                    .Include(x=> x.GuestPicture)
                where booking.HostId == id
                select booking;
            var guestProfile = new List<GuestProfile>();

            foreach (Booking booking in list)
            {
                var profile = ConvertGuestProfile(booking);
                guestProfile.Add(profile);
            }

            return guestProfile;
        }

        public BookingProfile ConvertBookingProfile(Booking booking)
        {
            var profile = new BookingProfile()
            {
                stayFrom = booking.HostFrom,
                stayTo = booking.HostTo,
                BookingId = booking.BookingId,
                ApartmentId = booking.ApartmentId, 
                currentStatus = booking.CurrentStatus,
            };
            return profile;
        }

        public GuestProfile ConvertGuestProfile(Booking booking)
        {
            var profile = new GuestProfile()
            {
                stayFrom = booking.HostFrom,
                stayTo = booking.HostTo,
                BookingId = booking.BookingId,
                firstname = booking.FirstName,
                lastname  = booking.LastName,
                GuestPicture64 = booking.GuestPicture,
                GuestStatusEnum = booking.CurrentStatus,
            };
            return profile;
        }

        public void DeleteBookingsByApartmentId(Guid id)
        {
            var list =
                from booking in _context.Bookings
                where booking.ApartmentId == id
                select booking;
            foreach (var entity in list)
                _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
