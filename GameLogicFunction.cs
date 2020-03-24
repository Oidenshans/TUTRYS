using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
    class GameLogicFunction
    {
        private Shape CurrentShape { get; }
        private int[,] Map { get; }
        public GameLogicFunction(Shape _currentShape, int[,] _map)
        {
            CurrentShape = _currentShape;
            Map = _map;
        }


        public void Merge()
        {
            for (int y = CurrentShape.Y; y < CurrentShape.Y + Shape.SizeMatrix; y++)
            {
                for (int x = CurrentShape.X; x < CurrentShape.X + Shape.SizeMatrix; x++)
                {
                    if (CurrentShape.Matrix[y - CurrentShape.Y, x - CurrentShape.X] != 0)
                    {
                        Map[y, x] = CurrentShape.Matrix[y - CurrentShape.Y, x - CurrentShape.X];
                    }

                }
            }
        }

        public void ResetArea()
        {
            for (int y = CurrentShape.Y; y < CurrentShape.Y + Shape.SizeMatrix; y++)
            {
                for (int x = CurrentShape.X; x < CurrentShape.X + Shape.SizeMatrix; x++)
                {
                    if (y >= 0 && x >= 0 && y < 16 && x < 8)
                    {
                        if (CurrentShape.Matrix[y - CurrentShape.Y, x - CurrentShape.X] != 0)
                        {
                            Map[y, x] = 0;
                        }
                    }
                }
            }
        }

        public int CheckWall()
        {
            for (int y = CurrentShape.Y; y < CurrentShape.Y + Shape.SizeMatrix; y++)
            {
                for (int x = CurrentShape.X; x < CurrentShape.X + Shape.SizeMatrix; x++)
                {
                    if (CurrentShape.Matrix[y - CurrentShape.Y, x - CurrentShape.X] != 0)
                    {
                        if (y + 1 == 16 || Map[y + 1, x] != 0)
                        {
                            return 1;
                        }
                    }
                }
            }

            return 0;
        }

        public int CheckWall(int d)
        {
            for (int y = CurrentShape.Y; y < CurrentShape.Y + Shape.SizeMatrix; y++)
            {
                for (int x = CurrentShape.X; x < CurrentShape.X + Shape.SizeMatrix; x++)
                {
                    if (CurrentShape.Matrix[y - CurrentShape.Y, x - CurrentShape.X] != 0)
                    {

                        if (x + 1 * d == 8 || x + 1 * d < 0)
                        {
                            return 1;
                        }

                        if (Map[y, x + 1 * d] != 0 || Map[y, x + 1 * d] != 0)
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        public void ChangeColor()
        {
            for (int y = CurrentShape.Y; y < CurrentShape.Y + Shape.SizeMatrix; y++)
            {
                for (int x = CurrentShape.X; x < CurrentShape.X + Shape.SizeMatrix; x++)
                {
                    if (CurrentShape.Matrix[y - CurrentShape.Y, x - CurrentShape.X] != 0)
                    {
                        Map[y, x] = 2;
                    }
                }
            }
        }
    }
}
