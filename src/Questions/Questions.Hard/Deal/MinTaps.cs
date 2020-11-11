using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 1/21/2020 10:41:00 AM
    /// @source : https://leetcode.com/problems/minimum-number-of-taps-to-open-to-water-a-garden/
    /// @des : 在x轴上有一个长度为n的花园
    /// 
    ///     给定一个整数n和一个长度为n + 1的整数数组范围，其中range [i](0索引)表示第i个水龙头可以浇灌的区域[i - ranges[i]， i + ranges[i]]如果它是打开的。
    ///     
    ///     求能浇灌整个花园的最少花洒数(没有返回-1)
    ///     
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class MinTaps
    {


        public int Solution(int n, int[] ranges)
        {

            int[] step = new int[n + 1];

            int res = n + 2, l, r, lastR,maxR = 0;

            for (int i = 0; i < ranges.Length; i++)
            {

                if (ranges[i] == 0) continue;

                l = i - ranges[i];
                r = i + ranges[i];

                if (l <= 0)
                    if (r >= n) return 1;
                    else step[i] = 1;
                else
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (step[j] == 0 || (lastR = j + ranges[j]) >= r || lastR < l) continue;

                        if (step[i] == 0) step[i] = step[j] + 1;
                        else step[i] = Math.Min(1 + step[j], step[i]);
                        if (r >= n) res = Math.Min(res, step[i]);
                    }

                    maxR = r;
                }

            }

            return res == n + 2 ? -1 : res;
        }

        public int Clear(int n, int[] ranges)
        {

            int[] step = new int[n + 1];

            int res = n + 2,l,r;

            for (int i = 0; i < ranges.Length; i++)
            {

                if (ranges[i] == 0) continue;

                l = i - ranges[i];

                if (l > n) continue;

                r = i + ranges[i];

                if (l <= 0)
                    if (r >= n) return 1;
                    else step[i] = 1;
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (step[j] == 0 || j + ranges[j] >= r || j + ranges[j] < l) continue;

                        if (step[i] == 0)
                            step[i] = step[j] + 1;
                        else
                            step[i] = Math.Min(1 + step[j], step[i]);

                        if (r >= n)
                            res = Math.Min(res, step[i]);
                    }
                }

            }

            return res == n + 2 ? -1 : res;
        }

        // bug
        public int Try2(int n, int[] ranges)
        {
            return Helper(-1, -1, n, ranges, 0, 0);
        }

        // bug
        public int Helper(int l,int r,int n,int[] arr,int index,int joinCount)
        {

            if (index == arr.Length) return -1;

            if (l == 0 && r >= n) return joinCount;

            var res = -1;

            for (int i = index; i < arr.Length; i++)
            {

                if (arr[i] == 0) continue;

                int newL = Math.Max(i - arr[i], 0), newR = Math.Min(i + arr[i], n);
                if (newL >= l && newR <= r) continue;// 区间重复
                if (newR < l) continue;// 无法连接

                // 进行连接
                var emp = Helper(Math.Min(l, newL), Math.Max(r, newR), n, arr, index + 1, joinCount + 1);

                if (emp != -1)
                {
                    if (res == -1) res = emp;
                    else res = Math.Min(res, emp);
                }

            }

            // 返回连接数
            return res;
        }

        /// <summary>
        /// pass basic test
        /// 
        ///  Runtime: 916 ms, faster than 5.00% of C# online submissions for Minimum Number of Taps to Open to Water a Garden.
        ///  Memory Usage: 28.3 MB, less than 100.00% of C# online submissions for Minimum Number of Taps to Open to Water a Garden.
        ///  
        ///    竟然通过了...
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public int Try(int n, int[] ranges)
        {

            // 记录每个花洒需要的数量
            int[] step = new int[n + 1], 
                // 记录每个节点的 [left,
                left = new int[n + 1],
                // 记录每个节点的 ,right]
                right = new int[n + 1];

            // 需要的花洒数
            int res = n + 2;

            for (int i = 0; i < ranges.Length; i++)
            {

                // skip
                if (ranges[i] == 0) continue;

                // record [left,right] 方便计算
                left[i] = i - ranges[i];
                right[i] = i + ranges[i];

                if (left[i] <= 0)
                    if (right[i] >= n) return 1;
                    // sp:能够到达左终点，记为1方便计算
                    else step[i] = 1;
                else
                {
                    // 中间区域 即洒不到 0 也洒不到 n,==>需要依赖其他花洒
                    // 遍历之前的花洒
                    for (int j = 0; j < i; j++)
                    {
                        // 若之前的花洒洒不到 0 skip
                        // right[j] >= right[i] 重复 skip
                        // right[j] < left[i] 无法连接 skip
                        if (step[j] == 0 || right[j] >= right[i] || right[j] < left[i]) continue;

                        // 初次连接直接复制
                        if(step[i] == 0)
                        {
                            step[i] = step[j] + 1;
                        }
                        else // 二次连接 比较之前连接需要的花洒数
                        {
                            step[i] = Math.Min(1 + step[j], step[i]);
                        }

                        // 能到达right 则 重新计算需要花洒数总和.
                        if (right[i] >= n)
                            res = Math.Min(res, step[i]);
                    }
                }

            }

            return res == n + 2 ? -1 : res;
        }

        public int Thinking(int n, int[] ranges)
        {
            // 移动位置 初始-》0
            int place = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                // 不考虑无意义浇灌 水龙头
                if (ranges[i] == 0) continue;

                // 获取[left,right]区域
                int left = i - ranges[i], right = i + ranges[i];
                // 如果 place>=left 表示place可以移动 
                // 如果 right>place 表示place移动是有效(没必要退后)
                if (place >= left && right > place) // can move
                    place = right;

                // 足够到达n则answer
                if (place >= n) return 1;
            }

            return -1;

        }

        #region Other Solution

        /// <summary>
        /// 
        /// source:https://leetcode.com/problems/minimum-number-of-taps-to-open-to-water-a-garden/discuss/484235/JavaC%2B%2BPython-Similar-to-LC1024
        /// 
        /// Runtime: 112 ms, faster than 84.00% of C# online submissions for Minimum Number of Taps to Open to Water a Garden.
        /// Memory Usage: 27.7 MB, less than 100.00% of C# online submissions for Minimum Number of Taps to Open to Water a Garden.
        /// 
        /// amazing .... 
        /// 
        /// </summary>
        /// <returns></returns>
        public int OtherSolution(int n, int[] A)
        {

            // 想到了dp ... 但还是初级
            // 数组中的值表示需要的花洒数
            int[] dp = new int[n + 1];

            // 每个值赋值为一个达不到的值
            Array.Fill(dp, n + 2);

            // dp[0] = 0 表示如果花洒能够到第一个(可以连接) 表示left通过
            dp[0] = 0;

            // 遍历每个花洒
            for (int i = 0; i <= n; ++i)

                // 遍历花洒i能洒到的最左节点 到 最右节点
                // +1说明: 
                //      当A[i]为0时 直接跳过遍历
                //      当A[i]为1时 跳过i-1 why? 因为下方基准为 dp[Math.Max(0, i - A[i])]  dp[i-1] + 1 与 dp[i-1] 无需比较
                // Math.Max(i - A[i] + 1, 1)中的 第二个1 ： 因为dp[0]为0 没必要处理...
                for (int j = Math.Max(i - A[i] + 1, 1); j <= Math.Min(i + A[i], n); ++j)

                    // 节点j需要的最小花洒数=Math.Min(当前节点j需要的最小花洒数,dp[i能连接到的最左边的节点] + 1)
                    // 为什么最左的永远是最小的/为什么比较固定下标 (i - A[i]) ? 
                    //      初始dp中的值为:[0,n+2,n+2,n+2...] 故初始时dp[Math.Max(0, i - A[i])] 要不是0要不就是n+2
                    //      为0时 节点j需要的最小花洒数=1 无需多说....
                    // 遍历每个花洒 然后遍历 从 能洒到的最左节点到最右节点  =》 从左到右 固定比较 (i - A[i]) 赋值 所以比较过后 区域恒定dp[左]>=dp[右]
                    // 然后遍历是左=>右 所以 所有区域都是 dp[左]>=dp[右]
                    dp[j] = Math.Min(dp[j], dp[Math.Max(0, i - A[i])] + 1);
            return dp[n] < n + 2 ? dp[n] : -1;
        }

        #endregion

    }
}
 