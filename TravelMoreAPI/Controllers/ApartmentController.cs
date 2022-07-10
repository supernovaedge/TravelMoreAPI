using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Services.ApartmentService;

namespace TravelMoreAPI.Controllers
{

    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService ?? throw new ArgumentNullException(nameof(apartmentService));
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Apartment> Get(int n)
        {
            var apartments = _apartmentService.GetApartments(n);
            return apartments;
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult GetApartmentById(Guid id)
        {
            var apartment = _apartmentService.GetApartmentById(id);
            return apartment == null ? NotFound() : Ok(apartment);
        }

        [Authorize]
        [HttpPost("AddApartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Apartment> CreateApartment(ApartmentDto apartmentDto)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != apartmentDto.UserId.ToString())
            {
                return Forbid();
            }

            var apartment = _apartmentService.CreateApartment(apartmentDto);
            return Created($"https://localhost:7043/api/Apartment/AddApartment", apartment.ApartmentId);
        }


        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteApartment(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != id.ToString())
            {
                return Forbid();
            }

            var status  = _apartmentService.DeleteApartment(id);

            return status == false ? BadRequest() : NoContent();
        }
    }
}
