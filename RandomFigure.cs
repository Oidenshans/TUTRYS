using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
    class RandomFigure
    {
        public static Shape GetRandomFigure()
        {
            Random rnd = new Random();
            int FigureType = rnd.Next(0, 4);
            Shape currentShape = null;

            switch (FigureType)
            {
                case 0:
                    currentShape = new ShapeLine(2, 0);
                    break;

                case 1:
                    currentShape = new ShapeZigZag(2, 0);
                    break;

                case 2:
                    currentShape = new ShapeRectangle(2, 0);
                    break;

                case 3:
                    currentShape = new ShapeLtype(2, 0);
                    break;

            }
            return currentShape;
        }
    }



}

