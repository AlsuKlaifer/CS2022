using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class CustomArrayCollectionRunner
    {
        public void Run1()
        {
            try
            {
                var arrList = new CustomArrayCollection<int>
                    (new int[] { 1, 2, 3, 3, 5 });
                arrList.Reverse();
                arrList.WriteToConsole();
                arrList.RemoveAll(3);
                arrList.WriteToConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +
                    Environment.NewLine + ex.StackTrace);
            }
        }
        public void Run2()
        {
            var arr1 = new CustomArrayCollection<int>(new[] { 1, 2 });
            arr1.Add(3);
            arr1.AddRange(new int[] { 4, 5 });

            var arr2 = new CustomArrayCollection<int>();
            arr2.Add(1);
        }
    }
}
