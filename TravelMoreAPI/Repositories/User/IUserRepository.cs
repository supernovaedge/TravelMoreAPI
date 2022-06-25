using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User? GetUserById(Guid id);
        User? GetUserByEmail(string email);
        User? GetUserByUsername(string userName);
        void AddUser(User user);
        void SaveChanges();
        Profile? GetUserProfileById(Guid id);
    }
}
