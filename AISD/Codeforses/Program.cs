using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.Codeforses
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split().ToArray();
            int length = int.Parse(a[0]);
            int number = int.Parse(a[1]);
            int[] array = new int[length];
            string[] strings = Console.ReadLine().Split(' ');
            for (int i = 0; i < length; i++)
            {
                array [i] = Convert.ToInt32(strings[i]);
            }
            //int[] array = new int[7] { 1, 2, 6, 1, 1, 7, 1 };
            Console.WriteLine(ToBringPiano(array, number));
        }
        public static int ToBringPiano(int[] array, int number)
        {
            if (number == 1) return Array.IndexOf(array, array.Min())+1;
            if (array.Length == 1) return 1;
            if (number == array.Length) return 1;
            int res = 0;
            int min = Int32.MaxValue;
            int end = array.Length - number + 1;
            for (int i = 0; i < end; i++)
            {
                int sum = 0;

                int end2 = number + i;

                for (int j = i; j < end2; j++)
                {
                    sum += array[j];
                }

                if (sum < min)
                {
                    min = sum;
                    res = i + 1;
                }
            }
            return res;
        }
    }
}
