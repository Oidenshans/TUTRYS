using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
    class GameLogicFunction
    {
        private Shape currentShape1;
        private int[,] map;
       public GameLogicFunction(Shape _currentShape, int[,] _map) { currentShape1 = _currentShape; map = _map; }


        public void Merge()
        {
            for (int i = currentShape1.y; i < currentShape1.y + currentShape1.sizematrix; i++)
            {
                for (int j = currentShape1.x; j < currentShape1.x + currentShape1.sizematrix; j++)
                {
                    if (currentShape1.matrix[i - currentShape1.y, j - currentShape1.x] != 0)
                    {
                        map[i, j] = currentShape1.matrix[i - currentShape1.y, j - currentShape1.x];
                    }

                }
            }
        }

        public void ResetArea()
        {
            for (int i = currentShape1.y; i < currentShape1.y + currentShape1.sizematrix; i++)
            {
                for (int j = currentShape1.x; j < currentShape1.x + currentShape1.sizematrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < 16 && j < 8)
                    {
                        if (currentShape1.matrix[i - currentShape1.y, j - currentShape1.x] != 0)
                        {
                            map[i, j] = 0;
                        }


                    }
                }


            }
        }


        public int CheckWall()
        {
            for (int i = currentShape1.y; i < currentShape1.y + currentShape1.sizematrix; i++)
            {
                for (int j = currentShape1.x; j < currentShape1.x + currentShape1.sizematrix; j++)
                {
                    if (currentShape1.matrix[i - currentShape1.y, j - currentShape1.x] != 0)
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
            for (int i = currentShape1.y; i < currentShape1.y + currentShape1.sizematrix; i++)
            {
                for (int j = currentShape1.x; j < currentShape1.x + currentShape1.sizematrix; j++)
                {
                    if (currentShape1.matrix[i - currentShape1.y, j - currentShape1.x] != 0)
                    {
                        
                        if (j + 1*d == 8||j+1*d<0 )
                        {
                            return 1;
                        }

                        if (map[i, j + 1*d] != 0|| map[i, j + 1 * d]!=0)
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
            for (int i = currentShape1.y; i < currentShape1.y + currentShape1.sizematrix; i++)
            {
                for (int j = currentShape1.x; j < currentShape1.x + currentShape1.sizematrix; j++)
                {
                    if (currentShape1.matrix[i - currentShape1.y, j - currentShape1.x] != 0)
                    {
                        map[i, j] = 2;
                    }
                }


            }


        }

    }
}
