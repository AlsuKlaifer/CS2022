using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.Karatsuba
{
    public class Mult
    {
        public void Run()
        {
            int a1 = 12;
            int a2 = 1;
            int a3 = 0;
            int a4 = 2;
            int b1 = 13;
            int b2 = 0;
            Console.WriteLine(Multiplication(a1,b2));
            Console.WriteLine(Multiplication(a1,b1));
            Console.WriteLine(Multiplication(a2,b1));
            Console.WriteLine(Multiplication(a3,b1));
            Console.WriteLine(Multiplication(a4,b1));

        }
        /// <summary>
        /// Неоптимальный метод нахождения длины интового числа
        /// </summary>
        private int IntLength(int a)
        {
            int i = 1;
            while (a / 10 != 0) i++;
            return i;
        }
        public double Multiplication(int a, int b)
        {
            var result = Calc(new Number(a, 0), new Number(b, 0));
            return (result.Numeral * Math.Pow(10, result.Discharge));
        }
        private Number Calc(Number a, Number b)
        {
            if (b.Numeral == 0 || a.Numeral == 0) return new Number(0, 0);
            if (a.Numeral == 1) return new Number(b.Numeral, b.Discharge + a.Discharge);
            if (b.Numeral == 1) return new Number(a.Numeral, b.Discharge + a.Discharge);
            if (a.Numeral < 10 || b.Numeral < 10) return new Number(b.Numeral * a.Numeral, 0);
            int aLength = IntLength(a.Numeral);
            int bLength = IntLength(b.Numeral);
            int halfLength1 = aLength / 2;
            int halfLength2 = bLength / 2;
            Number a1 = new Number(Convert.ToInt32(a.Numeral / Math.Pow(10, halfLength1)), 1);
            Number a2 = new Number(Convert.ToInt32(a.Numeral % Math.Pow(10, aLength - halfLength1)), 0);
            Number b1 = new Number(Convert.ToInt32(b.Numeral / Math.Pow(10, halfLength2)), 1);
            Number b2 = new Number(Convert.ToInt32(b.Numeral % Math.Pow(10, bLength - halfLength2)), 0);
            Number ac = Calc(a1, b1);
            Number bd = Calc(a2, b2);
            return new Number(2, 1);

        }
    }
        public class Number
        {
            /// <summary>
            /// число
            /// </summary>
            public int Numeral;
            /// <summary>
            /// разряд
            /// </summary>
            public int Discharge;

            public Number(int numeral, int discharge)
            {
                Numeral = numeral;
                Discharge = discharge;
            }
        }
}
