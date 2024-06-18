using MediatR;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes
{
    public class GetAllDishesQuery : IRequest<IEnumerable<Dish>>
    {
    }
}
