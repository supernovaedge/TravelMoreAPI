namespace TravelMoreAPI.Models.Dtos
{
    public class ApartmentDto
    {
        public Guid UserID { get; set; } = Guid.Empty;
        public string City { get; set; } =  string.Empty;
        public string Address { get; set; } = string.Empty;
        public int DistanceToCenter { get; set; } = 0;
        public int BedsNumber { get; set; } = 0;
        public string ApartmentDescription { get; set; } = string.Empty;
        public byte[] ApartmentPicture { get; set; } = new byte[0];

    }
}
