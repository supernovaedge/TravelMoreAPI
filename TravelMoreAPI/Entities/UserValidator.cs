using FluentValidation;

namespace TravelMoreAPI.Entities
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.FirstName).Length(1, 32);
            RuleFor(x => x.LastName).Length(1, 32);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.UserName).Length(13, 15);
        }
    }
}

