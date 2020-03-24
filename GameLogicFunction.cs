using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
    class GameLogicFunction
    {
       private Shape currentShape;
       private int[,] map;
       private int count;

        // Конструкторы для различных фигур
       public GameLogicFunction(Shape _currentShape, int[,] _map) 
        { 
            currentShape = _currentShape; 
            map = _map; 
        }


        public void Merge()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        map[i, j] = currentShape.matrix[i - currentShape.Y, j - currentShape.X];
                    }

                }
            }
        }

        public void ResetArea()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < 16 && j < 8)
                    {
                        if (currentShape.matrix[i - currentShape.Y, j - currentShape.X] != 0)
                        {
                            map[i, j] = 0;
                        }


                    }
                }


            }
        }


        public int CheckWall()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        if (i + 1 == 16)
                        {
                            return 1;
                        }
                        if (map[i + 1, j] != 0)
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
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        
                        if (j + 1*d >7 || j+1*d<0 )
                        {
                            return 1;
                        }

                        if (map[i, j + 1*d] != 0)
                        {
                            if (j - currentShape.X + 1 * d >= currentShape.sizeMatrix || j - currentShape.X + 1 * d < 0)
                            {
                                return 1;
                            }
                            if (currentShape.matrix[i - currentShape.Y, j - currentShape.X + 1 * d] == 0)

                                return 1;
                        }
                         
                        

                    }
                }
            }

            return 0;

        }

        public void ChangeColor()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.Y, j - currentShape.X] == 1)
                    {
                        map[i, j] = 2;
                    }
                }


            }


        }


        public void CutLine()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i, j] == 2)
                    {
                        count += 1;
                    }
                                   
                }

                if (count == 8)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        map[i, j] = 0;
                                                  
                       
                    }
                }


            }
        }


        public void LeftDrive()
        {
            ResetArea();

            if (CheckWall(-1) == 0)
            {

                currentShape.MoveLeft();

                Merge();
                
            }
        }

        public void RightDrive()
        {
            ResetArea();

            if (CheckWall(1) == 0)
            {

                currentShape.MoveRight();

                Merge();

            }
        }

        public void TurnArrounDrive()
        {
            ResetArea();

            currentShape.TurnArround();

            Merge();
        }

        public void DownDrive()
        {
            ResetArea();

            if (CheckWall() == 0)
            {

                currentShape.MoveDown();

                Merge();

            }

            else
            {

                Merge();

                ChangeColor();


            
            }
        }





    }
}
