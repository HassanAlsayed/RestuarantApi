using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restuarant.Commands.CreateRertuarants;
using Restaurants.Application.Restuarant.Commands.DeleteRestuarant;
using Restaurants.Application.Restuarant.Commands.UpdateRestaurant;
using Restaurants.Application.Restuarant.Queries.GetAllRestuarants;
using Restaurants.Application.Restuarant.Queries.GetRestuarantById;
using Restaurnats.Domain.Additios;

namespace Restaurants.API.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestuarantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllRestuarants")]
        public async Task<IActionResult> GetAll(string? name,string? description, bool? orderByName,int page)
        {
           return Ok(await mediator.Send(new GetAllRestuarantsQuery()
           {
               Name = name,
               Description = description,
               sort = orderByName,
               Page = page
           }));
        }

        [HttpGet("GetRestuarant/{id}")]
        public async Task<IActionResult> GetRestuarantById(Guid id)
        {
            var restuarant = await mediator.Send(new GetRestuarantByIdQuery()
            {
                Id = id
            });
            if(restuarant is null)
            {
                return NotFound("No restuarant with given id");
            }
            return Ok(restuarant);
        }

        [HttpPost("AddRestuarant")]
        public async Task<IActionResult> AddRestuarant(CreateRestuarntCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Please check if every thing is good");
            }
            var id = await mediator.Send(command);
            return Created(nameof(GetRestuarantById), id);
        }
            
        [HttpDelete("DeleteRestuarant/{id}")]
        public async Task<IActionResult> DeleteRestuarant(Guid id)
        {
           
            await mediator.Send(new DeleteRestuarantCommand()
            {
                Id= id
            });
            return Ok($"Deleting Restaurant with id {id}");
        }

        [HttpPut("UpdateRestuarant/{id}")]
        public async Task<IActionResult> UpdateRestuarant(UpdateRestuarantCommand command,Guid id)
        {
            command.Id = id;
            await mediator.Send(command);
            return Ok($"Updateing Restaurant with id {id}");
        }

    }
}

