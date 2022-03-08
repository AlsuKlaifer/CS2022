using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.List
{
    public class CustomArrayCollectionRunner
    {
        public void Run()
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
    }
}
