
using Restaurnats.Domain.Entities;

namespace Restaurnats.Domain
{
    public class Restaurant
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category {  get; set; } = string.Empty;
        public bool HasDelivery { get; set; }

        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; } = new();

    }
}
