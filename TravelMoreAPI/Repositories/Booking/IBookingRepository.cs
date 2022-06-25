using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetApartments();
        List<Booking>? GetBookingsById(Guid id);

        void AddBooking(Booking booking);

        void SaveChanges();

        Booking GuestToBooking(Guest guest);

    }
}
