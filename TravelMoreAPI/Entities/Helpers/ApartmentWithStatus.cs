namespace TravelMoreAPI.Entities.Helpers
{
    public class ApartmentWithStatus
    {
        public Guid ApartmentId;
        public string City;
        public string Address;
        public int DistanceToCenter;
        public int BedsNumber;
        public string? ApartmentDescription;
        public string? ApartmentCoordinates;
        public ApartmentPicture64 ApartmentPicture;
        public bool? Status;
    }
}
