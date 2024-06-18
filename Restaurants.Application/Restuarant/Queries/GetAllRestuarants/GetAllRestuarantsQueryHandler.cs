using MediatR;
using Restaurants.Application.Dtos;
using Restaurants.Application.Repository;
using Restaurnats.Domain.Additios;

namespace Restaurants.Application.Restuarant.Queries.GetAllRestuarants
{
    public class GetAllRestuarantsQueryHandler(IRestuarantServices services) : IRequestHandler<GetAllRestuarantsQuery, IEnumerable<RestuarantDtos>>
    {
        public async Task<IEnumerable<RestuarantDtos>> Handle(GetAllRestuarantsQuery request, CancellationToken cancellationToken)
        {
          return await services.GetAllRestuarants(request.Name,request.Description,request.sort,request.Page);
        }
    }
}
