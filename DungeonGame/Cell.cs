//Simple class that acts as one cell in the dungeon grid.
// Each cell has walls on all four sides, a visited flag, and an exit flag.
using DungeonGame;
public class Cell
{
    public bool Top = true;
    public bool Left = true;
    public bool Bottom = true;
    public bool Right = true;
    public bool Visited = false;
    public bool IsExit = false;
}
