using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public class Test
    {
        private const int no_edge = (int.MaxValue / 2) - 1;
        public int[,] GetArray()
        {
            var a = 6400;
            var random = new Random();
            var array = new int[a, a];
            var x = array.GetLength(0);
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                    array[i, j] = random.Next(1, no_edge);
            for (int i = 0; i < x; i++)
                array[i, i] = 0;
            return array;
        }
        public List<int> GetList()
        {
            int a = 1000;
            int b = a * a;
            var random = new Random();
            var array = new int[a, a];
            var x = array.GetLength(0);
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                    array[i, j] = random.Next(1, no_edge);
            for (int i = 0; i < x; i++)
                array[i, i] = 0;
            int[] m1 = new int[b];
            int z = 0;
            for (int i = 0; i < a; i++)
                for (int j = 0; j < a; j++)
                {
                    m1[z] = array[i, j];
                    z++;
                }
            var list = m1.ToList<int>();
            return list;
        }

        public void Print(int[,] distance)
        {
            int verticesCount = distance.GetLength(0);

            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == no_edge)
                        Console.Write("-".PadLeft(7));
                    else
                        Console.Write(distance[i, j].ToString().PadLeft(7));
                }
                Console.WriteLine();
            }
        }
        public void Run()
        {
            var array = GetList();
            var sw = new Stopwatch();
            sw.Start();
            Algorithms.FloydWarshall(array, 1000);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);       
        }
    }
}
