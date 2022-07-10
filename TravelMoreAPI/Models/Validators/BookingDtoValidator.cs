using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class BookingDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingDtoValidator()
        {
            RuleFor(x => x.HostFrom).GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.HostTo)
                .LessThanOrEqualTo(DateTime.Now.Date.AddDays(31))
                .GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.ApartmentId).NotNull().NotEmpty();
            RuleFor(x => x.City).Length(2, 32);
        }
    }
}