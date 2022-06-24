using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;

namespace TravelMoreAPI.Controllers
{

    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentController(IApartmentRepository apartmentRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _apartmentRepository = apartmentRepository ?? throw new ArgumentNullException(nameof(apartmentRepository));
        }


        [HttpGet]
        public async Task<IEnumerable<Apartment>> Get()
        {
            return _apartmentRepository.GetApartments();
        }


        [HttpPost("AddApartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> Create(ApartmentDto apartmentDto)
        {
     
            var userId = apartmentDto.UserID;

            var entity = _userRepository.GetUserById(userId);
            if(entity == null)
            {
                throw new Exception("User not found");
            }


            var apartment = new Apartment()
            {
                ApartmentId = new Guid(),
                City = apartmentDto.City,
                Address = apartmentDto.Address,
                BedsNumber = apartmentDto.BedsNumber,
                DistanceToCenter = apartmentDto.DistanceToCenter,
                ApartmentPicture = apartmentDto.ApartmentPicture,
                ApartmentDescription = apartmentDto.ApartmentDescription,
            };
            _apartmentRepository.AddApartment(apartment);

            entity.ApartmentId = apartment.ApartmentId;

            _userRepository.SaveChanges();

            return Ok(apartment);
        }
    }
}
