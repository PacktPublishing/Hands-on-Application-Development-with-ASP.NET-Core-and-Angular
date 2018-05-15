using FoodPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodPos.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly MyDbContext context;
        public ProductsController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = context.Products.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveProducts([FromBody] Product product)
        {
            context.Products.Add(product);
            var result = context.SaveChanges();
            return Accepted(result);
        }


    }
}