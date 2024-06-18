using MediatR;
using Restaurants.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restuarant.Queries.GetRestuarantById
{
    public class GetRestuarantByIdQuery : IRequest<RestuarantDtos?>
    {
        // use init instead of adding constructor and initiaze it
        public Guid Id { get; init; }
    }
}
