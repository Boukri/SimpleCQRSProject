using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.Commands;
using SimpleCQRS.Handlers;
using SimpleCQRS.Models;
using SimpleCQRS.Notifications;
using SimpleCQRS.Queries;

namespace SimpleCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender sender;
        private readonly IPublisher publisher;

        public ProductsController(IPublisher publisher, ISender sender)
        {
            this.publisher = publisher;
            this.sender = sender;
        } 
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await sender.Send(new GetProdutsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts([FromBody] ProductModel product)
        {
           var addedProduct = await sender.Send(new AddProductCommand(product));
            await publisher.Publish(new ProductAddNotification(addedProduct));
            return Ok(addedProduct);
        }
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var addedProduct = await sender.Send(new GetProductByIdQuery(id));
            return CreatedAtRoute("GetProductById", new { id = addedProduct.Id }, addedProduct);
        }
    }
}
