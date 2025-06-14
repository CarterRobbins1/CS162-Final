using System;


namespace DungeonGame
{
    public class Monster
    {
        public string Name { get; }
        public int Points { get; }
        public int RequiredRoll { get; }

        public Monster(string name, int points, int requiredRoll)
        {
            Name = name;
            Points = points;
            RequiredRoll = requiredRoll;
        }

        public bool AttemptDefeat(Random random)
        {
            int roll = random.Next(1, 21); // Simulate a d20 roll
            Console.WriteLine($"You encountered a {Name}! Rolling to defeat... You rolled a {roll}.");
            return roll > RequiredRoll;
        }
    }
}
