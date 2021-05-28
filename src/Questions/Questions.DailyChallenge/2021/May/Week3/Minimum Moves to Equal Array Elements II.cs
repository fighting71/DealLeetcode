using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/19/2021 4:09:12 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3748/
    /// @des : 
    ///     给定一个大小为n的整数数组nums，返回使所有数组元素相等所需的最小移动次数。
    ///     在一次移动中，你可以将数组中的元素增加或减少1。
    /// </summary>
    [Favorite(FlagConst.Special)]
    public class Minimum_Moves_to_Equal_Array_Elements_II
    {

        // Constraints:

        // n == nums.length
        //1 <= nums.length <= 10^5
        //-10^9 <= nums[i] <= 10^9

        // Your runtime beats 73.33 %
        // 好家伙 ，看似是找平均值，实则是找中位数...
        public int Try2(int[] nums)
        {

            Array.Sort(nums);

            int len = nums.Length;

            var mid = nums[len / 2];

            int res = 0;

            foreach (var num in nums)
            {
                res += Math.Abs(num - mid);
            }

            return res;

        }
        public int Try(int[] nums)
        {

            Array.Sort(nums);

            int len = nums.Length;

            if (len % 2 == 0)
            {

                int mid = nums[len / 2], mid2 = nums[len / 2 - 1];

                int res = 0, res2 = 0;

                foreach (var num in nums)
                {
                    res += Math.Abs(num - mid);
                    res2 += Math.Abs(num - mid2);
                }

                bool same = res == res2; // always true => 永远相等

                return Math.Min(res, res2);
            }
            else
            {
                var mid = nums[len / 2];

                int res = 0;

                foreach (var num in nums)
                {
                    res += Math.Abs(num - mid);
                }

                return res;
            }

        }

        // bug :1,0,0,8,6
        public int MinMoves2(int[] nums)
        {
            int avg = (int)nums.Average();

            int res = 0;

            foreach (var num in nums)
            {
                res += Math.Abs(num - avg);
            }

            return res;

        }

    }
}
