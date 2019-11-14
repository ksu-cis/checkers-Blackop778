using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Draughts
{
    public enum Color
    {
        Red,
        Black
    }

    public struct Coordinates
    {
        public int X;
        public int Y;

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Checker
    {
        public Color Color { get; protected set; }
        public bool King { get; set; }
        public Coordinates Coords { get; set; }

        public Checker(Color color, int x, int y, bool king = false)
        {
            Color = color;
            Coords = new Coordinates(x, y);
            King = king;
        }
    }
}
