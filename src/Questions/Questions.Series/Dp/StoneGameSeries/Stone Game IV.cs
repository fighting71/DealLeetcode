using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/26/2020 12:17:35 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3507/
    /// @des : 存在一堆石头，每次可以拿n^2个石头(至少一个)  当对方没有石头可拿时获胜
    /// </summary>
    [Optimize]
    public class Stone_Game_IV
    {

        // Runtime: 92 ms, faster than 44.17% of C# online submissions for Stone Game IV.
        public bool Optimize(int n)
        {
            // dp[剩余石头] = 能否获胜
            bool[] dp = new bool[n];

            int x = 1;
            for (int i = 0; i < n; i++)
            {
                if(i + 1 == x * x) // i == x^2  直接获胜 ==> base case
                {
                    dp[i] = true;
                    x++;
                }
                else
                {
                    // 状态转移
                    // 遍历  dp[i] = !dp[ i - n^2 ....](n<x[超出(为负数)无意义])
                    // 如果上一个移动输了，那么j + n^2 必赢
                    // 示例: 1 = true  2 = false 3 = true (因为 2 = false,故2+1^2 = true)
                    // 这一手win = 石头=n^2 or 上一手输了
                    for (int j = 1; j < x; j++)
                    {
                        if (!dp[i - j * j])
                        {
                            dp[i] = true;
                            break;
                        }
                    }
                }
            }

            return dp[n - 1];

        }

        private static Dictionary<int, bool> _cache = new Dictionary<int, bool>();
        //Runtime: 212 ms
        //Memory Usage: 24.4 MB
        public bool Simple(int n)
        {
            if (_cache.ContainsKey(n)) return _cache[n];
            bool res = false;
            double sqrt = Math.Sqrt(n);
            if (sqrt % 1 == 0) res = true;
            else
            {

                int floor = (int)sqrt;

                for (int i = 1; i <= floor; i++)
                {
                    var extra = n - (i * i);
                    if (!Simple(extra))
                    {
                        res = true;
                        break;
                    }
                }

            }

            return _cache[n] = res;
        }

    }
}
