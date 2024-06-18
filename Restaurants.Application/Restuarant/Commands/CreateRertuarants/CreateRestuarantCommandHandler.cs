using MediatR;
using Restaurnats.Domain.Entities;
using Restaurnats.Domain;
using Restaurants.Application.Repository;



namespace Restaurants.Application.Restuarant.Commands.CreateRertuarants
{
    public class CreateRestuarantCommandHandler(IRestuarantServices services) : IRequestHandler<CreateRestuarntCommand, Guid>
    {
        public async Task<Guid> Handle(CreateRestuarntCommand request, CancellationToken cancellationToken)
        {
            var restuarantId = await services.AddRestuarant(request);
            return restuarantId;
        }
    }
}
