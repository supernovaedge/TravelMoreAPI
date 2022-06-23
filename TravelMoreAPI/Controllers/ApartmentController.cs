using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Data;
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

        public ApartmentController(IApartmentRepository repository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _apartmentRepository = repository;
        }



        [HttpGet]
        public async Task<IEnumerable<Apartment>> Get()
        {
            return _apartmentRepository.GetApartments();
        }

        [HttpPost("AddApartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> Create(ApartmentDto ApartmentDto)
        {
     
            var userId = ApartmentDto.UserID;

            var entity = _userRepository.GetUserById(userId);
            if(entity == null)
            {
                throw new Exception("User not found");
            }
            

            var apartment = new Apartment()
            {
                ApartmentId = new Guid(),
                City = ApartmentDto.City,
                Address = ApartmentDto.Address,
                BedsNumber = ApartmentDto.BedsNumber,
                DistanceToCenter = ApartmentDto.DistanceToCenter,
                ImageBase64 = ApartmentDto.ImageBase64,
            };
            _apartmentRepository.AddApartment(apartment);

            entity.ApartmentId = apartment.ApartmentId;

            _userRepository.SaveChanges();

            return Ok(apartment);
        }
    }
}
