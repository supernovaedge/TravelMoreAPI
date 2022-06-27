﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
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
        private readonly IGuestRepository _guestRepository;
        private readonly IBookingRepository _bookingRepository;

        public ApartmentController(IApartmentRepository apartmentRepository, IUserRepository userRepository, IBookingRepository bookingRepository,IGuestRepository guestRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _apartmentRepository = apartmentRepository ?? throw new ArgumentNullException(nameof(apartmentRepository));
            _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }


        [HttpGet]
        public async Task<IEnumerable<Apartment>> Get()
        {
            return _apartmentRepository.GetApartments();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Apartment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var apartment = _apartmentRepository.GetApartmentById(id);

            return apartment == null ? NotFound() : Ok(apartment);
        }


        [HttpPost("AddApartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Apartment> Create(ApartmentDto apartmentDto)
        {
     
            var userId = apartmentDto.UserID;

            var entity = _userRepository.GetUserById(userId);
            if(entity == null)
            {
                return NotFound("User not found");
            }

            var newGuid = Guid.NewGuid();
            var apartment = new Apartment()
            {
                ApartmentId = newGuid,
                City = apartmentDto.City,
                Address = apartmentDto.Address,
                BedsNumber = apartmentDto.BedsNumber,
                DistanceToCenter = apartmentDto.DistanceToCenter,
                ApartmentDescription = apartmentDto.ApartmentDescription,
                ApartmentCoordinates = apartmentDto.ApartmentCoordinates,
                ApartmentPicture = new ApartmentPicture64{ApartmentId = newGuid ,ApartmentPicture = apartmentDto.ApartmentPictureBase64,ApartmentHeader = apartmentDto.ApartmentPictureHeader}
            };
            _apartmentRepository.AddApartment(apartment);

            entity.ApartmentId = apartment.ApartmentId;

            _userRepository.SaveChanges();

            return Ok(apartment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var entity = _userRepository.GetUserById(id);
            if (entity == null)
            {
                return NotFound("User not found");
            }
            
            if(entity.Apartment == null)
            {
                return NotFound("User has no apartment");
            }

            var guestToRemove = _guestRepository.GetGuestsById(id);
            foreach (var guestEntity in guestToRemove)
            {
                _userRepository.DeleteGuest(guestEntity);
                _bookingRepository.GetBookingByApartmentId(guestEntity.ApartmentID).CurrentStatus = GuestStatus.GuestStatusEnum.denied;
            }
                

            
            _apartmentRepository.DeleteApartment(entity.Apartment);
            entity.ApartmentId = null;
            _bookingRepository.SaveChanges();
            _guestRepository.SaveChanges();
            return Ok("Apartment removed");
        }
    }
}
