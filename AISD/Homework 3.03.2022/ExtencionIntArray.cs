using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public static class ExtencionIntArray
    {
        public static int[] RemoveAt(this int[] arr, int i)
        {
            for (int j = i; j < arr.Length - 1; j++)
            {
                arr[j] = arr[j + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }
    }
}
