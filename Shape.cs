using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
   public abstract class Shape
    {


        public int X { get; set; }
        public int Y { get; set; }
        public int[,] matrix;
        private int copy;
        public  int sizeMatrix=3;



        public Shape(int _x, int _y)
        {
            X = _x;
            Y = _y;
           
        }
                 
                  
        public void MoveDown()  // Изменение координаты у при движении вниз
        {
           
             Y++;
            
        }

        public void MoveRight() // Изменение координаты x при движении вправо
        {                    
                   
             X++; 
            
        }

        public void MoveLeft()  // Изменение координаты x при движении влево
        {
                      
             X--;                  
                    
        }


        public void TurnArround() // Переворачивание фигуры
        {
            if (X>=0 && X<= 8 - sizeMatrix && Y<= 15 - sizeMatrix)
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
            X = _x;
            Y = _y;
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
            X = _x;
            Y = _y;
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
            X = _x;
            Y = _y;
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
            X = _x;
            Y = _y;
            matrix = new int[3, 3]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 1 },
            };

        }

    }


}
