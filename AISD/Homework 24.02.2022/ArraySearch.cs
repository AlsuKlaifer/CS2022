using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public class ArraySearch
    {
        public static void MajoritySearch(int[] array)
        {
            Array.Sort(array);
            int counter = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                    counter++;
                else counter = 1;
                if (counter > array.Length / 2)
                    Console.WriteLine(array[i]);
            }
        }
        public int CountArrays(int[] a)
        {
            if (a.Length % 2 != 0)
                return a.Length + 1 / 2 * a.Length + 2;
            else return a.Length/ 2 * a.Length + 2 + (a.Length/2);
        }

        public int[][] AllArrays(int[] array)
        {
            int[][] result = new int[CountArrays(array)][];
            result[0] = null;
            for (int g = 0; g < array.Length; g++)
            {
                int k = 1;
                for (int i = 1; i <= array.Length; i++)
                {
                    if (g> 0 && g + k == array.Length)
                        break;
                    var arr = new int[k];
                    for (int j = 0; j < arr.Length; j++)
                        arr[j] = array[j + g];
                    result[i + (3*g)] = arr;
                    k++;
                }
            }
            return result;
        }
        public void Print(int[][] result)
        {
            foreach (int[] a in result)
            {
                if (a == null)
                {
                    Console.WriteLine(" ");
                    break;
                }
                foreach (int el in a)
                    Console.Write(el + " ");
                Console.WriteLine();
            }
        }
    }
}