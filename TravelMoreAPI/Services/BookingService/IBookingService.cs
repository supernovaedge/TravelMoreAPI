using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Services.BookingService
{
    public interface IBookingService
    {
        Booking CreateBooking(BookingDto bookingDto);
        List<BookingProfile> GetBookingProfileById(Guid id);
        List<GuestProfile> GetGuestProfileById(Guid id);
        Booking SetBookingStatus(Guid id, int i, Guid claimId);
        Booking DeleteBooking(Guid id, Guid claimId);
    }
}