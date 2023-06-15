using SimpleCQRS.Models;

namespace SimpleCQRS.Services
{
    public class ProductService
    {
        private static List<ProductModel> _products;
        public ProductService()
        {
            _products = new List<ProductModel>()
            {
                new ProductModel{ Id=1, Name = "KeySky Keyboard"},
                new ProductModel{ Id=2, Name = "Spirit of Games Mouse"},
                new ProductModel{ Id=3, Name = "Game Note Head set"},
                new ProductModel{ Id=4, Name = "Samsung Monitor"},
            };
        }
        public async Task AddProduct(ProductModel product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<ProductModel>> GetAllPRoducts()=> await Task.FromResult(_products);
       
    }
}
 
