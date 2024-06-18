using MediatR;

namespace Restaurants.Application.Restuarant.Commands.DeleteRestuarant
{
    public class DeleteRestuarantCommand : IRequest<Guid>
    {
        public Guid Id { get; init; }
    }
}
