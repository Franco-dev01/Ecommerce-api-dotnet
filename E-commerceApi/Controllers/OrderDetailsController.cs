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
    public class OrderDetailsController : ControllerBase
    {
        private readonly ECommerceApiContext _context;

        public OrderDetailsController(ECommerceApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            var orderdetails = await _context.Order_details.ToListAsync();
            return Ok(orderdetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetailById(int id)
        {
            var orderdetails = await _context.Order_details
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (orderdetails == null)
            {
                return NotFound();
            }

            return orderdetails;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetails>> CreateAddress(OrderDetails data)
        {

            _context.Order_details.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleOrderDetail(int id)
        {
            var findRecord = await _context.Order_details.FindAsync(id);
            if (findRecord == null)
            {
                return NotFound();
            }
            _context.Order_details.Remove(findRecord);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
