using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.Homework_21._04._2022
{
    public class ArraySearchMax
    {
        public int MaxElement(int[] array)
        {
            int length = array.Length;
            if (length == 1)
                return array[0];
            if (length == 2)
                return (array[0] > array[1]) ? array[0] : array[1];
            int midle = length / 2;
            int[] m1 = new int[midle];
            for (int i = 0; i < midle; i++)
                m1[i] = array[i];
            int[] m2 = new int[length - midle];
            for (int i = midle;i < length; i++)
                m2[i-midle] = array[i];
            int res1 = MaxElement(m1);
            int res2 = MaxElement(m2);
            return res1 > res2 ? res1 : res2;
        }
        public void Run()
        {
            int[] array = new int[8] { 1, 4, 3, 2, 7, 9, 10, 0 };
            int res = MaxElement(array);
            Console.WriteLine(res);

            int[] array2 = new int[7] { 11, 4, 3, 2, 7, 9, 10};
            int res2 = MaxElement(array2);
            Console.WriteLine(res2);
        }
    }
}
