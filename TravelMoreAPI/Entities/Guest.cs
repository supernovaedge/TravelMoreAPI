

using System.ComponentModel.DataAnnotations;
using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Entities
{
    public class Guest
    {
        [Key]
        public Guid BookingId { get; set; }
        public Guid GuestId { get; set; }
        public Guid ApartmentID { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HostFrom { get; set; }
        public DateTime HostTo { get; set; }  
        public Guid UserId { get; set; }


        private GuestStatusEnum _guestStatus;
        public GuestStatusEnum CurrentStatus
        {
            get { return _guestStatus; }
            set { _guestStatus = value; }
        }
    }
}
