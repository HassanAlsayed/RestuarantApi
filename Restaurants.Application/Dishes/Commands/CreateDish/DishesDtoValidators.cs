using FluentValidation;
using Restaurants.Application.Dihses.Dtos;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class DishesDtoValidators : AbstractValidator<CreateDishCommand>
    {
        public DishesDtoValidators()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
