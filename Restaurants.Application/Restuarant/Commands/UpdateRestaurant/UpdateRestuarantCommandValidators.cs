using FluentValidation;

namespace Restaurants.Application.Restuarant.Commands.UpdateRestaurant
{
    public class UpdateRestuarantCommandValidators : AbstractValidator<UpdateRestuarantCommand>
    {
        public UpdateRestuarantCommandValidators()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(dto => dto.Category).NotEmpty().WithMessage("Insert valid category");
        }
    }
}
