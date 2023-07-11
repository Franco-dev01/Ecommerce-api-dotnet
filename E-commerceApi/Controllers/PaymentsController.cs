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
    public class PaymentsController : ControllerBase
    {


        private readonly ECommerceApiContext _context;

        public PaymentsController(ECommerceApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            var payments = await _context.Payments.ToListAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(int id)
        {
            var payment = await _context.Payments
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayments(Payment data)
        {

            _context.Payments.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPaymentById), new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DetelePayment(int id)
        {
            var findRecord = await _context.Payments.FindAsync(id);
            if (findRecord == null)
            {
                return NotFound();
            }
            _context.Payments.Remove(findRecord);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
