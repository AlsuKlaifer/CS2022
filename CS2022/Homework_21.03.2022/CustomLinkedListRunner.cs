using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2022.Homework_21._03._2022;

namespace CS2022.List
{
    public class CustomLinkedListRunner
    {
        public void Run()
        {
            try
            {
                var ll = new CustomLinkedList<int>();
                ll.WriteToConsole();
                ll.Add(1);
                ll.WriteToConsole();
                ll.AddRange(new int[] { 1, 2, 3, 4, 5, 6 });
                ll.WriteToConsole();
                ll.Reverse();
                ll.WriteToConsole();

                var ll2 = new CustomLinkedList<int>(
                    new int[] { 1, 2, 3, 4, 5, 6 });
                ll2.WriteToConsole();
                ll2.Add(1);
                ll2.WriteToConsole();
                ll2.RemoveAt(3);
                ll2.WriteToConsole();
                ll2.RemoveAt(1);
                ll2.WriteToConsole();
                ll2.RemoveAt(ll2.Size());
                ll2.WriteToConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +
                    Environment.NewLine + ex.StackTrace);
            }
        }
    }
}