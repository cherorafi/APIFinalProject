using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly WebAPIDBContext _context;

        // GET: api/Customer
        public AccountController(WebAPIDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            return await _context.Accounts.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Account>> GetAccount(string username)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(username);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpGet("violations")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountViolations()
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            return await _context.Accounts.Where(e => e.violations == true).ToListAsync();
        }

        [HttpGet("player/{id}")]
        public async Task<ActionResult<Account>> GetAccountPlayer(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }
            var username = player.username;

            return await _context.Accounts.FindAsync(username);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> PutAccount(string username, Account account)
        {
            if (username != account.username)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Updated account info";

            return Ok(response);
        }

        private bool AccountExists(string username)
        {
            return (_context.Accounts?.Any(e => e.username == username)).GetValueOrDefault();
        }

        [HttpPatch("violations/{username}")]
        public async Task<IActionResult> UpdateAccountViolations(string username, [FromBody] bool violations)
        {
            var account = await _context.Accounts.FindAsync(username);
            if (account == null)
            {
                return NotFound();
            }
            account.violations = violations;
            await _context.SaveChangesAsync();

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Updated account violations";

            return Ok(response);
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'MyApiDBContext.Accounts'  is null.");
            }

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { username = account.username }, account);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            var response = new Response();
            if (!AccountExists(username))
            {
                return NotFound();
            }
            
            var account = await _context.Accounts.FirstOrDefaultAsync(e => e.username == username);

            if (account.number_of_characters != 0)
            {
                response.statusCode = 400;
                response.statusDescription = "Account has active players. Please delete players belong to account first";
                return Ok(response);
            }
    
            _context.Accounts.Remove(account);


            await _context.SaveChangesAsync();

            response.statusCode = 200;
            response.statusDescription = "Deleted account";

            return Ok(response);
        }
    }
}
