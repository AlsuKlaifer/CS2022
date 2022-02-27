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
            int length = 1;
            for(int k =1; k<=a.Length;k++)
                length += Factorial(a.Length) / Factorial(k) / Factorial(a.Length - k);
            return length;
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

        public int Factorial(int a)
        {
            int result = 1;
            for (int i = 2; i <= a; i++)
                result *= i;
            return result;
        }

        public static void Recursion(int[] arr, int loBound, int upBound)
        {
            for (int i = loBound; i <= upBound; i++)
            {
                swap(ref arr[loBound], ref arr[i]);
                if (loBound == upBound)
                {
                    Console.Write(arr);
                    Console.WriteLine();
                }
                Recursion(arr, loBound + 1, upBound);
                swap(ref arr[loBound], ref arr[i]);
            }
        }

        public static void swap(ref int a, ref int b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}