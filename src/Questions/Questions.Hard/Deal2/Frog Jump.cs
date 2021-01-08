using Command.Attr;
using Command.Const;
using Command.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/7/2021 2:24:16 PM
    /// @source : https://leetcode.com/problems/frog-jump/
    /// @des :  一只青蛙去过河
    ///     给定河中的石头坐标，坐标数>=2 stones[0] = 0
    ///     从位置0开始起跳，初始跳跃单位为1，下一次可跳跃k-1/k/k+1个单位(必须往前跳)
    ///     不能跳下水，查看小跳蛙能否顺利跳到最后一个石头上
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class Frog_Jump
    {

        // 2 <= stones.length <= 2000
        //0 <= stones[i] <= 2^31 - 1
        //stones[i] == 0

        // Runtime: 102 ms, faster than 90% of C# online submissions for Frog Jump.

        // Runtime: 128 ms, faster than 83.47% of C# online submissions for Frog Jump.
        // Memory Usage: 45.3 MB, less than 5.79% of C# online submissions for Frog Jump.
        // 结束 over~
        public bool Optimize(int[] stones)
        {
            if (stones[1] != 1) return false;

            int len = stones.Length;

            bool[][] dp = new bool[len][];

            for (int i = 0; i < dp.Length; i++)
                dp[i] = new bool[len];

            Array.Fill(dp[len - 1], true);

            for (int i = len - 2; i >= 0; i--)
            {
                var num = stones[i];
                int maxStep = i + 1;
                for (int next = i + 1; next < len; next++) // 替换遍历所有跳跃单位为查看最大跳跃单位是否能到达next
                {
                    var successStep = stones[next] - num;
                    if (successStep > maxStep) break;
                    dp[i][successStep] = dp[next][successStep] || dp[next][successStep - 1] || dp[next][successStep + 1];
                }
            }

            return dp[0][1];
        }

        // Runtime: 384 ms, faster than 5.79% of C# online submissions for Frog Jump.
        // Memory Usage: 44.7 MB, less than 5.79% of C# online submissions for Frog Jump.
        // nice.
        // dp[i][j] i表示位置  j表示可能的跳跃单位
        public bool CanCross(int[] stones)
        {

            if (stones[1] != 1) return false;

            int len = stones.Length;

            // 方便查找坐标。
            IDictionary<int, int> indexDic = new Dictionary<int, int>();

            for (int i = 0; i < len; i++)
            {
                indexDic[stones[i]] = i;
            }

            bool[][] dp = new bool[len][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[len];
            }

            Array.Fill(dp[len - 1], true);

            for (int i = len - 2; i > 0; i--)
            {
                var num = stones[i];
                for (int j = 1; j <= i + 1; j++)// 坐标i可能的跳跃单位为{1,i+1} (必须前进+最多k+1)
                {
                    var curr = num + j;
                    if (indexDic.ContainsKey(curr))// 顺利跳到一个stone上
                    {
                        var index = indexDic[curr];
                        dp[i][j] = dp[index][j] || dp[index][j - 1] || dp[index][j + 1];// 查看此stone能否到达目标
                    }
                }
            }

            return dp[1][1] || dp[1][2];// dp[0][1] = dp[1][1] || dp[1][2] 影响不大的简化...

        }
        public bool Simple(int[] stones)
        {
            return Helper(stones, 0, 0);
        }

        private bool Helper(int[] stones, int curr, int step)
        {

            if (curr == stones[stones.Length - 1]) return true;
            if (!stones.Contains(curr)) return false;

            return Helper(stones, curr + step, step) || Helper(stones, curr + step + 1, step + 1) || (step > 1 && Helper(stones, curr + step - 1, step - 1));

        }

    }
}
