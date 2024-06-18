using MediatR;
using Restaurants.Application.Repository;

namespace Restaurants.Application.Restuarant.Commands.UpdateRestaurant
{
    internal class UpdateRestuarantCommandHandler(IRestuarantServices services) : IRequestHandler<UpdateRestuarantCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateRestuarantCommand request, CancellationToken cancellationToken)
        {
            await services.UpdateRestuarant(request,request.Id);
            return request.Id;
        }
    }
}
