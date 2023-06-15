using MediatR;
using SimpleCQRS.Models;

namespace SimpleCQRS.Queries
{
    public record GetProdutsQuery:IRequest<IEnumerable<ProductModel>>
    {

    }
}
