namespace TravelMoreAPI.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserPicture64 UserPicture { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Guid? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
