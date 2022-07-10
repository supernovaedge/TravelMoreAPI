using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;
using TravelMoreAPI.Repositories.BookingRepository;

namespace TravelMoreAPI.Services.ApartmentService
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;

        public ApartmentService(IApartmentRepository apartmentRepository, IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _apartmentRepository = apartmentRepository ?? throw new ArgumentNullException(nameof(apartmentRepository));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }
        public IEnumerable<Apartment> GetApartments(int n)
        {
            return _apartmentRepository.GetApartments(n);
        }

        public Apartment GetApartmentById(Guid id)
        {
            var apartment = _apartmentRepository.GetApartmentById(id);
            return apartment!;
        }

        public Apartment CreateApartment(ApartmentDto apartmentDto)
        {
            var entity = _userRepository.GetUserById(apartmentDto.UserId);

            var newGuid = Guid.NewGuid();
            var apartment = new Apartment()
            {
                ApartmentId = newGuid,
                City = apartmentDto.City,
                Address = apartmentDto.Address,
                BedsNumber = apartmentDto.BedsNumber,
                DistanceToCenter = apartmentDto.DistanceToCenter,
                ApartmentDescription = apartmentDto.ApartmentDescription,
                ApartmentCoordinates = apartmentDto.ApartmentCoordinates,
                ApartmentPicture = new ApartmentPicture64 { ApartmentId = newGuid, ApartmentPicture = apartmentDto.ApartmentPictureBase64, ApartmentHeader = apartmentDto.ApartmentPictureHeader }
            };
            _apartmentRepository.AddApartment(apartment);

            entity!.ApartmentId = apartment.ApartmentId;

            _userRepository.SaveChanges();

            return apartment;
        }

        public bool DeleteApartment(Guid id)
        {

            var entity = _userRepository.GetUserById(id);
            if (entity!.Apartment == null)
            {
                return true;
            }

            _bookingRepository.DeleteBookingsByApartmentId(entity.ApartmentId.GetValueOrDefault());
            _apartmentRepository.DeleteApartment(entity.Apartment);
            entity.ApartmentId = null;

            _apartmentRepository.SaveChanges();

            return true;
        }
    }
}
