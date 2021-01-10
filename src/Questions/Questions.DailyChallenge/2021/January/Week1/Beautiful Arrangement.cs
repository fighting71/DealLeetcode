using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/4/2021 2:37:14 PM
    /// @source : https://leetcode.com/explore/featured/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3591/
    /// @des : 
    ///     给你1-n总n个数字(1-n每个数字出现一次)
    ///     查看存在多少种组合满足：
    ///         对任意i有：
    ///         arr[i] % i == 0 || i % arr[i] == 0
    /// </summary>
    public class Beautiful_Arrangement
    {

        // 1 <= n <= 15

        // Your runtime beats 71.79 %
        // 题目说明不清晰... 后参考文章才明白
        public int CountArrangement(int n)
        {

            _res = 0;

            Helper(1, new bool[n + 1]);

            return _res;
        }

        private int _res;

        private void Helper(int i,bool[] used)
        {
            if(i == used.Length)
            {
                _res++;
                return;
            }

            for (int j = 1; j < used.Length; j++)
            {
                if (used[j]) continue;

                if (i % j == 0 || j % i == 0)
                {
                    used[j] = true;
                    Helper(i + 1, used);
                    used[j] = false;
                }
            }

        }

    }
}
