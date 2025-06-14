using System;
using System.Collections.Generic;


public class Dungeon
{
    public const int Size = 10;
    public Cell[,] Grid { get; private set; }
    private Random rand = new Random();

    public Dungeon()
    {
        Grid = new Cell[Size, Size];
        InitializeGrid();
        GenerateMaze(0, 0);
        Grid[Size - 1, Size - 1].IsExit = true;
    }

    private void InitializeGrid()
    {
        for (int y = 0; y < Size; y++)
            for (int x = 0; x < Size; x++)
                Grid[x, y] = new Cell();
    }

    private void GenerateMaze(int x, int y)
    {
        Grid[x, y].Visited = true;
        var directions = new List<(int dx, int dy)>
        {
            (0, -1), (1, 0), (0, 1), (-1, 0)
        };
        directions.Sort((a, b) => rand.Next(-1, 2)); // shuffle directions randomly

        foreach (var (dx, dy) in directions)
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
}