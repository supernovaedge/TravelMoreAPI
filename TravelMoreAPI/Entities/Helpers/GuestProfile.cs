using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Entities.Helpers
{
    public class GuestProfile
    {
        public Guid BookingId;
        public string firstname;
        public string lastname;
        public DateTime stayFrom;
        public DateTime stayTo;
    }
}
