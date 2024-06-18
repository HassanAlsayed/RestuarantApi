using MediatR;
using Restaurants.Application.Repository;

namespace Restaurants.Application.Restuarant.Commands.DeleteRestuarant
{
    public class DeleteRestuarantCommandHandler(IRestuarantServices services) : IRequestHandler<DeleteRestuarantCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteRestuarantCommand request, CancellationToken cancellationToken)
        {
            await services.DeleteRestuarant(request.Id);
            return request.Id;
        }
    }
}
