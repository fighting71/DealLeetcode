using System;
using System.Collections.Generic;
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

    }
}
 