using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TUTRYS
{
    class MapFunction
    {
        private int Size { get; set; }
        private int[,] Map { get; set; }

        public MapFunction(int _size, int[,] _map) {
            Size = _size;
            Map = _map;
        }

        public void DrawGrid(Graphics e)
        {
            for (int y = 0; y <= 16; y++)
            {
                e.DrawLine(Pens.Black, new Point(50, 50 + y * Size), new Point(50 + 8 * Size, 50 + y * Size));
            }
            for (int x = 0; x <= 8; x++)
            {
                e.DrawLine(Pens.Black, new Point(50 + x * Size, 50), new Point(50 + x * Size, 50 + 16 * Size));
            }
        }

        public void DrawMap(Graphics e)
        {
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Map[y, x] == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(50 + x * (Size) + 1, 50 + y * (Size) + 1, Size - 1, Size - 1));
                    }
                    if (Map[y, x] == 2)
                    {
                        e.FillRectangle(Brushes.Green, new Rectangle(50 + x * (Size) + 1, 50 + y * (Size) + 1, Size - 1, Size - 1));
                    }
                }
            }
        }
    }
}
