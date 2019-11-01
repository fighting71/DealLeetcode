using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/1 15:57:46
    /// @source : https://leetcode.com/problems/first-missing-positive/
    /// @des : 
    /// </summary>
    public class FirstMissingPositive
    {
        
        /**
         * Runtime: 84 ms, faster than 99.09% of C# online submissions for First Missing Positive.
         * Memory Usage: 24.1 MB, less than 9.09% of C# online submissions for First Missing Positive.
         *
         * ...???
         *
         */
        public int Solution(int[] nums)
        {
            var res = 1;
            // out memory ....
            //var exists = new bool[int.MaxValue];

            // 此处可能不符合题意...
            ISet<int> set = new HashSet<int>();

            foreach (var num in nums)
            {
                if (num <= 0) continue;
                if (res == num)
                {
                    while (set.Contains(++res))
                    {
                    }

                    //while (exists[++res])
                    //{
                    //}
                }

                set.Add(num);
                //exists[num] = true;
            }

            return res;
        }
    }
}