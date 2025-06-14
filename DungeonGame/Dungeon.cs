//Name: Carter Robbins Date: 6/13/25
using System;
using System.Collections.Generic;


namespace DungeonGame
{
    public class Dungeon
    {
        public const int Size = 10; // Size of the dungeon grid
        public Cell[,] Grid { get; private set; }
        private Random rand = new Random();

        public Dungeon() // Constructor to initialize the dungeon grid and generate the maze
        {
            Grid = new Cell[Size, Size];
            InitializeGrid();
            GenerateMaze(0, 0);
            Grid[Size - 1, Size - 1].IsExit = true;
        }

        private void InitializeGrid() // Initializes the dungeon grid with cells
        { 
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    Grid[x, y] = new Cell();
        }

        private void GenerateMaze(int x, int y) // Recursive method to generate the maze using a randomized depth-first search algorithm
        {
            Grid[x, y].Visited = true;
            var directions = new List<(int dx, int dy)> 
        {
            (0, -1), (1, 0), (0, 1), (-1, 0)
        };
            directions.Sort((a, b) => rand.Next(-1, 2)); // shuffle directions randomly

            foreach (var (dx, dy) in directions) // Iterate through each direction
            {
                int nx = x + dx;
                int ny = y + dy;

                if (nx >= 0 && ny >= 0 && nx < Size && ny < Size && !Grid[nx, ny].Visited)
                {
                    // Remove walls between current and neighbor
                    if (dx == 1) { Grid[x, y].Right = false; Grid[nx, ny].Left = false; }
                    if (dx == -1) { Grid[x, y].Left = false; Grid[nx, ny].Right = false; }
                    if (dy == 1) { Grid[x, y].Bottom = false; Grid[nx, ny].Top = false; }
                    if (dy == -1) { Grid[x, y].Top = false; Grid[nx, ny].Bottom = false; }

                    GenerateMaze(nx, ny);
                }
            }
        }

        public void PrintWithPlayer(Delver player)
        {
            for (int y = 0; y < Size; y++)
            {
                // Top walls
                for (int x = 0; x < Size; x++)
                {
                    Console.Write("+");
                    Console.Write(Grid[x, y].Top ? "---" : "   ");
                }
                Console.WriteLine("+");

                // Side walls and player/exit
                for (int x = 0; x < Size; x++)
                {
                    Console.Write(Grid[x, y].Left ? "|" : " ");
                    if (player.X == x && player.Y == y)
                        Console.Write(" P ");
                    else if (Grid[x, y].IsExit)
                        Console.Write(" E ");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine("|");
            }

            // Bottom walls
            for (int x = 0; x < Size; x++)
            {
                Console.Write("+");
                Console.Write(Grid[x, Size - 1].Bottom ? "---" : "   ");
            }
            Console.WriteLine("+");
        }


    }
}