

using TravelMoreAPI.Entities.Helpers;

namespace TravelMoreAPI.Entities
{
    public class Apartment 
    {
        public Guid ApartmentId { get; set; }     
        public string City { get; set; }
        public string Address { get; set; }
        public int DistanceToCenter { get; set; }
        public int BedsNumber { get; set; }
        public string? ApartmentDescription { get; set; }
        public string? ApartmentCoordinates { get; set; }
        public ApartmentPicture64 ApartmentPicture { get; set; }

    }
}
