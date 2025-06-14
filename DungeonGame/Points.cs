//Name: Carter Robbins Date: 6/13/25
namespace DungeonGame
{
    public class Points
    {
        private int score;

        public Points() // Constructor to initialize the score
        {
            score = 100;
        }

        public void Deduct(int amount=1)
        {
            score -= amount;
            if (score < 0) score = 0; // Ensure score doesn't go negative
        }

        public void Add(int amount) // Adds points to the score
        {
            score += amount; 
        }

        public int GetScore() // Returns the current score
        {
            return score;
        }
    }
}
