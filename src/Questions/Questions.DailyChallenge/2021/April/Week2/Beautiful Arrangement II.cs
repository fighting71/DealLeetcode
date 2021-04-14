using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/12/2021 5:52:44 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3705/
    /// @des : 
    ///     给定一个n,k
    ///     要求返回一个数组：
    ///         1. 数组中包含1-n,且每个数字仅使用一次
    ///         2. 差值的定义：arr[i] - arr[i-1] (i>0)，要求整个数组中不同的差值仅有k个
    /// </summary>
    [Favorite(FlagConst.Special, "投机取巧")]
    public class Beautiful_Arrangement_II
    {

        // 123 3 2 1
        // 1234    1423
        // 12345 51423

        // The n and k are in the range 1 <= k < n <= 10^4.

        // Runtime: 204 ms
        // Memory Usage: 29.3 MB
        public int[] Optimize(int n, int k)
        {
            if (k == 1) return Enumerable.Range(1, n).ToArray();

            int[] res = new int[n];
            res[0] = n;
            int max = n - 1, min = 1, i = 1;
            while (--k > 0)
            {
                if (i % 2 == 0)
                {
                    res[i++] = max--;
                }
                else
                {
                    res[i++] = min++;
                }
            }

            if (i % 2 == 0)
            {
                for (; min <= max;)
                {
                    res[i++] = min++;
                }
            }
            else
            {
                for (; max >= min;)
                {
                    res[i++] = max--;
                }
            }

            return res;
        }

        // Runtime: 296 ms
        // Memory Usage: 29.6 MB
        public int[] ConstructArray(int n, int k)
        {

            /*
             * 乱拳打死问题~
             * 
             * 按示例来看：
             * 
             * 3 2 =  3 1 2
             * 8 3 =  8 1 7 6 5 4 3 2 
             * 8 7 =  8 1 7 2 6 3 5 4
             * 
             * 
             * summary => 
             *      n  n-(maxDiff) n-1 n-(maxDiff - 1) n-2
             * 
             */

            if (k == 1) return Enumerable.Range(1, n).ToArray();

            var list = Enumerable.Range(1, n - 1).ToList();

            int[] res = new int[n];

            int i = 1, prev = res[0] = n, diff = n - 1;
            bool isAdd = false;
            while (--k > 0)
            {
                int curr = prev + (isAdd ? diff : -diff);
                res[i++] = curr;
                list.Remove(curr);
                isAdd = !isAdd;
                prev = curr;
                diff--;
            }

            // 若此处不根据isAdd 会导致后面可能生成2个不一样的diff (按理只需要一个.)
            if (isAdd)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    res[i++] = list[j];
                }
            }
            else
            {
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    res[i++] = list[j];
                }
            }

            return res;
        }

        public bool Check(int n, int k, int[] res)
        {
            ISet<int> diffSet = new HashSet<int>(k);
            for (int i = 1; i < res.Length; i++)
            {
                var diff = res[i] - res[i - 1];
                diffSet.Add(diff);
            }
            var flag = diffSet.Count == k;
            if (!flag)
            {
                res = Optimize(n, k);
                //ConstructArray(n, k);
            }
            return flag;
        }

    }
}
