using System.Net;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Exceptions;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;
using TravelMoreAPI.Repositories.BookingRepository;
using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }


        public Booking CreateBooking(BookingDto bookingDto)
        {
            var entity = _userRepository.GetUserByApartmentId(bookingDto.ApartmentId);

            if (entity!.UserId == bookingDto.GuestId)
            {
                throw new BookingException("Can't book your own Apartment");
            }
            foreach (BookingProfile bookingEntity in _bookingRepository.GetBookingProfile(bookingDto.GuestId)!)
            {
                if (bookingDto.HostFrom.Date <= bookingEntity.stayTo.Date && bookingEntity.stayFrom.Date <= bookingDto.HostTo.Date) throw new BookingException("Dates overlap with previous booking request");
            }

            var booking = new Booking()
            {
                BookingId = Guid.NewGuid(),
                GuestId = bookingDto.GuestId,
                ApartmentId = bookingDto.ApartmentId,
                FirstName = bookingDto.FirstName,
                LastName = bookingDto.LastName,
                City = bookingDto.City,
                HostFrom = bookingDto.HostFrom.Date,
                HostTo = bookingDto.HostTo.Date,
                CurrentStatus = (GuestStatusEnum)0,
                HostId = entity.UserId,
                GuestPicture = _userRepository.GetUserProfileById(bookingDto.GuestId)!.UserPicture,
            };

            _bookingRepository.AddBooking(booking);

            _bookingRepository.SaveChanges();

            return booking;
        }

        public List<BookingProfile> GetBookingProfileById(Guid id)
        {
            var booking = _bookingRepository.GetBookingProfile(id);
            return booking;
        }

        public List<GuestProfile> GetGuestProfileById(Guid id)
        {
            var guests = _bookingRepository.GetGuestProfile(id);
            return guests;
        }

        public Booking SetBookingStatus(Guid id, int i, Guid claimId)
        {
            var booking = _bookingRepository.GetBookingById(id);
            if (claimId != booking.HostId)
            {
                throw new ForbiddenException();
            }
            if (i == 0 || i > 2) throw new BookingException("Invalid Status Enumeration");
            var userGuests = _bookingRepository.GetGuestProfile(booking.HostId);

            if (i == 2)
            {
                foreach (GuestProfile bookingEntity in userGuests)
                {
                    if (booking.HostFrom.Date <= bookingEntity.stayTo.Date && bookingEntity.stayFrom.Date <= booking.HostTo.Date)
                    {
                        _bookingRepository.GetBookingById(bookingEntity.BookingId).CurrentStatus = GuestStatusEnum.NotPossible;
                    }
                }
            }

            booking.CurrentStatus = (GuestStatusEnum)i;
            _bookingRepository.SaveChanges();
            return booking;            
        }

        public Booking DeleteBooking(Guid id, Guid claimId)
        {
            var bookingToDelete = _bookingRepository.GetBookingById(id);
            if (claimId != bookingToDelete.GuestId)
            {
                throw new ForbiddenException();
            }
            if (bookingToDelete.CurrentStatus == (GuestStatusEnum)2)
            {
                throw new BookingException("Booking Already Accepted");
            }
            _bookingRepository.DeleteBooking(bookingToDelete);
            _bookingRepository.SaveChanges();

            return bookingToDelete;
        }
    }
}
