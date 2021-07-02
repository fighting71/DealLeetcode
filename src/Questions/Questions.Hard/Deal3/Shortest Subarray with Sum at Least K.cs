using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/30/2021 5:31:08 PM
    /// @source : https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/
    /// @des :
    ///     
    ///     返回sum至少为k的最短的、非空的、连续的nums子数组的长度。
    ///     如果没有sum大于等于k的非空子数组，则返回-1。
    /// 
    /// </summary>
    [Obsolete(FlagConst.DontUnderstand + FlagConst.OtherSolution)]
    public class Shortest_Subarray_with_Sum_at_Least_K
    {

        // todo : try solution
        #region other solution

        // source: https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/discuss/143726/C%2B%2BJavaPython-O(N)-Using-Deque
        public int shortestSubarray(int[] A, int K)
        {
            int N = A.Length, res = N + 1;
            int[] B = new int[N + 1];
            for (int i = 0; i < N; i++) B[i + 1] = B[i] + A[i];
            LinkedList<int> d = new LinkedList<int>();
            for (int i = 0; i < N + 1; i++)
            {
                while (d.Count > 0 && B[i] - B[d.First.Value] >= K)
                {
                    res = Math.Min(res, i - d.First.Value);
                    d.RemoveFirst();
                }
                // 第二个while循环的目的是什么？
                //继续B[D[i]]增加双端队列。


                //为什么保持双端队列增加？
                //如果B[i] <= B[d.back()]而且我们已经知道了i > d.back()，就意味着与 相比d.back()，
                //B[i]可以帮助我们使子数组长度更短，总和更大。所以不需要保留d.back()在我们的双端队列中。
                while (d.Count > 0 && B[i] <= B[d.Last.Value])
                    d.RemoveLast();
                d.AddLast(i);
            }
            return res <= N ? res : -1;
        }

        #endregion



        // 1 <= nums.length <= 50000
        //-10^5 <= nums[i] <= 10^5
        //1 <= k <= 10^9

        // bug
        public int Simple(int[] nums, int k)
        {
            int res = 0;
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                int sum = 0;
                for (int j = i; j < len; j++)
                {
                    sum += nums[j];

                    if (sum >= k)
                    {
                        res++;
                    }

                }
            }
            return res == 0 ? -1 : res;
        }

    }
}
