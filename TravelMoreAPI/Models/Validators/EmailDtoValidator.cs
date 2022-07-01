using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class EmailDtoValidator : AbstractValidator<EmailDto>
    {
        public EmailDtoValidator()
        {

            RuleFor(x => x.NewEmail).EmailAddress();
        }
    }
}