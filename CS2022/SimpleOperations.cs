using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022
{
    public class SimpleOperations
    {
        public int Square(int i)
        {
            return i * i;
        }

        public double Division(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }
    }
}
