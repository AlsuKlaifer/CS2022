using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    /// <summary>
    /// пара. ключ значений
    /// </summary>
    public class Couple
    {
        public int Key;
        public int Value;

        public Couple(int key, int value)
        {
            Key = key;
            Value = value;
        }
        public static Couple[] UniqNumCount(int[] a)
        {
            if (a == null)
                throw new Exception("Массив пуст");
            var result = new Couple[0];
            foreach( var el in a)
            {
                int i = 0;
                while (i< result.Length)
                {
                    if(result[i].Key == el)
                    {
                        result[i].Value++;
                        break;
                    }
                    i++;
                }
                if (i==result.Length)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[i] = new Couple(el, 1);
                }
            }
            return result;
        }
    }
}
