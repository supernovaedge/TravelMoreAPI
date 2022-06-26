using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelMoreAPI.Entities
{
    [Keyless]
    [NotMapped]
    public class ImageBase64
    {
        public byte[] Picture;
        public string Header;
    }
}
