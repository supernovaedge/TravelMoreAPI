namespace TravelMoreAPI.Models.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[]? UserPictureBase64 { get; set; } = new byte[0];
        public string UserPictureHeader { get; set; } = string.Empty;
    }
}
