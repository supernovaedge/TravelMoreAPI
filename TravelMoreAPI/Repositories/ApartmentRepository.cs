using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {

        private readonly Data.UserDbContext _context;
        public ApartmentRepository(UserDbContext context)
        {
            _context = context;
        }

        

        public Apartment? GetApartmentById(Guid id)
        {
            return _context.Apartments.FirstOrDefault(x => x.ApartmentId == id);
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return _context.Apartments;
        }

        public void AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
        }
    }
}
