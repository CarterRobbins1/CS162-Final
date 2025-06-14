using System;


namespace DungeonGame
{
    public class Delver
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Delver(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }
        public void Move(int dx, int dy, Dungeon dungeon)
        {

        }

    }
}
