using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class ApartmentDtoValidator : AbstractValidator<ApartmentDto>
    {
        public ApartmentDtoValidator()
        {
            RuleFor(x => x.Address).Length(1, 255);
            RuleFor(x => x.ApartmentCoordinates).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.City).Length(2, 30);
            RuleFor(x => x.DistanceToCenter).NotNull();
            RuleFor(x => x.BedsNumber).GreaterThan(0);
            RuleFor(x => x.ApartmentDescription).Length(1, 255);
            RuleFor(x => x.ApartmentPictureHeader).NotNull();
            RuleFor(x => x.ApartmentPictureBase64).NotNull();
        }
    }
}
