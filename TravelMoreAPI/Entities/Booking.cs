

using System.ComponentModel.DataAnnotations;
using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Entities
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
        public Guid ApartmentId { get; set; }
        public string City { get; set; }
        public DateTime StayFrom { get; set; }
        public DateTime StayTo { get; set; }
        public Guid UserId { get; set; }
        
        private GuestStatusEnum _guestStatus;
        public GuestStatusEnum CurrentStatus
        {
            get { return _guestStatus; }
            set { _guestStatus = value; }
        }
    }
}
