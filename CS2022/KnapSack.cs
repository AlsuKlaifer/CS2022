using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022
{
    public static class KnapSack
    {
        public static void SolutionKnapSack()
        {
            int[,] wp = new int[,] { { 1, 2 }, { 2, 1 }, { 1, 1 } };
            int mv = 3;
            int[,] arr = new int[mv + 1, wp.GetLength(0) + 1];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = Math.Max(arr[i - 1, j], arr[i - 1,j - wp[i, 0]] + wp[i - 1, 1]);
                }
        }
        public static void Solution2KnapSack()
        {
            int bagweight = 3;
            int[,] items = new int[,] { { 1, 2 }, { 2, 1 }, { 1, 1 } };
            int itemcount = items.GetLength(0); //кол во вещей
            int[,] dparray = new int[bagweight + 1, itemcount + 1]; //dinamic program\
            for (int i = 1; i <= itemcount; i++)
                for (int j = 1; j <= bagweight; j++)
                {
                    dparray[i, j] = Math.Max(dparray[i - 1, j], dparray[i - 1, Math.Max(j - items[i-1, 0],0)] + items[i - 1, 1]); //+ стоимость iтой вещи
                }
        }
    }               
}