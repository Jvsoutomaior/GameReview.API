namespace GameReview.API.Models
{
    public class Review
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }

    }
}
