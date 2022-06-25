namespace TravelMoreAPI.Models.Dtos
{
    public class GuestDto
    {
        //public Guid GuestId { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;  
        public string LastName { get; set; } = string.Empty;
        public Guid ApartmentId { get; set; } = Guid.Empty;
        public DateTime HostFrom { get; set; } = DateTime.MinValue;
        public DateTime HostTo { get; set; } = DateTime.MinValue;
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
