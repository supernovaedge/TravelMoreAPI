using System.ComponentModel.DataAnnotations;

namespace TravelMoreAPI.Entities.Helpers
{
    public class ApartmentPicture64
    {

            [Key]
            public Guid ApartmentId { get; set; }
            public byte[] ApartmentPicture { get; set; }
            public string ApartmentHeader { get; set; }

    }
}
