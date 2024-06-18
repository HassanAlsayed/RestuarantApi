using Restaurants.Application.Dihses.Dtos;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Dtos
{
    public class RestuarantDtos
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool HasDelivery { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }

        public List<DishesDto> Dishes { get; set; } = new();
    }
}
