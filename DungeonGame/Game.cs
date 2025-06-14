//Name: Carter Robbins Date: 6/13/25
using System;

namespace DungeonGame
{
    class Game // Main game class that runs the dungeon exploration game
    {
        public static void Run()
        {
            Dungeon dungeon = new Dungeon(); // Initializes the dungeon
            Delver player = new Delver(0, 0); // Creates the player at the starting position (0, 0)
            Points points = new Points(); // Initializes the points system
            Random rand = new Random(); // Random number generator for monster encounters

            List<Monster> monsters = new List<Monster> //Creates a list of monsters
            {
                new Monster("Goblin", 10, 5),
                new Monster("Goblin", 10, 5),
                new Monster("Goblin", 10, 5),
                new Monster("Goblin", 10, 5),
                new Monster("Goblin", 10, 5),
                new Monster("Slime", 50, 10),
                new Monster("Slime", 50, 10),
                new Monster("Slime", 50, 10),
                new Monster("Ogre", 100, 15)
            };

            Console.WriteLine("Welcome to the Dungeon!");
            Console.WriteLine("Use W (up), A (left), S (down), D (right) to move.");
            Console.WriteLine("Reach the 'E' to escape. Press 'Q' to quit.");

            while (true) // Main game loop
            {
                Console.Clear(); // Clear the console for each turn
                dungeon.PrintWithPlayer(player);
                Console.WriteLine($"Points: {points.GetScore()}");

                bool atExit = player.AtExit(dungeon.Grid);

                if (atExit) // Check if the player is on the exit tile
                {
                    Console.WriteLine("\nYou are standing on the exit tile.");
                    Console.Write("Press 'E' to escape or W/A/S/D to keep exploring: ");
                }
                else // If not at exit, prompt for movement
                {
                    Console.Write("\nMove (W/A/S/D): ");
                }

                char input = Char.ToLower(Console.ReadKey(true).KeyChar);

                if (input == 'q') // Quit the game
                {
                    Console.WriteLine("You gave up. Game over.");
                    Console.WriteLine($"Final Score: {points.GetScore()}");
                    break;
                }

                if (atExit && input == 'e')
                {
                    Console.WriteLine("\nYou escaped the dungeon!");
                    Console.WriteLine($"Final Score: {points.GetScore()}");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
                }

                if ("wasd".Contains(input)) // Check if input is a valid movement command
                {
                    player.Move(input.ToString(), dungeon.Grid);
                    points.Deduct();

                    if (monsters.Count > 0 && rand.Next(0, 4) == 0) // 25% chance of encountering a monster
                    {
                        int index = rand.Next(monsters.Count);
                        Monster encounter = monsters[index];

                        if (encounter.AttemptDefeat(rand))
                        {
                            Console.WriteLine($"You defeated the {encounter.Name}! +{encounter.Points} points.");
                            points.Add(encounter.Points);
                            monsters.RemoveAt(index);
                        }
                        else
                        {
                            Console.WriteLine($"The {encounter.Name} defeated you. No points gained.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Use W, A, S, D to move.");
                    Console.ReadKey();
                }
            }
        }
    }
}