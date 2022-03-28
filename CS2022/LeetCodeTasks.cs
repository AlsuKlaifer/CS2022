using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2022.LINQ
{
    public class LeetCodeTasks
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int result = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count = 0;
                else
                {
                    count++;
                    result = Math.Max(result, count);
                }
            }
            return result;
        }
        public int FindNumbers(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                if (num.ToString().Length % 2 == 0)
                    result++;
            }
            return result;
        }
    }
}
