using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class SearchCriteriaDtoValidator : AbstractValidator<SearchCriteriaDto>
    {
        public SearchCriteriaDtoValidator()
        {
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.EndDate).LessThanOrEqualTo(DateTime.Now.Date.AddDays(32));
            RuleFor(x => x.Address).Length(1, 255);
            RuleFor(x => x.BedNumber).GreaterThan(0);
            RuleFor(x => x.City).Length(2, 32);
        }
    }
}