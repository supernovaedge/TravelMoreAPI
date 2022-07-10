using TravelMoreAPI.Entities;
using TravelMoreAPI.Exceptions;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;

namespace TravelMoreAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenCreationService _tokenCreationService;


        public UserService(IUserRepository repository, ITokenCreationService tokenCreationService)
        {
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tokenCreationService = tokenCreationService ?? throw new ArgumentNullException(nameof(tokenCreationService));
        }


        public Guid CreateUser(UserDto userDto)
        {

            PasswordProcessingService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newGuid = Guid.NewGuid();
            var user = new User()
            {
                UserId = newGuid,
                UserName = userDto.UserName.ToLower(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email.ToLower(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserPicture = new UserPicture64 { UserId = newGuid, UserPicture = userDto.UserPictureBase64, UserHeader = userDto.UserPictureHeader }
            };

            var usernameOwner = _userRepository.GetUserByUsername(userDto.UserName);
            if (usernameOwner != null)
            {
                throw new UsernameInUseException(userDto.UserName);
            }

            var emailOwner = _userRepository.GetUserByEmail(userDto.Email);
            if (emailOwner != null)
            {
                throw new EmailInUseException(userDto.Email);
            }

            _userRepository.AddUser(user);
            return user.UserId;
        }

        public string Login(UserLoginDto request)
        {
            var user = _userRepository.GetUserByUsername(request.UserName);
            if (user == null)
            {
                throw new WrongCredentialsException();
            }
            if (!PasswordProcessingService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new WrongCredentialsException();
            }

            string token = _tokenCreationService.CreateToken(user);

            return token;
        }

        public string ChangeEmail(EmailDto emailDto)
        {

            var entity = _userRepository.GetUserById(emailDto.UserId);

            var emailOwner = _userRepository.GetUserByEmail(emailDto.NewEmail.ToLower());
            if (emailOwner != null)
            {
                throw new EmailInUseException(emailDto.NewEmail);
            }


            entity!.Email = emailDto.NewEmail.ToLower();
            _userRepository.SaveChanges();

            return emailDto.NewEmail;
        }

        public string ChangeUsername(UserNameDto userNameDto)
        {

            var entity = _userRepository.GetUserById(userNameDto.UserId);

            var userNameOwner = _userRepository.GetUserByUsername(userNameDto.NewUserName.ToLower());
            if (userNameOwner != null)
            {
                throw new UsernameInUseException(userNameDto.NewUserName);
            }

            entity!.UserName = userNameDto.NewUserName.ToLower();
            _userRepository.SaveChanges();

            return userNameDto.NewUserName;
        }

        public bool ChangePassword(PasswordDto passwordDto)
        {

            var entity = _userRepository.GetUserById(passwordDto.UserId);

            PasswordProcessingService.CreatePasswordHash(passwordDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

            entity!.PasswordHash = passwordHash;
            entity!.PasswordSalt = passwordSalt;

            _userRepository.SaveChanges();

            return true;
        }

        public Profile GetUserProfileById(Guid id)
        {
            var profile = _userRepository.GetUserProfileById(id);

            return profile!;
        }

        public User GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            return user!;
        }
    }
}
