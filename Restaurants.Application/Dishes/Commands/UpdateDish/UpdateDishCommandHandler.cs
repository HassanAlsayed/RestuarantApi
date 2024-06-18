using MediatR;
using Restaurants.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.UpdateDish
{
    public class UpdateDishCommandHandler(IDisheServices services) : IRequestHandler<UpdateDishCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            var DishId = await services.UpdateDish(request, request.Id);
            return DishId;
        }
    }
}
