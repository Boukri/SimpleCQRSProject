using MediatR;
using SimpleCQRS.Models;
using SimpleCQRS.Queries;
using SimpleCQRS.Services;

namespace SimpleCQRS.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProdutsQuery, IEnumerable<ProductModel>>
    {
        private readonly ProductService productService;

        public GetProductHandler(ProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetProdutsQuery request, CancellationToken cancellationToken)
        {
            return await productService.GetAllPRoducts();
        }
    }
}
