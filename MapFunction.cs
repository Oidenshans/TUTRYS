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
        private int size;
        private int[,] map;

        public MapFunction(int _size,int [,] _map)
        { 
            size = _size; 
            map = _map;  
        }


        public void DrawGrid(Graphics e)
        {
            for (int i = 0; i <= 16; i++)
            {

                e.DrawLine(Pens.Black, new Point(50, 50 + i * size), new Point(50 + 8 * size, 50 + i * size));

            }
            for (int i = 0; i <= 8; i++)
            {

                e.DrawLine(Pens.Black, new Point(50 + i * size, 50), new Point(50 + i * size, 50 + 16 * size));

            }
        }



        public void DrawMap(Graphics e)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i, j] == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                    }
                    if (map[i, j] == 2)
                    {
                        e.FillRectangle(Brushes.Green, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                    }
                }
            }
        }



    }
}
