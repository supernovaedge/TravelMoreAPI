namespace TravelMoreAPI.Models.Dtos
{
    public class PasswordDto
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
