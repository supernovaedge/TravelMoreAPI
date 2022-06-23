﻿namespace TravelMoreAPI.Models.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[] UserPicture { get; set; } = new byte[0];

    }
}
