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
    public class OrdersController : ControllerBase
    {

        private readonly ECommerceApiContext _context;

        public OrdersController(ECommerceApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _context.Orders
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateUsers(Order data)
        {

            _context.Orders.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderById), new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleOrder(int id)
        {
            var findRecord = await _context.Orders.FindAsync(id);
            if (findRecord == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(findRecord);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
