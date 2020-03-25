using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTRYS
{
    class GameLogicFunction
    {
        private Shape currentShape;
        private int[,] map;


        // Конструктор
        public GameLogicFunction(Shape _currentShape, int[,] _map)
        {
            currentShape = _currentShape;
            map = _map;
        }


        public void Merge() // Метод соединяет матрицу фигуры и матрицу карты
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        map[i, j] = currentShape.Matrix[i - currentShape.Y, j - currentShape.X];
                    }

                }
            }
        }

        public void ResetArea() // Метод удаляет предыдущее положение фигуры с карты
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < 16 && j < 8)
                    {
                        if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] != 0)
                        {
                            map[i, j] = 0;
                        }


                    }
                }


            }
        }

        // Метод проверяет наличие стенки или другой фигуры снизу от текущей фигуры
        public int CheckWall()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] != 0)
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


        // Метод проверяет наличие стенки или другой фигуры справа или слева от текущей фигуры в зависимости от значения direction
        // direction = -1 -слева,direction = 1 -справа.
        public int CheckWall(int direction)
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        if (j + 1 * direction > 7 || j + 1 * direction < 0)
                        {
                            return 1;
                        }
                        if (map[i, j + 1 * direction] != 0)
                        {
                            if (j - currentShape.X + 1 * direction >= currentShape.sizeMatrix || j - currentShape.X + 1 * direction < 0)
                            {
                                return 1;
                            }
                            if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X + 1 * direction] == 0)

                                return 1;
                        }
                    }
                }
            }
            return 0;
        }

        // Метод изменяет цвет упавшей фигуры
        public void ChangeColor()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.Y, j - currentShape.X] == 1)
                    {
                        map[i, j] = 2;
                    }
                }
            }
        }

        // Метод удаляет строку если все ячейки заполнены
        public int CutLine()
        {
            
            for (int i = 0; i < 16; i++)
            {            
                int count = 0;
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
                   
                    FallFigures(i);
                    return count;
                }
                
            }
            
            return 0;
        }

        // Метод перемещает верхние окрашенные ячеки вниз после удаления заполненой линии
        public void FallFigures(int row)
        {
            for (int i = row; i >= 1 ; i=i-1)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i-1, j] == 2)
                    {
                        map[i, j] = 2;
                        map[i-1, j] = 0;
                    }                                    
                }
            }
        }
        public int GameOverCheck() // Метод проверяет верхние строки на наличие фигур, если есть возвращает 1
        {
            //for (int i = 0; i < 2; i++)
                           
                for (int j = 0; j < 8; j++)
                {
                    if (map[0, j] != 0)
                    {
                        return 1;   
                    }
                }
            
            return 0;
        }


        public void LeftDrive()  // Метод для движения фигуры влево
        {
            ResetArea();
            if (CheckWall(-1) == 0 && CheckWall() == 0)
            {
                currentShape.MoveLeft();                           
            }
            Merge();
        }


        public void RightDrive() // Метод для движения фигуры вправо
        {
            ResetArea();
            if (CheckWall(1) == 0 && CheckWall() == 0)
            {               
                currentShape.MoveRight();               
            }
            Merge();
        }


        public void TurnArrounDrive()  // Метод для переворачивания фигуры
        {
            ResetArea();
            if (currentShape.X >= 0 && currentShape.X <= 8 - currentShape.sizeMatrix && currentShape.Y <= 15 - currentShape.sizeMatrix)
            {
                currentShape.TurnArround();
            }             
            Merge();
        }


        public int DownDrive() // Метод для движения фигуры вниз
        {
            ResetArea();
            if (CheckWall() == 0)
            {
                currentShape.MoveDown();
                Merge();
                return 0;
            }        
           
            return 1;                                
        }


        public void DownPlaceAction(out int scoreCount,out int endGame) // метод, производящий действия, когда фигура достигает нижнего положения
        {
            Merge();
            ChangeColor();
            scoreCount=CutLine();
            
            endGame = 0;
            if (GameOverCheck() == 1)
            {
              endGame = 1;               
            }
            
        }




    }
}
