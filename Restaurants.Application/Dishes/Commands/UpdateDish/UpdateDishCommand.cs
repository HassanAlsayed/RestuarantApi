﻿using MediatR;

namespace Restaurants.Application.Dishes.Commands.UpdateDish
{
    public class UpdateDishCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }

        public Guid RestaurantId { get; set; }
    }
}
