using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JupiterTask.Entites;
using System.Linq;
using System.Threading.Tasks;
using JupiterTask.Data;
using JupiterTask.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace JupiterTask.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminScoresController : ControllerBase
    {
        private readonly StoreContext _context;

        public AdminScoresController(StoreContext context)
        {
            _context = context;
        }

        #region Update Score By TeamId
        [HttpPut("update-score/{teamId}")]
        public async Task<IActionResult> UpdateScore(int teamId, [FromBody] UpdateScoreDTO request)
        {
            var teamScores = await _context.Scores.Where(s => s.TeamId == teamId).ToListAsync();
            if (teamScores == null || !teamScores.Any())
            {
                return NotFound($"No scores found for team {teamId}.");
            }

            foreach (var score in teamScores)
            {
                score.Value = request.Value;  
                _context.Entry(score).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return Ok(teamScores); 
        }
        #endregion

        #region Reset Score By TeamId
        [HttpPut("reset-score/{teamId}")]
        public async Task<IActionResult> ResetScore(int teamId)
        {
            var teamScores = await _context.Scores.Where(s => s.TeamId == teamId).ToListAsync();
            if (teamScores == null || !teamScores.Any())
            {
                return NotFound($"No scores found for team {teamId}.");
            }

            foreach (var score in teamScores)
            {
                score.Value = 0;  
                _context.Entry(score).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return Ok(teamScores); 
        }

        #endregion

        #region Get Score By TeameId
        [HttpGet("team/{teamId}/scores")]
        public async Task<IActionResult> GetTeamScores(int teamId)
        {
            var scores = await _context.Scores
                .Where(s => s.TeamId == teamId)
                .Select(s => new
                {
                    ScoreId = s.Id,
                    Value = s.Value
                })
                .ToListAsync();

            if (scores == null || !scores.Any())
            {
                return NotFound($"No scores found for team {teamId}");
            }

            return Ok(scores);
        }
        #endregion
    }
}
