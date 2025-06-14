using System;

namespace DungeonGame
{
    class Game
    {
        public static void Run()
        {
            Dungeon dungeon = new Dungeon();
            Delver player = new Delver(0, 0);
            Points points = new Points();
            Random rand = new Random();

            List<Monster> monsters = new List<Monster>
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

            while (true)
            {
                Console.Clear();
                dungeon.PrintWithPlayer(player);
                Console.WriteLine($"Points: {points.GetScore()}");

                bool atExit = player.AtExit(dungeon.Grid);

                if (atExit)
                {
                    Console.WriteLine("\nYou are standing on the exit tile.");
                    Console.Write("Press 'E' to escape or W/A/S/D to keep exploring: ");
                }
                else
                {
                    Console.Write("\nMove (W/A/S/D): ");
                }

                char input = Char.ToLower(Console.ReadKey(true).KeyChar);

                if (input == 'q')
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

                if ("wasd".Contains(input))
                {
                    player.Move(input.ToString(), dungeon.Grid);
                    points.Deduct();

                    if (monsters.Count > 0 && rand.Next(0, 4) == 0)
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