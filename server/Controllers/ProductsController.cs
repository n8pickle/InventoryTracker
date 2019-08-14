using Microsoft.AspNetCore.Mvc;

namespace server.controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller 
    {
        public ProductsController()
        {

        }

        [HttpGet]
        public IActionResult GetProducts() 
        {
            return Ok("product");
        }

    }
}