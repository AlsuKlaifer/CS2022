using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AISD
{
    public class Algorithms
    {
        //Если значение бесконечности представить в виде int.MaxValue,
        //мы столкнемся с переполнением, когда веса путей i→k и k→j будут равны int.MaxValue,
        //при использовании константы (int.MaxValue / 2) - 1 переполнения не будет. 

        private const int no_edge = (int.MaxValue / 2) - 1;

        public static List<int> ReadFromFileToList()
        {
            var path = @"C:\Users\79874\source\repos\AlsuKlaifer\CS2022\AISD\SemesterWork1\input.txt";
            string str = File.ReadAllText(path);
            List<int> list = new List<int>(str.Split(' ', '\n', '\r').Where(x => x != "").Select(s => Int32.TryParse(s, out int n) ? n : (int)no_edge));
            return list;
        }
        public static int[,] ReadFromFileToArray()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\79874\source\repos\AlsuKlaifer\CS2022\AISD\SemesterWork1\input.txt");
            int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == "-")
                    {
                        num[i, j] = no_edge;
                        continue;
                    }
                    num[i, j] = Convert.ToInt32(temp[j]);
                }
            }
            return num;
        }
        public static void Run()
        {
            int[,] graph1 = ReadFromFileToArray();

            FloydWarshall(graph1);

            var graph2 = ReadFromFileToList();

            FloydWarshall(graph2, 4);
        }
        
        public static void FloydWarshall(int[,] graph)
        {
            int verticesCount = graph.GetLength(0);

            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (graph[i, k] + graph[k, j] < graph[i, j])
                            graph[i, j] = graph[i, k] + graph[k, j];
                    }
                }
            }

            Print(graph);
        }
        private static void Print(int[,] distance)
        {
            int verticesCount = distance.GetLength(0);

            Console.WriteLine("Кратчайшее расстояния между каждой парой вершин:");

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

        public static void FloydWarshall(List<int> list1, int sz)
        {
            var list = list1.ToArray();
            for (var k = 0; k < sz; ++k)
            {
                for (var i = 0; i < sz; ++i)
                {
                    if (list[i * sz + k] == no_edge)
                    {
                        continue;
                    }
                    for (var j = 0; j < sz; ++j)
                    {
                        var distance = list[i * sz + k] + list[k * sz + j];
                        if (list[i * sz + j] > distance)
                        {
                            list[i * sz + j] = distance;
                        }
                    }
                }
            }
            Print(list, sz);
        }
        private static void Print(int[] distance, int sz)
        {
            Console.WriteLine("Кратчайшее расстояния между каждой парой вершин:");

            for (int i = 0; i < sz; ++i)
            {
                for (int j = 0; j < sz; ++j)
                {
                    if (distance[i * sz + j] == no_edge)
                        Console.Write("-".PadLeft(7));
                    else
                        Console.Write(distance[i * sz + j].ToString().PadLeft(7));
                }
                Console.WriteLine();
            }
        }
    }
}
