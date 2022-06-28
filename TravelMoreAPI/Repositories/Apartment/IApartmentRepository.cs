using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetApartments(int n);
        Apartment? GetApartmentById(Guid id);

        void AddApartment(Apartment apartment);

        void SaveChanges();

        void DeleteApartment(Apartment apartment);
    }
}
