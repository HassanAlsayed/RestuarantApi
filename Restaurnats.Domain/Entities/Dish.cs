
namespace Restaurnats.Domain.Entities
{
    public class Dish
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public decimal Price { get; set; }
    }
}
