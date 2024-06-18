using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Dihses.Dtos
{
    public class DishesDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }

        public Guid RestaurantId { get; set; }
    }
}
