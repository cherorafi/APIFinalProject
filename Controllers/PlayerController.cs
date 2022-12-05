using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly WebAPIDBContext _context;

        // GET: api/Customer
        public PlayerController(WebAPIDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer(string username)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.Where(e => e.username == username).ToListAsync();
        }

        [HttpGet("location/{last_location}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerLoc(string last_location)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.Where(e => e.last_location == last_location).ToListAsync();
        }

        [HttpGet("level/{player_level}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerLevel(int player_level)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.Where(e => e.player_level == player_level).ToListAsync();
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerName(string name)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            return await _context.Players.Where(e => e.name == name).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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
            response.statusDescription = "Updated player info";

            return Ok(response);
        }

        private bool PlayerExists(int id)
        {
            return (_context.Players?.Any(e => e.id == id)).GetValueOrDefault();
        }

        [HttpPatch("level/{id}")]
        public async Task<IActionResult> UpdatePlayerLevel(int id, [FromBody] int level)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            player.player_level = level;
            await _context.SaveChangesAsync();

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Updated player level";

            return Ok(response);
        }

        [HttpPatch("name/{id}")]
        public async Task<IActionResult> UpdatePlayerName(int id, [FromBody] string name)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            player.name = name;
            await _context.SaveChangesAsync();

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Updated player name";

            return Ok(response);
        }

        [HttpPatch("location/{id}")]
        public async Task<IActionResult> UpdatePlayerLocation(int id, [FromBody] string last_location)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            player.last_location = last_location;
            await _context.SaveChangesAsync();

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Updated player location";

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<Player>> PostAccount(Player player)
        {
            if (_context.Players == null)
            {
                return Problem("Entity set 'MyApiDBContext.Players'  is null.");
            }

            _context.Players.Add(player);
            var username = player.username;
            var account = await _context.Accounts.FirstOrDefaultAsync(e => e.username == username);
            account.number_of_characters++;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPlayer", new { id = player.id }, player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (!PlayerExists(id))
            {
                return NotFound();
            }
            var player = await _context.Players.FirstOrDefaultAsync(e => e.id == id);
            var username = player.username;
            var account = await _context.Accounts.FirstOrDefaultAsync(e => e.username == username);

            _context.Players.Remove(player);
            account.number_of_characters--;

            await _context.SaveChangesAsync();

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Deleted player";

            return Ok(response);
        }
    }
}
