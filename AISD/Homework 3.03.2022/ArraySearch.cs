using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public class ArraySearch
    {
        /// <summary>
        /// 1 задание. Поиск элемента повторяющегося больше array.Length/2
        /// </summary>
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

        /// <summary>
        /// Считает размерность ступенчаого массива (равно количеству всех сочетаний) для 2 задания
        /// </summary>
        public int CountArrays(int[] a)
        {
            int length = 1;
            for(int k =1; k<=a.Length;k++)
                length += Factorial(a.Length) / Factorial(k) / Factorial(a.Length - k);
            return length;
        }

        //2 задание (не решено до конца)
        //public int[][] AllArrays(int[] array)
        //{
        //    int[][] result = new int[CountArrays(array)][];
        //    result[0] = null;
        //    for (int g = 0; g < array.Length; g++)
        //    {
        //        int k = 1;
        //        for (int i = 1; i <= array.Length; i++)
        //        {
        //            if (g > 0 && g + k == array.Length)
        //                break;
        //            var arr = new int[k];
        //            for (int j = 0; j < arr.Length; j++)
        //                arr[j] = array[j + g];
        //            result[i + (3 * g)] = arr;
        //            k++;
        //        }
        //    }
        //    return result;
        //}
        //public bool NextSet(int[] arr, int n, int m)
        //{
        //    int k = m;
        //    for (int i = k - 1; i >= 0; i--)
        //        if (arr[i] < n - k + i + 1)
        //        {
        //            ++arr[i];
        //            for (int j = i + 1; j < k; ++j)
        //                arr[j] = arr[j - 1] + 1;
        //            return true;
        //        }
        //    return false;
        //}

        public static void Print(int[][] result)
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

        /// <summary>
        /// Перевод числа в массив
        /// </summary>
        public static int[] ToArray(int a, int[] arr)
        {
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = a % 10;
                a /= 10;
            }
            return arr;
        }

        /// <summary>
        /// Перевод массива в число
        /// </summary>
        public static int ToInt(int[] arr)
        {
            int number = 0;
            for (int i = 0; i < arr.Length; i++)
                number += arr[i] * Convert.ToInt32(Math.Pow(10, arr.Length - 1 - i));
            return number;
        }

        /// <summary>
        /// Метод, проверяющий является ли "с" суммой "а" и "b"
        /// </summary>
        public static bool CheckABC(int a, int b, int c)
        {
            int number = Convert.ToString(a).Length;
            int[] arrA = new int[number];
            ToArray(a, arrA);
            var arraysOfA = Permutations.GetAllPermutations(arrA);

            for (int i = 0; i < arraysOfA.Length; i++)
            {
                if (ToInt(arraysOfA[i]) + b == c)
                {
                    Console.WriteLine($"YES {ToInt(arraysOfA[i])} {b}");
                    return true;
                }
                else if (i == arraysOfA.Length - 1) return false;
            }
            return false;
        }

        /// <summary>
        /// Третье задание. Сумма двух чисел
        /// </summary>
        public static void Task3(int a, int b, int c)
        {
            if (!CheckABC(a, b, c))
                if(!CheckABC(b, a, c))
                    Console.WriteLine($"NO {a} {b}");
        }
    }
}