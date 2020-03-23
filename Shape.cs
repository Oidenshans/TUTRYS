using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
   public class Shape
    {

        public int x;
        public int y;
        public int[,] matrix;
        private int copy;
        public  int sizematrix;

        public Shape(int _x,int _y) 
        {
            x = _x;
            y = _y;
            matrix = new int[3, 3] 
            { 
                { 0, 1, 0 },
                { 0, 1, 0 }, 
                { 0, 1, 1 }, 
            };

            sizematrix = 3;
        }

        public void MoveDown()
        {
           
                y++;
            
        }


        public void MoveRight()
        {                    
            if (x <= 8 - sizematrix)
                
                x++;                                                                                     
        }

        public void MoveLeft()
        {
            if (x >= 0)
            {
                x--;
            }          
                    
        }




        public void TurnArround()
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
}
