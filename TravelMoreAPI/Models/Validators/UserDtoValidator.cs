using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
            public UserDtoValidator()
            {
                RuleFor(x => x.FirstName).Length(2, 30);
                RuleFor(x => x.LastName).Length(2, 30);
                RuleFor(x => x.Email).EmailAddress();
                RuleFor(x => x.UserName).Length(5, 25);
                RuleFor(x => x.Password).Length(6, 255);
                RuleFor(x => x.UserPictureHeader).NotNull();
                RuleFor(x => x.UserPictureBase64).NotNull();
            }
    }
}