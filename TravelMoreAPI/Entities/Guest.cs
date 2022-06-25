

namespace TravelMoreAPI.Entities
{
    public class Guest
    {
        public Guid GuestId { get; set; }
        public Guid ApartmentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HostFrom { get; set; }
        public DateTime HostTo { get; set; }  
        public Guid UserId { get; set; }
        public bool GuestStatus { get; set; }
    }
}
