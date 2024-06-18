using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Restuarant.Queries.GetAllRestuarants
{
    public class GetAllRestuarantsQuery : IRequest<IEnumerable<RestuarantDtos>>
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public bool? sort { get; init; }
        public int Page { get; init; }
    }
}
