using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/11/2021 3:13:55 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/604/week-2-june-8th-june-14th/3775/
    /// @des : wtf
    /// 
    /// 有n个石头排成一排。
    /// 
    /// 在每个玩家的回合中，他们可以从一行中移走最左边的石头或最右边的石头，并获得剩余石头价值之和的点数。
    /// 
    /// 目标是最大化分数的差异
    /// 
    /// </summary>
    [Serie(FlagConst.DP)]
    public class Stone_Game_VII
    {

        // n == stones.length
        //2 <= n <= 1000
        //1 <= stones[i] <= 1000

        // Runtime: 152 ms
        // Memory Usage: 44.4 MB
        // Your runtime beats 66.67 % 
        public int Try(int[] stones)
        {

            int len = stones.Length;

            int[][] dp = new int[len][];

            int[] sumArr = new int[len];

            for (int i = 0; i < len; i++)
            {
                sumArr[i] = stones[i];
                dp[i] = new int[len];
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = 0; i <= len - l; i++)
                {
                    int right = i + l - 1, sum = sumArr[i] += stones[right];

                    dp[i][i + l - 1] = sum - Math.Min(
                            stones[i] + dp[i + 1][right],// left
                            stones[right] + dp[i][right - 1] // right
                        );
                    //dp[i][i + l - 1] = Math.Max(
                    //    sum - stones[i] - dp[i + 1][right],// left
                    //    sum - stones[right] - dp[i][right - 1] // right
                    //    );

                }
            }

            return dp[0][len - 1];

        }

        public int Simple(int[] stones)
        {

            /**
             * 定义dp: 
             * 
             *      dp[最左下标][最右下标] = 最大差值
             *      
             * 状态转移:
             *      sum = (i,...j)总积分
             *      dp[i][j] = Math.Max(
             *          (移走后能获得的积分 - 下一步对方能获得最大差值)
             *          移走 i => sum - stones[i] - dp[i + 1][j] 
             *          ,
             *          移走 j => sum - stones[j] - dp[i][j-1]
             *      );
             * 
             */

            int len = stones.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = 0; i <= len - l; i++)
                {

                    // 耗时
                    int sum = stones.Skip(i).Take(l).Sum();

                    dp[i][i + l - 1] = Math.Max(
                        sum - stones[i] - dp[i + 1][i + l - 1],// left
                        sum - stones[i + l - 1] - dp[i][i + l - 2] // right
                        );

                }
            }

            return dp[0][len - 1];

        }

    }
}
