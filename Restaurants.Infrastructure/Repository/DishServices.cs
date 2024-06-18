using Restaurants.Application.Repository;
using Restaurants.Infrastructure.Data;
using Restaurnats.Domain.Entities;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.UpdateDish;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Restaurants.Application.Exeptions;

namespace Restaurants.Infrastructure.Repository
{
    public class DishServices(RestuarantDbContext dbContext) : IDisheServices
    {
        public async Task<Guid> AddDish(CreateDishCommand dishCommand, Guid RestuarantId)
        {
            var AddedDish = new Dish
            {
                Name = dishCommand.Name,
                Description = dishCommand.Description,
                Price = dishCommand.Price,
                KiloCalories = dishCommand.KiloCalories,
                RestaurantId = RestuarantId
            };
            await dbContext.Dishes.AddAsync(AddedDish);
            await dbContext.SaveChangesAsync();
            return AddedDish.Id;
        }

        public async Task<Guid> DeleteDish(Guid id)
        {
            var existedDish = await dbContext.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if(existedDish is null)
            {
                throw new NotFoundExeption($"No dish with id {id}");
            }
             dbContext.Remove(existedDish);
            await dbContext.SaveChangesAsync();
            return existedDish.Id;
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            return await dbContext.Dishes.ToListAsync();
        }

        public async Task<Dish> GetDishById(Guid id)
        {
            var existedDish = await dbContext.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if (existedDish is null)
            {
                throw new NotFoundExeption($"No dish with id {id}");
            }
            return existedDish;
        }

        public async Task<Guid> UpdateDish(UpdateDishCommand dishCommand, Guid id)
        {
            var existedDish = await dbContext.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if (existedDish is null)
            {
                throw new NotFoundExeption($"No dish with id {id}");
            }
                existedDish.Name = dishCommand.Name;
                existedDish.Description = dishCommand.Description;
                existedDish.Price = dishCommand.Price;
                existedDish.KiloCalories = dishCommand.KiloCalories;

             await dbContext.SaveChangesAsync();
            return existedDish.Id;

        }
    }
}
