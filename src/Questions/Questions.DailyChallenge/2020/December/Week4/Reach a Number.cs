using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/29/2020 2:11:54 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3583/
    /// @des : 
    /// </summary>
    public class Reach_a_Number
    {

        public int OldSolution(int target)
        {
            if (target == 0) return 0;
            target = Math.Abs(target);
            int i = 1,sum = 0;
            for (; sum != target; i++)
            {
                sum += i;
                if (sum > target && (sum - target) % 2 == 0) // (⊙_⊙)? 没有一点印象.
                    return i;
            }
            return i;
        }

        // [-10^9, 10^9].
        // bug
        public int ReachNumber(int target)
        {

            target = Math.Abs(target);

            int step = 0, num = 0;

            while (num < target)
            {
                num += ++step;
            }

            if (num == target) return step;

            var more = num - target;

            if (more == 1)
            {
                return step + 1;
            }

            var prevDiff = target - num + step;

            if (prevDiff == 1) return step + 1;

            return step;
        }

        // 退出条件->无限减->无限递归
        private int Helper(int curr, int step, int target)
        {
            if (target == curr) return step;
            if (target < curr) return int.MaxValue;
            return Math.Min(Helper(curr + step, step + 1, target), Helper(curr - step, step + 1, target));
        }

    }
}
