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
    public class UsersController : ControllerBase
    {

        private readonly ECommerceApiContext _context;
        public UsersController(ECommerceApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUsers(User data)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);

            data.Password = hashedPassword;

            _context.Users.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleUsers(int id)
        {
            var findRecord = await _context.Users.FindAsync(id);
            if (findRecord == null)
            {
                return NotFound();
            }
            _context.Users.Remove(findRecord);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
