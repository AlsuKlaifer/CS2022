using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                var ll2 = new CustomLinkedList<int>(
                    new int[] { 1, 2, 3, 4, 5, 6 });
                ll2.WriteToConsole();
                ll2.RemoveAt(3);
                ll2.WriteToConsole();
                ll2.RemoveAt(1);
                ll2.WriteToConsole();
                ll2.RemoveAt(ll2.Size());
                ll2.WriteToConsole();

                foreach (var el in ll2)
                {
                    Console.WriteLine(el.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +
                    Environment.NewLine + ex.StackTrace);
            }
        }
    }
}