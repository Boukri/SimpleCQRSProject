using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.Models;
using SimpleCQRS.Queries;

namespace SimpleCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender sender;

        public ProductsController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await sender.Send(new GetProdutsQuery()));
        }
       
    }
}
