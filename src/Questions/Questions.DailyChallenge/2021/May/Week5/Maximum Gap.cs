using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/31/2021 11:31:57 AM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/602/week-5-may-29th-may-31st/3761/
    /// @des : 
    /// </summary>
    public class Maximum_Gap
    {

        // Constraints:
        //1 <= nums.length <= 10^4
        //0 <= nums[i] <= 10^9

        // 更耗时。
        public int Optimize(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int len = nums.Length;

            int[] diffArr = new int[len];

            Array.Fill(diffArr, int.MaxValue);

            int max = 0;

            for (int i = 0; i < len - 1; i++)
            {
                int currMax = diffArr[i];
                int num = nums[i];
                for (int j = i + 1; j < len; j++)
                {
                    int curr = nums[j];
                    if (curr == num)
                    {
                        currMax = 0;
                        break;
                    }
                    if (curr > num)
                    {
                        currMax = Math.Min(currMax, curr - num);
                    }
                    else
                    {
                        diffArr[j] = Math.Min(diffArr[j], num - curr);
                    }
                }
                if(currMax != int.MaxValue)
                    max = Math.Max(currMax, max);
            }
            return max;

        }

        // Your runtime beats 33.33 % 
        public int Simple(int[] nums)
        {
            if (nums.Length < 2) return 0;

            nums = nums.OrderBy(u => u).ToArray();

            //Array.Sort(nums);

            int max = int.MinValue;
            for (int i = 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i] - nums[i - 1]);
            }
            return max;
        }

    }
}
