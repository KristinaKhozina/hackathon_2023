using Microsoft.AspNetCore.Mvc;
using ShootScares.API.Data;
using ShootScares.API.Models;

namespace ShootScares.API.Controllers
{
    [Route("api/leader-board")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly PlayersRepository playersRepository;
        private readonly GameResultsRepository gameResultsRepository;

        public LeaderBoardController(PlayersRepository playersRepository,
            GameResultsRepository gameResultsRepository)
        {
            this.playersRepository = playersRepository;
            this.gameResultsRepository = gameResultsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeaderBoardItem>> Get()
        {
            var leaderBoard = new List<LeaderBoardItem>();
            var topResults = gameResultsRepository.GetTopResults(5);
            foreach (var result in topResults)
            {
                var item = new LeaderBoardItem();
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
