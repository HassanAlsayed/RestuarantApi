using FluentValidation;

namespace Restaurants.Application.Restuarant.Commands.CreateRertuarants
{
    public class CreateRestuarantCommandValidators : AbstractValidator<CreateRestuarntCommand>
    {
        public CreateRestuarantCommandValidators()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(dto => dto.Category).NotEmpty().WithMessage("Insert valid category");
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("please provide valid email address");
            RuleFor(dto => dto.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("please provide a valid postal code XX-XXX");
        }
    }
}
