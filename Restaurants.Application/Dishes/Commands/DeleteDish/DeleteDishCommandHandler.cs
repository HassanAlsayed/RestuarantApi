using MediatR;
using Restaurants.Application.Repository;

namespace Restaurants.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommandHandler(IDisheServices services) : IRequestHandler<DeleteDishCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var dish = await services.DeleteDish(request.Id);
            return dish;
        }
    }
}
