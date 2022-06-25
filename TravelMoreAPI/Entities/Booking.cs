

namespace TravelMoreAPI.Entities
{
    public class Booking
    {
        public Guid ApartmentId { get; set; }
        public string City { get; set; }
        public DateTime StayFrom { get; set; }
        public DateTime StayTo { get; set; }
        public Guid UserId { get; set; }
    }
}
