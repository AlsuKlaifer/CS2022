using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.Karatsuba
{
    public class Mult
    {
        public int Calc(int a, int b)
        {
            var result = calc(a, b);
            return result;
        }
        private int IntLength(int a)
        {
            string s = a.ToString();
            return s.Length;
        }
        private int calc(int a, int b)
        {
            if (b == 0 || a == 0) return 0;
            if (a == 1) return b;
            if (b == 1) return a;
            if (a < 10 || b < 10) return a * b;

            //работает для любых длин

            int aLength = IntLength(a);
            int bLength = IntLength(b);
            int halfLength = Math.Min(aLength, bLength) / 2;

            int halfLengthPow = (int)Math.Pow(10, halfLength);
            int a1 = a / halfLengthPow;
            int a2 = a % halfLengthPow;
            int b1 = b / halfLengthPow;
            int b2 = b % halfLengthPow;

            int ac = calc(a1, b1);
            int bd = calc(a2, b2);

            var sumFirst = a1 + a2;
            var sumSecond = b1 + b2;
            int bigsum = calc(sumFirst, sumSecond);

            var middle = bigsum - ac - bd;
            int numeralResult = ac * (int)Math.Pow(10, halfLength * 2) +
                middle * (int)Math.Pow(10, halfLength) + bd;

            return numeralResult;
        }
    }
}