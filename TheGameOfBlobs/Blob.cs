using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TheGameOfBlobs
{
    internal class Blob
    {
        internal enum Direction
        {
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW,
            NoMovement
        }

        internal string Name { get; set; }

        internal Point Position { get; set; }
        internal int Size { get; set; }
        internal Direction NearestPreyDirection { get; set; }

        internal Blob(int x, int y, int size)
        {
            Position = new Point(x, y);
            Size = size;
        }

        internal void MoveToPrey(Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    Position = new Point(Position.X, Position.Y + 1);
                    break;

                case Direction.NE:
                    Position = new Point(Position.X + 1, Position.Y + 1);
                    break;

                case Direction.E:
                    Position = new Point(Position.X + 1, Position.Y);
                    break;

                case Direction.SE:
                    Position = new Point(Position.X + 1, Position.Y - 1);
                    break;

                case Direction.S:
                    Position = new Point(Position.X, Position.Y - 1);
                    break;

                case Direction.SW:
                    Position = new Point(Position.X - 1, Position.Y - 1);
                    break;

                case Direction.W:
                    Position = new Point(Position.X - 1, Position.Y);
                    break;

                case Direction.NW:
                    Position = new Point(Position.X - 1, Position.Y + 1);
                    break;

                default:
                    break;
            }
        }

        internal void Engulf(Blob prey)
        {
            Size += prey.Size;
        }
    }
}
