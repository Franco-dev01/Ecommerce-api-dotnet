using E_commerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        private readonly ECommerceApiContext _context;

        public ProductsController(ECommerceApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreateProducts(Product data)
        {

            _context.Products.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductById), new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleProduct(int id)
        {
            var findRecord = await _context.Products.FindAsync(id);
            if (findRecord == null)
            {
                return NotFound();
            }
            _context.Products.Remove(findRecord);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
