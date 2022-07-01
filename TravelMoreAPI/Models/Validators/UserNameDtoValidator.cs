using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class UserNameDtoValidator : AbstractValidator<UserNameDto>
    {
        public UserNameDtoValidator()
        {
            RuleFor(x => x.NewUserName).Length(5, 25);
        }
    }
}
