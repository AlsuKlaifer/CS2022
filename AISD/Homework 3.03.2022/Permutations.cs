using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public class Permutations
    {
        public static int[][] GetAllPermutations(int[] input)
        {
            if (input == null)
                throw new ArgumentNullException("Входящий массив не инициализирован");

            if (input.Distinct().Count() != input.Count())
                throw new ArgumentException("Входящий массив содержит повторения");

            var result = new string[0];

            GetAllPermutations(input, ref result);

            int[][] result1 = StringArrToIntArr(result);

            return result1;
        }

        private static void GetAllPermutations(int[] input, ref string[] result, string current = "")
        {
            if (input.Count() == 0)
            {
                var length = result.Length;
                Array.Resize<string>(ref result, length + 1);
                result[length] = current;
                return;
            }
            for (int i = 0; i < input.Count(); i++)
            {
                int[] newInput = (int[])input.Clone();
                newInput = newInput.RemoveAt(i);

                GetAllPermutations(newInput, ref result, current + " " + input[i]);
            }
        }

        public static int[][] StringArrToIntArr(string[] s)
        {
            int[][] result = new int[s.Length][];
            for (int j = 0; j < s.Length; j++)
            {
                string str = s[j].Replace(" ", "");
                result[j] = str.Select(number => Convert.ToInt32(Char.GetNumericValue(number))).ToArray();
            }
            return result;
        }
    }
}
