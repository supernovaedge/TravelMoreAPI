using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {

            RuleFor(x => x.UserName).Length(5, 30);
            RuleFor(x => x.Password).Length(6, 255);
        }
    }
}