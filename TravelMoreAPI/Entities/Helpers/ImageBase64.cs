
using System.ComponentModel.DataAnnotations;


namespace TravelMoreAPI.Entities
{

    public class ImageBase64
    {
        [Key]
        public Guid UserId { get; set; }
        public byte[] UserPicture { get; set; }
        public string UserHeader { get; set; }

        public byte[]? ApartmentPicture { get; set; }
        public string? ApartmentHeader { get; set; }
    }
}
