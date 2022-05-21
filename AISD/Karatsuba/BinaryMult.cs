using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.Karatsuba
{
    public class BinaryMult
    {
        public int Calc(int a, int b)
        {
            string s1 = Convert.ToString(a, 2);
            string s2 = Convert.ToString(b, 2);
            var result = calc(s1, s2);
            return result;
        }
        /// <summary>
        /// Преобразует битовую строку меньшей длины (s1) в строку c длиной наибольшей длины (s2), добавляя начальные 0 в меньшую строку. 
        /// </summary>
        /// <returns> Измененная строка
        string makeEqualLength(string s1, string s2, int len1, int len2)
        {
            for (int i = 0; i < len2 - len1; i++)
                s1 = '0' + s1;
            return s1;
        }

        int calc(string X, string Y)
        {
            int len1 = X.Length;
            int len2 = Y.Length;

            //Делаем строки одной длины
            if (len1 < len2)
                X = makeEqualLength(X, Y, len1, len2);
            else if (len2 < len1)
                Y = makeEqualLength(Y, X, len2, len1);

            int n = Y.Length;

            if (n == 0) return 0;
            if (n == 1) return multiplyiSingleBit(X, Y);

            int fh = n / 2;   // Первая половина строки (n / 2)
            int sh = n - fh; // Вторая 

            // Находим первую половину и вторую половину первой строки.
            string X2 = X.Substring(fh);
            string X1 = X.Substring(0, fh);

            // Находим первую половину и вторую половину второй строки
            string Y2 = Y.Substring(fh);
            string Y1 = Y.Substring(0, fh);

            int P1 = calc(X1, Y1);
            int P2 = calc(X2, Y2);
            int P3 = calc(add(X1, X2), add(Y1, Y2));

            return P1 * (1 << (2 * sh)) + (P3 - P1 - P2) * (1 << sh) + P2;
        }

        int multiplyiSingleBit(string a, string b)
        {
            return (a[0] - '0') * (b[0] - '0');
        }

        /// <summary>
        /// Складываает две битовые последовательности и возвращает сумму
        /// </summary>
        string add(string a, string b)
        {
            string result = null;

            int len1 = a.Length;
            int len2 = b.Length;

            //Делаем строки одной длины
            if (len1 < len2)
                a = makeEqualLength(a, b, len1, len2);
            else if (len2 < len1)
                b = makeEqualLength(b, a, len2, len1);

            int length = Math.Max(a.Length, b.Length);
            int carry = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                int firstBit = a.ElementAt(i) - '0';
                int secondBit = b.ElementAt(i) - '0';
                // логическое выражение для суммы 3 бит
                int sum = (firstBit ^ secondBit ^ carry) + '0';
                result = (char)sum + result;
                // логическое выражение для 3-битного сложения
                carry = (firstBit & secondBit) | (secondBit & carry) | (firstBit & carry);
            }
            // если переполнить, то добавить ведущий 1
            if (carry == 1) result = '1' + result;
            return result;
        }
    }
}