using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Dihses.Dtos;
using Restaurants.Application.Dtos;
using Restaurants.Application.Repository;
using Restaurants.Application.Restuarant.Commands.CreateRertuarants;
using Restaurants.Application.Restuarant.Commands.UpdateRestaurant;
using Restaurants.Infrastructure.Data;
using Restaurnats.Domain;
using Restaurnats.Domain.Additios;
using Restaurnats.Domain.Entities;

namespace Restaurants.Infrastructure.Repository
{ 
    public class RestuarantSercices(RestuarantDbContext dbContext) : IRestuarantServices
    {
        public async Task<Guid> AddRestuarant(CreateRestuarntCommand restuarant)
        {
            var AddedRestuarant = new Restaurant
            {
                Name = restuarant.Name,
                Description = restuarant.Description,
                Category = restuarant.Category,
                HasDelivery = restuarant.HasDelivery,
                ContactEmail = restuarant.ContactEmail,
                ContactNumber = restuarant.ContactNumber,
                Address = new Address
                {
                    City = restuarant.City,
                    Street = restuarant.Street,
                    PostalCode = restuarant.PostalCode,

                },
                Dishes = restuarant.Dishes.Select(d => new Dish
                {
                    Name = d.Name,
                    Description = d.Description,
                    Price = d.Price,
                    KiloCalories = d.KiloCalories,
                }).ToList(),
            };
            await dbContext.AddAsync(AddedRestuarant);
            await dbContext.SaveChangesAsync();
            return AddedRestuarant.Id;
        }

        public async Task<Guid?> DeleteRestuarant(Guid id)
        {
            var restuarant = await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);

            dbContext.Remove(restuarant);
            await dbContext.SaveChangesAsync();
            return restuarant?.Id;
        }

        public async Task<IEnumerable<RestuarantDtos>> GetAllRestuarants(string? name, string? description, bool? sort,int page)
        {
            var restaurants = dbContext.Restaurants.Include(r => r.Dishes).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                restaurants = restaurants.Where(r => r.Description.Contains(description));
            }
            if(sort == true)
            {
                restaurants = restaurants.OrderBy(r => r.Name);
            }
            int pageSize = 1;
            int totalCount = await restaurants.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            page = Math.Max(1, Math.Min(page, totalPages));

            var resturantsList = await restaurants.Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToListAsync();
                                         
            var restaurantDtos = resturantsList.Select(r => new RestuarantDtos
            {
                Name = r.Name,
                Description = r.Description,
                Category = r.Category,
                HasDelivery = r.HasDelivery,
                City = r.Address!.City,
                Street = r.Address.Street,
                PostalCode = r.Address.PostalCode,
                Dishes = r.Dishes.Select(d => new DishesDto
                {
                    Name = d.Name,
                    Description = d.Description,
                    Price = d.Price,
                    KiloCalories = d.KiloCalories,
                    RestaurantId = d.RestaurantId,
                }).ToList(),

            }).ToList();

            return restaurantDtos!;
        }

        public async Task<RestuarantDtos?> GetRestuarantById(Guid id)
        {

            var restuarant = await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
            var restuarantDto = new RestuarantDtos
         {
             Name = restuarant!.Name,
             Description = restuarant.Description,
             Category = restuarant.Category,
             HasDelivery = restuarant.HasDelivery,
             City = restuarant.Address?.City,
             Street = restuarant.Address?.Street,
             PostalCode = restuarant.Address?.PostalCode,
             Dishes = restuarant.Dishes.Select(d => new DishesDto
             {
                 Name = d.Name,
                 Description = d.Description,
                 Price = d.Price,
                 KiloCalories = d.KiloCalories,
                 RestaurantId = d.RestaurantId,
             }).ToList(),

        };
            return restuarantDto;

        }

        public async Task<Guid?> UpdateRestuarant(UpdateRestuarantCommand restuarant, Guid id)
        {
            var ExistedRestuarant = await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);

            ExistedRestuarant!.Name = restuarant.Name;
            ExistedRestuarant.Description = restuarant.Description;
            ExistedRestuarant.Category = restuarant.Category;
            ExistedRestuarant.HasDelivery = restuarant.HasDelivery;

            ExistedRestuarant.Dishes = restuarant.Dishes.Select(d => new Dish
            {
                Name= d.Name,
                Description= d.Description,
                Price = d.Price,
                KiloCalories= d.KiloCalories,
            }).ToList();

            await dbContext.SaveChangesAsync();
            return ExistedRestuarant.Id;
        }
    }
}
