
namespace DungeonGame
{
    public class Points
    {
        private int score;

        public Points()
        {
            score = 100;
        }

        public void Deduct(int amount=1)
        {
            score -= amount;
            if (score < 0) score = 0; // Ensure score doesn't go negative
        }

        public void Add(int amount)
        {
            score += amount;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
