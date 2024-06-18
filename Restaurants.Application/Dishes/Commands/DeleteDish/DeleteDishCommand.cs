using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommand : IRequest<Guid>
    {
        public Guid Id { get; init; }
    }
}
