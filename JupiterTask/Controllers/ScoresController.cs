using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JupiterTask.Entites;
using System.Linq;
using System.Threading.Tasks;
using JupiterTask.Data;

namespace JupiterTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly StoreContext _context;

        public ScoresController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetTeamsAndScoresByCategory(int categoryId)
        {

            var teams = await _context.Teams
                .Where(t => t.CategoryId == categoryId)
                .Select(t => new
                {
                    TeamName = t.Name,
                    Scores = t.Scores.Select(s => s.Value).ToList()
                })
                .ToListAsync();


            if (teams == null || !teams.Any())
            {
                return NotFound($"No teams found for category {categoryId}");
            }

            return Ok(teams);
        }
    }
}
