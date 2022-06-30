using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Repositories
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetApartments(int n);
        IEnumerable<Apartment> GetApartments(SearchCriteriaDto searchCriteriaDto = null);
        Apartment? GetApartmentById(Guid id);

        void AddApartment(Apartment apartment);

        void SaveChanges();

        void DeleteApartment(Apartment apartment);
        ApartmentWithStatus ConvertApartmentWithStatus(Apartment apartment);
    }
}
