//Name: Carter Robbins Date: 6/13/25
using System;


namespace DungeonGame
{
    public class Delver // Represents the player character in the dungeon game
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        // Constructor to initialize the delver's position
        public Delver(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void Move(string direction, Cell[,] grid)
        {
            int newX = X;
            int newY = Y;

            switch (direction.ToLower()) // Handle case insensitivity for direction input
            {
                case "w":
                    if (!grid[X, Y].Top) newY--; // Move up if no wall
                    break;
                case "s":
                    if (!grid[X, Y].Bottom) newY++; // Move down if no wall
                    break;
                case "a":
                    if (!grid[X, Y].Left) newX--; // Move left if no wall
                    break;
                case "d":
                    if (!grid[X, Y].Right) newX++; // Move right if no wall
                    break;
            }

            // Only move if inside bounds
            if (newX >= 0 && newX < Dungeon.Size && newY >= 0 && newY < Dungeon.Size)
            {
                X = newX;
                Y = newY;
            }
        }
        // Check if the delver is at the exit cell
        public bool AtExit(Cell[,] grid)
        {
            return grid[X, Y].IsExit;
        }

    }
}
