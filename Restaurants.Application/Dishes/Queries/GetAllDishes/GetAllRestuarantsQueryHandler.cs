using MediatR;
using Restaurants.Application.Repository;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes
{
    public class GetAllRestuarantsQueryHandler(IDisheServices services) : IRequestHandler<GetAllDishesQuery, IEnumerable<Dish>>
    {
        public async Task<IEnumerable<Dish>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
        {
            return await services.GetAllDishes();
        }
    }
}
