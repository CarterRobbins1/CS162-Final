using System;
using System.Collections.Generic;
using DungeonGame;


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

    }
}