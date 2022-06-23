using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetApartments();
        Apartment? GetApartmentById(Guid id);

        void AddApartment(Apartment apartment);

        void SaveChanges();
    }
}
