﻿using Microsoft.EntityFrameworkCore;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;

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
                                            || (x.BedsNumber == searchCriteria.BedNumber
                                            && x.City == searchCriteria.City))
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

        public ApartmentWithStatus ConvertApartmentWithStatus(Apartment apartment)
        {
            var apartmentWithStatus = new ApartmentWithStatus()
            {
                ApartmentId = apartment.ApartmentId,
                ApartmentPicture = apartment.ApartmentPicture,
                Address = apartment.Address,
                BedsNumber = apartment.BedsNumber,
                City = apartment.City,
                DistanceToCenter = apartment.DistanceToCenter,
                ApartmentCoordinates = apartment.ApartmentCoordinates,
                ApartmentDescription = apartment.ApartmentDescription,
            };
            return apartmentWithStatus;
        }
    }
}