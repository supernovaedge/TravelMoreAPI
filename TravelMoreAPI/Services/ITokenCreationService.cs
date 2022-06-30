using TravelMoreAPI.Entities;

namespace TravelMoreAPI
{
    public interface ITokenCreationService
    {
        string CreateToken(User user);
    }
}
