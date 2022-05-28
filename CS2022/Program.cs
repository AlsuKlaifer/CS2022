// See https://aka.ms/new-console-template for more information
using CS2022;
using CS2022.List;
using System.Text.RegularExpressions;
using CS2022.LINQ;
using CS2022.Delegats;
using CS2022.Homework_21._03._2022;
using CS2022.Tree;
using CS2022.List;
using CS2022.Reflection;
using System.Threading;

var runner = new CustomList<int>();
runner.Run();

Thread thread = new Thread(Fibonachi);
thread.IsBackground = true;
thread.Start();
Console.WriteLine(thread.ThreadState);
thread.IsBackground = false;

static void Fibonachi()
{
    int prev = 1;
    Console.WriteLine(prev);
    int next = 1;
    Console.WriteLine(next);
    int sum = 0;
    for (int i = 2; i < 10; i++)
    {
        sum = prev + next;
        Console.WriteLine(sum);
        prev = next;
        next = sum;
    }
}

//int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int i = 0;
//public delegate void PowWithParams(object? obj);
////Thread thread1 = new Thread(new PowWithParams(Pow2));
//Thread thread2 = new Thread(Fibonachi);
//Thread thread3 = new Thread(Fibonachi);

//void Pow2(int[] array)
//{
//    foreach (int i in array)

//}