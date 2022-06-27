using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetApartments();
        List<Booking>? GetBookingsById(Guid id);

        void AddBooking(Booking booking);

        Booking GetBookingByApartmentId(Guid id);

        void SaveChanges();

        Booking GuestToBooking(Guest guest);

    }
}
