using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class AppUserController : ControllerBase
    {
        private readonly DataContext _context;

        public AppUserController(DataContext context)
        {
            _context = context;
        }

        // private readonly ILogger<AppUserController> _logger;
        //  public AppUserController(ILogger<AppUserController> logger)
        //  {
        //      _logger = logger;
        //  }
         [EnableCors("AllowOrigin")]
         [HttpGet]
        public IEnumerable<AppUser> Getall()
        {
            return _context.AppUsers;
        }
       [HttpGet("{id}")]
        public async Task<IActionResult> Getall([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.AppUsers.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserData([FromBody] AppUser users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppUsers.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getall", new { id = users.Id }, users);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserDetails([FromRoute] int id, [FromBody] AppUser users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!userTblExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool userTblExist(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usr = await _context.AppUsers.FindAsync(id);
            if (usr == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(usr);
            await _context.SaveChangesAsync();

            return Ok(usr);
        }
        
    }
}
