using MediatR;
using Restaurants.Application.Repository;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Dishes.Queries.GetDishById
{
    public class GetDishByIdQueryHandler(IDisheServices services) : IRequestHandler<GetDishByIdQuery, Dish>
    {
        public async Task<Dish> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
           return await services.GetDishById(request.Id);
        }
    }
}
