using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AISD
{
    public class ArrayTasks
    {
        public static int[][] ReadFromFile()
        {
            string path = @"C:\Users\Asus\Desktop\Array.txt";
            if (!File.Exists(path))
                throw new Exception("Файл не найден");
            string[] lines = File.ReadAllLines(path);
            int[][] array = new int [lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                array [i] = new int [line.Length];
                for (int j = 0; j < line.Length; j++)
                { 
                    array[i][j] = Int32.Parse(line[j]);
                }
            }
            return array;
        }
        public static void JoinAllArrays(int[][] array)
        {
            //проверяем, отсортированы ли массивы
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j - 1] > array[i][j])
                        throw new Exception("Массив не отсортирован");
                }
            }

            while (array.Length != 1)
            {
                int [][] newArr = new int[array.Length / 2 + array.Length % 2][];
                int k = 0;
                for (int i = 0; i < array.Length - 1; i += 2)
                {
                    newArr[k] = JoinArray(array[i], array[i + 1]);
                    k++;
                }
                if (array.Length % 2 != 0)
                {
                    newArr[k] = array[array.Length-1];
                    k++;
                }
                array = newArr;
            }

            Console.WriteLine(String.Join(" ", array[0]));
        }
         /// <summary>
         /// Слияние двух массивов
         /// </summary>
        public static int[] JoinArray(int[] a1, int[] a2)
        {
            if (a1?.Length == 0 && a2?.Length == 0)
            {
                Console.WriteLine("Массивы пустые");
                return null;
            }
            if (a1?.Length == 0 && a2?.Length > 0)
                return a2;
            if (a1?.Length > 0 && a2?.Length == 0)
                return a1;

            //позиция текущего элемента массива
            int i1 = 0;
            int i2 = 0;
            int[] result = new int[a1.Length + a2.Length];
            int iResult = 0;
            while (i1 < a1.Length && i2 < a2.Length)
            {
                if (a1[i1] < a2[i2])
                {
                    result[iResult] = a1[i1];
                    i1++;
                }
                else
                {
                    result[iResult] = a2[i2];
                    i2++;
                }
                iResult++;
            }
            //конец массива
            if (i1 < a1.Length)
                for (int i = i1; i < a1.Length; i++)
                {
                    result[iResult] = a1[i];
                    iResult++;
                }
            if (i2 < a2.Length)
                for (int i = i2; i < a2.Length; i++)
                {
                    result[iResult] = a2[i2];
                    iResult++;
                }
            return result;
        }
        public int[] ArrayDifference(int[] a1, int[] a2)
        {
            if (a1?.Length == 0 && a2?.Length == 0)
            {
                Console.WriteLine("Массивы пустые");
                return null;
            }
            if (a1?.Length == 0 && a2?.Length > 0)
                return a2;
            if (a1?.Length > 0 && a2?.Length == 0)
                return a1;

            int i1 = 0;
            int i2 = 0;
            int[] result = new int[a1.Length];
            int iResult = 0;
            while (i1 < a1.Length && i2 < a2.Length)
            {
                if (a1[i1] < a2[i2])
                {
                    result[iResult] = a1[i1];
                    i1++;
                    iResult++;
                }
                else if (a1[i1] == a2[i2])
                {
                    i1++;
                    i2++;
                }
                else if (a1[i1] > a2[i2]) i2++;
            }

            if (i1 < a1.Length)
                for (int i = i1; i < a1.Length; i++)
                {
                    result[iResult] = a1[i1];
                    iResult++;
                }
            return result;
        }

        public int[] Intersection(int[] a1, int[] a2)
        {
            if (a1?.Length == 0 && a2?.Length == 0)
            {
                Console.WriteLine("Массивы пустые");
                return null;
            }
            if (a1?.Length == 0 && a2?.Length > 0)
                return a2;
            if (a1?.Length > 0 && a2?.Length == 0)
                return a1;

            int i1 = 0;
            int i2 = 0;
            int[] result = new int[a1.Length > a2.Length ? a1.Length : a2.Length];
            int iResult = 0;
            while (i1 < a1.Length && i2 < a2.Length)
            {
                if (a1[i1] < a2[i2])
                {
                    i1++;
                }
                else if (a1[i1] == a2[i2])
                {
                    result[iResult] = a1[i1];
                    iResult++;
                    i1++;
                    i2++;
                }
                else i2++;
            }
            return result;
        }
    }
}
