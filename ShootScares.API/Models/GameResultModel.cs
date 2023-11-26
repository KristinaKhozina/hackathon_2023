using ShootScares.API.Domain.Entities;

namespace ShootScares.API.Models
{
    public class GameResultModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public string Date { get; set; } = string.Empty;

        public static explicit operator GameResultModel(GameResult result)
        {
            return new GameResultModel
            {
                Id = result.Id,
                PlayerId = result.PlayerId,
                Score = result.Score,
                Date = result.Date.ToString("HH:mm dd/MM/yy")
            };
        }
    }
}
