using Microsoft.AspNetCore.Mvc;
using ShootScares.API.Data;
using ShootScares.API.Models;

namespace ShootScares.API.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly PlayersRepository playersRepository;
        private readonly GameResultsRepository gameResultsRepository;

        public LeaderboardController(PlayersRepository playersRepository,
            GameResultsRepository gameResultsRepository)
        {
            this.playersRepository = playersRepository;
            this.gameResultsRepository = gameResultsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeaderboardItem>> Get()
        {
            var leaderBoard = new List<LeaderboardItem>();
            var topResults = gameResultsRepository.GetTopResults(5);
            foreach (var result in topResults)
            {
                var item = new LeaderboardItem();
                item.Username = playersRepository
                    .Get(result.PlayerId)
                    .FirstOrDefault()!
                    .Name;
                item.Score = result.Score;
                item.Date = result.Date.ToString("HH:mm dd/MM/yy");
                leaderBoard.Add(item);
            }
            return Ok(leaderBoard);
        }
    }
}
