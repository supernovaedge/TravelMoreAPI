
using System.ComponentModel.DataAnnotations;


namespace TravelMoreAPI.Entities
{

    public class UserPicture64
    {
        [Key]
        public Guid UserId { get; set; }
        public byte[] UserPicture { get; set; }
        public string UserHeader { get; set; }

    }
}
