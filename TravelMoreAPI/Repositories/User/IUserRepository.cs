using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User? GetUserById(Guid id);
        void AddUser(User user);
        void SaveChanges();

        bool EmailUniqueValidation(string email);
        bool UsernameUniqueValidation(string username);

        Profile? GetUserProfileById(Guid id);
    }
}
