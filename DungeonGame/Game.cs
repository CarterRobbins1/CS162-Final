using System;

namespace DungeonGame
{
    class Game
    {
        public static void Run()
        {
            Dungeon dungeon = new Dungeon();
            Delver player = new Delver(0, 0);

            Console.WriteLine("Welcome to the Dungeon!");
            Console.WriteLine("Use W (up), A (left), S (down), D (right) to move.");
            Console.WriteLine("Reach the 'E' to escape. Press 'Q' to quit.");

            while (true)
            {
                Console.Clear();
                dungeon.PrintWithPlayer(player);

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
                    break;
                }

                if (atExit && input == 'e')
                {
                    Console.WriteLine("\n🎉 You escaped the dungeon!");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
                }

                if ("wasd".Contains(input))
                {
                    player.Move(input.ToString(), dungeon.Grid);
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