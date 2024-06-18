using MediatR;
using Restaurants.Application.Dtos;
using Restaurants.Application.Repository;

namespace Restaurants.Application.Restuarant.Queries.GetRestuarantById
{
    public class GetRestuarantByIdQueryHandler(IRestuarantServices services) : IRequestHandler<GetRestuarantByIdQuery, RestuarantDtos?>
    {
        public async Task<RestuarantDtos> Handle(GetRestuarantByIdQuery request, CancellationToken cancellationToken)
        {
            return await services.GetRestuarantById(request.Id);
        }
    }
}
