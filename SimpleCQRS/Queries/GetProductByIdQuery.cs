using MediatR;
using SimpleCQRS.Models;

namespace SimpleCQRS.Queries
{
    public record GetProductByIdQuery(int IdPRoduct):IRequest<ProductModel>;
}
