using MediatR;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Dishes.Queries.GetDishById
{
    public class GetDishByIdQuery : IRequest<Dish>
    {
        public Guid Id { get; init; }
    }
}
