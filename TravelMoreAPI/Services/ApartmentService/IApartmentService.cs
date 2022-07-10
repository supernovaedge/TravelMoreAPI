using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Services.ApartmentService
{
    public interface IApartmentService
    {
        IEnumerable<Apartment> GetApartments(int n);
        Apartment GetApartmentById(Guid id);
        Apartment CreateApartment(ApartmentDto apartmentDto);
        public bool DeleteApartment(Guid id);
    }
}
