using MediatR;
using SimpleCQRS.Commands;
using SimpleCQRS.Models;
using SimpleCQRS.Services;

namespace SimpleCQRS.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,ProductModel>
    {
        private readonly ProductService productService;

        public AddProductHandler(ProductService productService)
        {
            this. productService = productService;
        }

        public async Task<ProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await productService.AddProduct(request.Product);
            return request.Product;
        }
    }
}
