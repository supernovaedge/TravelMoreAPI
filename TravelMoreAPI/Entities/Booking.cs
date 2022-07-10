using System.ComponentModel.DataAnnotations;
using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Entities
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
        public Guid HostId { get; set; }
        public Guid GuestId { get; set; }
        public Guid ApartmentId { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HostFrom { get; set; }
        public DateTime HostTo { get; set; }
        public UserPicture64? GuestPicture { get; set; }

        private GuestStatusEnum _guestStatus;
        public GuestStatusEnum CurrentStatus
        {
            get { return _guestStatus; }
            set { _guestStatus = value; }
        }
    }
}
