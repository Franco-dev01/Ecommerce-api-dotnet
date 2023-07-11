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
    public class AddressController : ControllerBase
    {
        private readonly ECommerceApiContext _context;

        public AddressController(ECommerceApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            var address = await _context.Address.ToListAsync();
            return Ok(address);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
            var product = await _context.Address
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address data)
        {

            _context.Address.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAddressById), new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleAddress(int id)
        {
            var findRecord = await _context.Address.FindAsync(id);
            if (findRecord == null)
            {
                return NotFound();
            }
            _context.Address.Remove(findRecord);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
