using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;

namespace TravelMoreAPI.Repositories.BookingT
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookings();
        void AddBooking(Booking booking);
        Booking GetBookingById(Guid id);
        BookingProfile ConvertBookingProfile(Booking booking);
        GuestProfile ConvertGuestProfile(Booking booking);
        List<BookingProfile> GetBookingProfile(Guid id);
        List<GuestProfile> GetGuestProfile(Guid id);
        void DeleteBookingsByApartmentId(Guid id);
        void SaveChanges();
    }
}
