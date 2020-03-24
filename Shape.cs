using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
    public abstract class Shape
    {

        public const int SizeMatrix = 3;
        public int X { get; set; }
        public int Y { get; set; }
        public int[,] Matrix { get; set;  }

        public Shape(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public void MoveDown()
        {
            Y++;
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
        }

        public void TurnArround()
        {
            if (X >= 0 && X <= 8 - SizeMatrix && Y <= 15 - SizeMatrix)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < x; y++)
                    {
                        int copy = Matrix[x, y];
                        Matrix[x, y] = Matrix[y, x];
                        Matrix[y, x] = copy;
                    }
                }
            }
        }
    }
}
