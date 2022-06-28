using Microsoft.EntityFrameworkCore;
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
            return _context.Apartments.Include(u => u.ApartmentPicture).FirstOrDefault(x => x.ApartmentId == id);
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return _context.Apartments.Include(x => x.ApartmentPicture).Take(10);
        }

        public void AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteApartment(Apartment apartment)
        {
            _context.Apartments.Remove(apartment);
            SaveChanges();
        }
    }
}
