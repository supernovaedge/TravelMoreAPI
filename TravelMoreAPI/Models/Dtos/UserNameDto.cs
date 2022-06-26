namespace TravelMoreAPI.Models.Dtos
{
    public class UserNameDto
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public string NewUserName { get; set; } = string.Empty;
    }
}
