#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Games_Genres.Data;
using API_Games_Genres.Models;
using API_Games_Genres.ViewModels;

namespace API_Games_Genres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // GET: api/Teams/Czech Republic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsFrom(string country)
        {
            var teams = await _context.Teams.ToListAsync();

            if (country == null)
            {
                return BadRequest();
            }

            return teams.Where(t => t.Place == country).ToList();
        }

        // GET: api/Teams/2/Players
        [HttpGet("{id}/Players")]
        public async Task<ActionResult<IEnumerable<Team>>> GetPlayersFromTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound("team does not exist");
            }
            _context.Entry(team).Collection(c => c.Players).Load();

            return Ok(team.Players);
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        /*[HttpPost("{id}/Players/{PlayerId}")]*/
        [HttpPost("{id}/Players/{PlayerId}")]
        public async Task<ActionResult> AddPlayerToTeam(int id, [FromBody] IdVM pl)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound("team does not exists");
            }
            var player = await _context.Players.FindAsync(pl.Id);

            if (player == null)
            {
                return NotFound("player does not exists");
            }

            var playerTeam =
                await _context.Players.Where(s => s.PlayerId == pl.Id && s.TeamId == id).SingleOrDefaultAsync();
            if (playerTeam == null)
            {
                player.TeamId = id;
                await _context.SaveChangesAsync();
                return Ok(player);
            }
            else
            {
                return NoContent();
            }
        }

        /*[HttpDelete("{id}/Players/{PlayerId}")]*/
        [HttpDelete("{id}/Players/{PlayerId}")]
        public async Task<ActionResult> RemovePlayerFromTeam(int id, int plId)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound("team does not exists");
            }
            var player = await _context.Players.FindAsync(plId);

            if (player == null)
            {
                return NotFound("player does not exists");
            }

            var playerTeam =
                await _context.Players.Where(s => s.PlayerId == plId && s.TeamId == id).SingleOrDefaultAsync();
            if (playerTeam == null)
            {
                return BadRequest();
            }
            else
            {
                player.TeamId = null;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        // PUT: api/Players/5  
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/UpdateMoneyWon")]
        public async Task<IActionResult> UpdateMoneyWon(int id, int amount)
        {
            var team = await _context.Teams.FindAsync(id);

            if (amount > team.MoneyWon) { team.MoneyWon = amount; } else { return BadRequest(/*$"Your amount isn´t bigger than {team.MoneyWon}"*/); }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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


        // GET: api/Teams/count
        [HttpGet("/count")]
        public async Task<IActionResult> GetNumberOfTeams()
        {
            var count = await _context.Teams.ToArrayAsync();

            return Ok(count.Length);
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
