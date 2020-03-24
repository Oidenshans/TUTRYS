using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
   public abstract class Shape
    {

        public int x;
        public int y;
        public int[,] matrix;
        private int copy;
        public  int sizematrix=3;



        public Shape(int _x, int _y)
        {
            x = _x;
            y = _y;
           
        }
                 
                  
        public void MoveDown()  // Изменение координаты у при движении вниз
        {
           
             y++;
            
        }

        public void MoveRight() // Изменение координаты x при движении вправо
        {                    
                   
             x++; 
            
        }

        public void MoveLeft()  // Изменение координаты x при движении влево
        {
                      
             x--;                  
                    
        }


        public void TurnArround() // Переворачивание фигуры
        {
            if (x>=0 && x<= 8 - sizematrix && y<= 15 - sizematrix)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        copy = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = copy;
                    }
                }
            }
            
        }

    }

    public class ShapeLine:Shape

    {
     
        public ShapeLine(int _x, int _y)  // Создание фигуры в виде Линии
            : base(_x, _y)
        {
            x = _x;
            y = _y;
            matrix = new int[3, 3]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 0, 0 },
            };


        }

    }


    public class ShapeZigZag : Shape

    {
    
        public ShapeZigZag(int _x, int _y) // Создание фигуры в виде Зигзага
            : base(_x, _y)
        {
            x = _x;
            y = _y;
            matrix = new int[3, 3]
            {
                { 0, 1, 0 },
                { 0, 1, 1 },
                { 0, 0, 1 },
            };


        }

    }
    public class ShapeRectangle : Shape  // Создание фигуры в виде Квадрата

    {
     
        public ShapeRectangle(int _x, int _y)
            : base(_x, _y)
        {
            x = _x;
            y = _y;
            matrix = new int[3, 3]
            {
                { 0, 1, 1 },
                { 0, 1, 1 },
                { 0, 0, 0 },
            };


        }

    }


    public class ShapeLtype : Shape    // Создание фигуры в виде буквы L

    {
    
        public ShapeLtype(int _x, int _y)
            : base(_x, _y)
        {
            x = _x;
            y = _y;
            matrix = new int[3, 3]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 1 },
            };

        }

    }


}
