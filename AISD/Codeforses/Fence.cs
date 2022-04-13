using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD.Codeforses
{
    public class Fence
    {
        public void Run()
        {
            int[] array = new int[7] { 1, 2, 6, 1, 1, 7, 1 };
            Console.WriteLine(ToBringPiano(array, 3));
        }
        public int ToBringPiano(int[] array, int number)
        {
            int sum = 0;
            int res = 0;
            int min = Int32.MaxValue;
            int end = array.Length - number + 1;
            for (int j = 0; j < number + 1; j++)
            {
                sum += array[j];
            }
            for (int i = 1; i < end; i++)
            {
                sum = sum - array[i - 1] + array[number + i];

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
