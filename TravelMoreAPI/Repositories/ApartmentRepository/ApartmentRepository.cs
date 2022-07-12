using Microsoft.EntityFrameworkCore;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Exceptions;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {

        private readonly UserDbContext _context;
        public ApartmentRepository(UserDbContext context)
        {
            _context = context;
        }

        public Apartment GetApartmentById(Guid id)
        {
            var apartment = _context.Apartments.Include(u => u.ApartmentPicture).FirstOrDefault(x => x.ApartmentId == id);
            if (apartment == null)
            {
                throw new ApartmentNotFoundException(id);
            }
            return apartment;
        }

        public IEnumerable<Apartment> GetApartments(int n)
        {
            return _context.Apartments.Include(x => x.ApartmentPicture).Take(n);
        }

        public IEnumerable<Apartment> GetApartments(SearchCriteriaDto searchCriteria = null)
        {
            if (searchCriteria == null)
            {
                return _context.Apartments.Include(x => x.ApartmentPicture);
            }
            
            return _context.Apartments.Where(x => x.Address.Contains(searchCriteria.Address)
                                            || x.City.Contains(searchCriteria.Address.ToLower())                               
                                            || (x.BedsNumber == searchCriteria.BedNumber
                                            && x.City.ToLower() == searchCriteria.City.ToLower()))
                                            .Include(x => x.ApartmentPicture);
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