using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUTRYS
{
    public class LShape : Shape
    {
        public LShape(int _x, int _y)
            : base(_x, _y)
        {
            Matrix = new int[SizeMatrix, SizeMatrix]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 1 },
            };
        }
    }
}
