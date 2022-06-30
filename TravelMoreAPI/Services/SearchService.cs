using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;
using TravelMoreAPI.Repositories.BookingT;

namespace TravelMoreAPI.Services
{
    public class SearchService : ISearchService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;

        public SearchService(
            IApartmentRepository apartmentRepository,
            IBookingRepository bookingRepository)
        {
            _apartmentRepository = apartmentRepository;
            _bookingRepository = bookingRepository;
        }

        public List<Apartment> GetApartments(SearchCriteriaDto searchCriteria)
        {
            var apartments = _apartmentRepository.GetApartments(searchCriteria).ToList();

            foreach (Booking bookingEntity in _bookingRepository.GetBookings())
            {
                if (searchCriteria.StartDate <= bookingEntity.HostFrom.Date && bookingEntity.HostTo.Date <= searchCriteria.EndDate.Date && bookingEntity.CurrentStatus == GuestStatus.GuestStatusEnum.Accepted)
                {
                    var apartment = apartments.FirstOrDefault(x => x.ApartmentId == bookingEntity.ApartmentId);
                    if (apartment == null)
                    {
                        continue;
                    }
                    apartment.ApartmentStatus = false;
                }
            }
            return apartments;
        }
    }
}