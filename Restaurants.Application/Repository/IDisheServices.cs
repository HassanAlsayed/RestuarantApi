using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.UpdateDish;
using Restaurnats.Domain.Entities;

namespace Restaurants.Application.Repository
{
    public interface IDisheServices
    {
        public Task<Guid> AddDish(CreateDishCommand dishCommand, Guid RestuarantId);
        public Task<IEnumerable<Dish>> GetAllDishes();
        public Task<Dish> GetDishById(Guid id);
        public Task<Guid> DeleteDish(Guid id);
        public Task<Guid> UpdateDish(UpdateDishCommand dishCommand, Guid id);
    }
}
