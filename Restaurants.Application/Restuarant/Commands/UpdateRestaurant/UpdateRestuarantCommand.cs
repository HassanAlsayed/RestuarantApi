using MediatR;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Restuarant.Commands.UpdateRestaurant
{
    public class UpdateRestuarantCommand : IRequest<Guid>
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool HasDelivery { get; set; }

        public List<Dish> Dishes { get; set; } = new();
    }
}
