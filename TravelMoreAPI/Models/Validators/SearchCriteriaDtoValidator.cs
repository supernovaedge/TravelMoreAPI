using FluentValidation;
using TravelMoreAPI.Models.Dtos;

namespace TravelMoreAPI.Models.Validators
{
    public class SearchCriteriaDtoValidator : AbstractValidator<SearchCriteriaDto>
    {
        public SearchCriteriaDtoValidator()
        {
            RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .When(x => x.StartDate.HasValue);
            RuleFor(x => x.EndDate)
                .LessThanOrEqualTo(DateTime.Now.Date.AddDays(32))
                .When(x => x.EndDate.HasValue);
            RuleFor(x => x.Address)
                .Length(1, 255)
                .When(x => x.Address != null);
            RuleFor(x => x.BedNumber)
                .GreaterThan(0)
                .When(x => x.BedNumber.HasValue);  
            RuleFor(x => x.City)
                .Length(2, 32)
                .When(x => x.City != null);
        }
    }
}