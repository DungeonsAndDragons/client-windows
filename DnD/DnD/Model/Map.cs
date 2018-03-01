using System.Collections.Generic;

namespace DnD.Model
{
    public enum MapType
    {
        Hex,
        Rect
    }

    public class Map
    {
        public MapType Type { get; set; }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        private Dictionary<Point, int> Data = new Dictionary<Point, int>();

        public void SetData(int x, int y, int data)
        {
            Data[new Point(x, y)] = data;
        }

        public int GetData(int x, int y)
        {
            return Data[new Point(x, y)];
        }

        private struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override int GetHashCode()
            {
                return X + Y;
            }

            public override bool Equals(object obj)
            {
                if (obj is Point point)
                {
                    return point.X == X && point.Y == Y;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}