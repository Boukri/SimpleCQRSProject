using MediatR;
using SimpleCQRS.Models;
using SimpleCQRS.Queries;
using SimpleCQRS.Services;

namespace SimpleCQRS.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly ProductService productService;

        public GetProductByIdHandler(ProductService productService)
        {
            this.productService = productService;
        }

        public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           return await productService.GetProductById(request.IdPRoduct);
        }
    }
}
