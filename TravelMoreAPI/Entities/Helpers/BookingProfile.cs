using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Entities.Helpers
{
    public class BookingProfile
    {
        public Guid BookingId;
        public Guid ApartmentId;
        public GuestStatusEnum currentStatus;
        public DateTime stayFrom;
        public DateTime stayTo;
    }
}
