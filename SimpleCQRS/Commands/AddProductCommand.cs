using MediatR;
using SimpleCQRS.Models;

namespace SimpleCQRS.Commands
{
    public record AddProductCommand(ProductModel Product): IRequest<ProductModel> ; 
}
