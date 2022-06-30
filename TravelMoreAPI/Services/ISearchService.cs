using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Services
{
    public interface ISearchService
    {
        List<Apartment> GetApartments(SearchCriteriaDto searchCriteria);
    }
}