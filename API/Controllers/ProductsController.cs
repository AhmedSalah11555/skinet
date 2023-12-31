using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using core.Entities;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = context.Products.ToList();
            return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id)
        {

            var producs = await context.Products.FindAsync(id);
            return Ok(producs);

        }
    }
}