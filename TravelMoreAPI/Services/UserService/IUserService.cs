using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Services.UserService
{
    public interface IUserService
    {
        Guid CreateUser(UserDto userDto);
        string Login(UserLoginDto request);
        string ChangeEmail(EmailDto emailDto);
        string ChangeUsername(UserNameDto userNameDto);
        bool ChangePassword(PasswordDto passwordDto);
        Profile GetUserProfileById(Guid id);
        User GetUserById(Guid id);

    }
}
