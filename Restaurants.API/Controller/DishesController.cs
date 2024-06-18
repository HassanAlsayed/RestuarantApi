using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDish;
using Restaurants.Application.Dishes.Commands.UpdateDish;
using Restaurants.Application.Dishes.Queries.GetAllDishes;
using Restaurants.Application.Dishes.Queries.GetDishById;

namespace Restaurants.API.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]

    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost("AddDish/{RestuarantId}")]
        public async Task<IActionResult> CreateDish(CreateDishCommand command,Guid RestuarantId)
        {
            command.RestaurantId = RestuarantId;
            return Created(nameof(GetDishById),await mediator.Send(command));
        }

        [HttpPut("UpdateDish/{id}")]
        public async Task<IActionResult> UpdateDish(UpdateDishCommand command,Guid id)
        {
            command.Id = id;
            await mediator.Send(command);
            return Ok($"Updateing dish with id {id}");
        }
        [HttpDelete("DeleteDish/{id}")]
        public async Task<IActionResult> DeleteDish(Guid id)
        {
            return Ok(await mediator.Send(new DeleteDishCommand()
            {
                Id = id
            }));
        }
        [HttpGet("GetDishById/{id}")]
        public async Task<IActionResult> GetDishById(Guid id)
        {
           var dish = await mediator.Send(new GetDishByIdQuery()
            {
                Id = id
            });
            if(dish is null)
            {
                return NotFound("no dish with given id");
            }
            return Ok(dish);
        }
        [HttpGet("GetAllDiches")]
        public async Task<IActionResult> GetAllDiches()
        {
            return Ok(await mediator.Send(new GetAllDishesQuery()));
        }


    }
}
