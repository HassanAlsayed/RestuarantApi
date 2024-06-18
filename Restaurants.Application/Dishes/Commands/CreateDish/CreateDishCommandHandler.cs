using MediatR;
using Restaurants.Application.Repository;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler(IDisheServices services) : IRequestHandler<CreateDishCommand, Guid>
    {
        public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
          var DishId =  await services.AddDish(request, request.RestaurantId);
            return DishId;
        }
    }
}
