using System;
using DungeonGame;

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

            if (player.AtExit(dungeon.Grid))
            {
                Console.WriteLine("\n🎉 You escaped the dungeon!");
                break;
            }

            Console.Write("\nMove (W/A/S/D): ");
            string input = Console.ReadLine().ToLower();

            if (input == "q")
            {
                Console.WriteLine("You gave up. Game over.");
                break;
            }

            if ("wasd".Contains(input))
            {
                player.Move(input, dungeon.Grid);
            }
            else
            {
                Console.WriteLine("Invalid input. Use W, A, S, D to move.");
                Console.ReadKey();
            }
        }
    }
}