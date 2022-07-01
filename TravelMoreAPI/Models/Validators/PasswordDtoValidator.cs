using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class PasswordDtoValidator : AbstractValidator<PasswordDto>
    {
        public PasswordDtoValidator()
        {
            RuleFor(x => x.NewPassword).Length(6, 255);
        }
    }
}
