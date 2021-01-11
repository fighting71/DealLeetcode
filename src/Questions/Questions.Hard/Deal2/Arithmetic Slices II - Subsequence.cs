using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 4:26:31 PM
    /// @source : https://leetcode.com/problems/arithmetic-slices-ii-subsequence/
    /// @des : 
    ///     返回数组A中等差子序列片的数量 (等差序列的长度>=3)
    ///     子序列： (P0, P1, ..., Pk) such that 0 ≤ P0 < P1 < ... < Pk < N.
    /// </summary>
    [Favorite(FlagConst.DP, FlagConst.Complex)]
    public class Arithmetic_Slices_II___Subsequence
    {

        // The input contains N integers. Every integer is in the range of -2^31 and 2^31-1 and 0 ≤ N ≤ 1000. The output is guaranteed to be less than 231-1.

        // Runtime: 176 ms, faster than 100.00% of C# online submissions for Arithmetic Slices II - Subsequence.
        // Memory Usage: 29.1 MB, less than 100.00% of C# online submissions for Arithmetic Slices II - Subsequence.
        // 成就感一下子就刷刷上来了~
        public int EfficientSolution(int[] arr)
        {
            int len = arr.Length, res = 0;

            // dic[num] = list(index,index2...) 方便查找target
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < len; i++)
            {
                var curr = arr[i];
                if (dic.ContainsKey(curr))
                {
                    dic[curr].Add(i);
                }
                else
                {
                    dic[curr] = new List<int>() { i };
                }
            }

            // dp[(index,diff)] = length
            // dp[(下标,差值)] = 序列长度(-2)
            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

            for (int i = len - 3; i >= 0; i--) // first ele index
            {
                for (int j = i + 1; j < len - 1; j++) // second ele index
                {

                    // 利用 long 来检查越界
                    var diffL = arr[j] - (long)arr[i];

                    if (diffL < int.MinValue || diffL > int.MaxValue) continue;

                    var targetL = arr[j] + diffL;

                    if (targetL < int.MinValue || targetL > int.MaxValue) continue;

                    int target = (int)targetL, diff = (int)diffL;

                    if (!dic.ContainsKey(target)) continue;

                    var key = (j, diff);

                    int curr = 0;
                    foreach (var index in dic[target]) // find next index
                    {
                        // 检查下标是否符合，序列需要保持顺序性 故 next_index 必须 > j
                        if (index > j)
                        {
                            curr++;
                            var nextKey = (index, diff);
                            if (dp.ContainsKey(nextKey)) curr += dp[nextKey];
                        }
                    }
                    dp[key] = curr;
                    res += curr;

                }
            }

            return res;
        }

        #region 递归版 
        /*
         * 递归大法好，完美的规避了数字重复√
         * Explain:
         *  两个一组进行遍历，寻找下一位
         *  
         *  若下一位差值匹配，则构成等差序列(2+len(next))
         *  len(排列方式)=序列长度-2，case:
         *      1,2,3 = 1
         *      1,2,3,4 = 1(2,3,4) + 2(1,2,3,4)
         *      1,2,3,4,5 = 1 + 2 + 3(1,2,3,4,5) + 1(1,3,5)
         *      ....
         */
        // slow.
        public int Recursion(int[] arr)
        {
            int len = arr.Length, res = 0;

            for (int i = len - 3; i >= 0; i--)
            {
                for (int j = i + 1; j < len; j++)
                {
                    res += Help(arr, arr[j] - arr[i], j + 1, j);
                }
            }

            return res;
        }

        private int Help(int[] arr, int diff, int i, int prev)
        {
            if (i == arr.Length) return 0;

            int res = 0;

            if (arr[i] - arr[prev] == diff)
            {
                res += 1 + Help(arr, diff, i + 1, i);
            }
            res += Help(arr, diff, i + 1, prev);
            return res;
        }
        #endregion

        /*
         * target: 处理数字重复问题
         */
        public int Try2(int[] arr)
        {
            int len = arr.Length, res = 0;

            //Dictionary<int, int>[] dp = new Dictionary<int, int>[len];

            //Dictionary<int, int> mul = new Dictionary<int, int>();

            //for (int i = len - 2; i >= 0; i--)
            //{
            //    var dic = new Dictionary<int, int>();
            //    int curr = arr[i];
            //    for (int j = i + 1; j < len; j++)
            //    {
            //        var diff = arr[j] - curr;

            //        if (dic.ContainsKey(diff))
            //        {
            //            continue;
            //        }

            //        if (dp[j] == null || !dp[j].ContainsKey(diff))
            //        {
            //            dic[diff] = 0;
            //        }
            //        else
            //        {
            //            int count = dp[j][diff] + 1;
            //            res += count;
            //            dic[diff] = count;
            //        }
            //    }
            //    dp[i] = dic;
            //}

            return res;
        }

        /*
         * bug : 数字重复问题:
         *  1,2,3,4,4,5
         *  1,2,2,3,4,4,5
         */
        public int Try(int[] arr)
        {
            int len = arr.Length, res = 0;

            // dic[diff] = count
            Dictionary<int, int>[] dp = new Dictionary<int, int>[len];

            for (int i = len - 2; i >= 0; i--)
            {
                var dic = new Dictionary<int, int>();
                int curr = arr[i];
                for (int j = i + 1; j < len; j++)
                {
                    var diff = arr[j] - curr;

                    //if (dic.ContainsKey(diff))
                    //{
                    //    mulitiple[i]++;
                    //    res += dic[diff] - 2;
                    //    continue;
                    //}

                    if (dp[j] == null || !dp[j].ContainsKey(diff))
                    {
                        dic[diff] = 2;
                    }
                    else
                    {
                        /*
                         * 2,4,6,8,10,12,14
                         * 
                         * 3=1
                         * 4=3  1+2
                         * 5=7  3 + 3 + 1
                         * 6=12 7 + 4 + 1
                         * 7=20 12 + 5 + 1 + 2
                         * 8=29 20 + 6 + ...
                         * 
                         */
                        int count = dp[j][diff] + 1;
                        //if (mulitiple[j] > 0)
                        //    res += mulitiple[j];
                        res += count - 2;
                        dic[diff] = count;
                    }
                }
                dp[i] = dic;
            }

            return res;
        }

    }
}
