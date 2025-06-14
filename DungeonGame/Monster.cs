//Name: Carter Robbins Date: 6/13/25
using System;


namespace DungeonGame
{
    public class Monster
    {
        // Represents a monster in the dungeon game with properties for its name, points, and required roll to defeat it.
        public string Name { get; }
        public int Points { get; }
        public int RequiredRoll { get; }

        public Monster(string name, int points, int requiredRoll) // Constructor to initialize the monster's properties
        {
            Name = name;
            Points = points;
            RequiredRoll = requiredRoll;
        }

        public bool AttemptDefeat(Random random) // Attempts to defeat the monster by rolling a d20
        {
            int roll = random.Next(1, 21); // Simulate a d20 roll
            Console.WriteLine($"You encountered a {Name}! Rolling to defeat... You rolled a {roll}.");
            return roll > RequiredRoll;
        }
    }
}
