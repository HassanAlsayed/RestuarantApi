using Microsoft.AspNetCore.Http;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restuarant.Commands.CreateRertuarants;
using Restaurants.Application.Restuarant.Commands.UpdateRestaurant;
using Restaurnats.Domain;
using Restaurnats.Domain.Additios;

namespace Restaurants.Application.Repository
{
    public interface IRestuarantServices
    {
        public Task<IEnumerable<RestuarantDtos>> GetAllRestuarants(string? name, string? description,bool? sort,int pageSize);
        public Task<RestuarantDtos?> GetRestuarantById(Guid id);
        public Task<Guid> AddRestuarant(CreateRestuarntCommand restuarant);
        public Task<Guid?> DeleteRestuarant(Guid id);
        public Task<Guid?> UpdateRestuarant(UpdateRestuarantCommand restuarant,Guid id);
    }
}
