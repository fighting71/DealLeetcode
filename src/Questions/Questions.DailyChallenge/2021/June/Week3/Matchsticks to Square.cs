using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/16/2021 11:05:12 AM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3780/
    /// @des : 
    ///     给定一个整数数组matchsticks，其中matchsticks[i]是第i个火柴棍的长度。你想用所有的火柴棍做一个正方形。你不应该折断任何一根火柴棍，但是你可以把它们连接起来，而且每根火柴棍只能使用一次。
    ///     如果你能使这个正方形返回真，否则返回假。
    /// </summary>
    [Favorite(FlagConst.Special, FlagConst.DFS)]
    public class Matchsticks_to_Square
    {

        //Constraints:

        //1 <= matchsticks.length <= 15
        //0 <= matchsticks[i] <= 10^9

        public bool Explain(int[] matchsticks)
        {
            int len = matchsticks.Length;

            long sum = 0;
            foreach (var item in matchsticks)
            {
                sum += item;
            }

            // 正方形特性：边长相等
            if (sum % 4 != 0) return false;

            long side = sum / 4;

            // 用于标记哪些火柴已经被使用
            bool[] used = new bool[len];

            // 排序火柴使得==>优先使用较长的火柴(Help方法优先使用靠前的火柴)
            matchsticks = matchsticks.OrderByDescending(u => u).ToArray();

            for (int i = 0; i < 3; i++) // 若能够有三种符合边长则表示满足条件
            {
                if (!Help(0, 0)) return false;
            }

            return true;

            // 类似于dfs ， 利用递归遍历所有可能
            // curr = 当前火柴组合的总长度
            // i = 下一根火柴的下标
            bool Help(long curr, int i)
            {
                if (curr == side) return true;
                if (i == len || curr > side) return false;
                if (used[i]) // 火柴已被使用
                {
                    return Help(curr, i + 1);
                }

                used[i] = true;
                if (Help(curr + matchsticks[i], i + 1)) // 方案1：使用此火柴
                {
                    return true;
                }
                used[i] = false;

                return Help(curr, i + 1); // 方案2: 不使用此火柴
            }

        }

        // You are here!
        // Your runtime beats 100.00 % of csharp submissions.
        // haha genius
        public bool Makesquare(int[] matchsticks)
        {
            int len = matchsticks.Length;

            long sum = 0;
            foreach (var item in matchsticks)
            {
                sum += item;
            }

            if (sum % 4 != 0) return false;

            long side = sum / 4;

            bool[] used = new bool[len];

            matchsticks = matchsticks.OrderByDescending(u => u).ToArray();

            for (int i = 0; i < 3; i++)
            {
                if (!Help(0, 0)) return false;
            }

            return true;

            bool Help(long curr, int i)
            {
                if (curr == side) return true;
                if (i == len || curr > side) return false;
                if (used[i])
                {
                    return Help(curr, i + 1);
                }

                used[i] = true;
                if (Help(curr + matchsticks[i], i + 1))
                {
                    return true;
                }
                used[i] = false;

                return Help(curr, i + 1);
            }

        }
    }
}
