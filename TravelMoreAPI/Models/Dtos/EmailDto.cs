namespace TravelMoreAPI.Models.Dtos
{
    public class EmailDto
    {
        public string NewEmail { get; set; } = string.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
