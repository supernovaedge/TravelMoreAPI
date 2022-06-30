using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Services;

namespace TravelMoreAPI.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Apartment>> GetApartment(SearchCriteriaDto searchCriteriaDto)
        {
            var apartments = _searchService.GetApartments(searchCriteriaDto);

            if (apartments == null || apartments.Count == 0)
            {
                return NotFound();
            }

            return Ok(apartments);
        }
    }
}
