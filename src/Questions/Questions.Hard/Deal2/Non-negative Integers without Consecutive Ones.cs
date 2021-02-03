using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/3/2021 2:45:35 PM
    /// @source : https://leetcode.com/problems/non-negative-integers-without-consecutive-ones/
    /// @des : 
    ///     给定一个正整数n，求小于或等于n且二进制表示中不包含连续1的非负整数的数目。
    /// </summary>
    [Favorite(FlagConst.DP, "多状态转移")]
    public class Non_negative_Integers_without_Consecutive_Ones
    {



        // Note: 1 <= n <= 10^9

        // Runtime: 40 ms, faster than 75.00% of C# online submissions for Non-negative Integers without Consecutive Ones.
        // Memory Usage: 17.3 MB, less than 16.67% of C# online submissions for Non-negative Integers without Consecutive Ones.
        // ohho 
        public int Try3(int num)
        {
            if (num == 0) return 0;
            List<int> list = new List<int>();
            while (num > 0)
            {
                list.Insert(0, num % 2);
                num /= 2;
            }

            // 参考Try方法进行转移
            //      这里参考Try而不参考Simple是由于 Simple在结束时进行了  if (sum <= clone) 检查，故使用Simple作为dp的话，不能保证next中的值都符合curr的要求
            // dp[canChoiceAll][prevIsOne]
            // 由于只会用到next故简化dp=>next
            int[][] next = getNewArr();

            // base case
            next[1][0] = next[1][1] = next[0][0] = next[0][1] = 1;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                var curr = getNewArr();
                bool isOne = list[i] == 1;
                // if canChoiceAll then next[1][0] + next[1][1]
                //      canChoiceAll 表示 接下来随便选 可以1也可以0
                curr[1][0] = next[1][0] + next[1][1];
                //      当前已经是1了 为保证不连续 next只能选0
                curr[1][1] = next[1][0];
                //      当前是1 然后选择了0     表示降低了，那么后面的值可以任选
                //      示例： 101  -> [0??] 由于第一位降低了，那么后面的可以随便选0或1 因为就算全1也符合小于num的条件
                curr[0][0] = next[isOne ? 1 : 0][0] + (isOne ? next[0][1] : 0);
                curr[0][1] = next[isOne ? 1 : 0][0];
                next = curr;
            }
            return next[0][0];
            int[][] getNewArr()
            {
                var arr = new int[2][];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new int[2];
                }
                return arr;
            }

            #region full dp

            //    // dp[index][hasZero][prevIsOne]
            //    int[][][] dp = new int[list.Count][][];

            //for (int i = 0; i < dp.Length; i++)
            //{
            //    dp[i] = new int[2][];
            //    for (int j = 0; j < dp[i].Length; j++)
            //    {
            //        dp[i][j] = new int[2];
            //    }
            //}

            //for (int i = list.Count - 1; i >= 0; i--)
            //{
            //    bool isOne = list[i] == 1;
            //    var next = dp[i + 1];
            //    dp[i][1][0] = next[1][0] + (isOne ? next[1][1] : 0);
            //    dp[i][1][1] = next[1][0];
            //    dp[i][0][0] = next[isOne ? 1 : 0][0] + (isOne ? next[1][1] : 0);
            //    dp[i][0][1] = next[isOne ? 1 : 0][0];
            //}

            //return dp[0][0][0];

            #endregion

        }

        // 慢于Simple
        public int Try2(int num)
        {
            var clone = num;
            int count = 0;
            while (num > 0)
            {
                count++;
                num /= 2;
            }
            int res = 0;

            Helper(0, 0, false);

            return res;

            void Helper(int index, int sum, bool prevIsOne)
            {
                if ((sum << (count - index)) > clone) return;
                if (index == count)
                {
                    res++;
                    return;
                }
                if (!prevIsOne)
                {
                    Helper(index + 1, sum * 2 + 1, true);
                }
                Helper(index + 1, sum * 2, false);

            }

        }

        // time limit ... 慢于Simple
        public int Try(int num)
        {
            List<int> list = new List<int>();
            int clone = num, res = 0;
            while (num > 0)
            {
                list.Insert(0, num % 2);
                num /= 2;
            }

            Helper(0, 0, false, false);

            return res;

            void Helper(int index, int sum, bool prevIsOne, bool hasZero)
            {
                if (index == list.Count)
                {
                    res++;
                    return;
                }

                bool isOne = list[index] == 1;

                if (!prevIsOne && (hasZero || isOne))
                {
                    Helper(index + 1, sum * 2 + 1, true, hasZero);
                }

                if (!hasZero && isOne)
                {
                    hasZero = true;
                }

                Helper(index + 1, sum * 2, false, hasZero);
            }

        }

        // time limit , 实际够用了已经...
        public int Simple(int num)
        {
            var clone = num;
            int count = 0;
            while (num > 0)
            {
                count++;
                num /= 2;
            }
            int res = 0;

            Helper(0, 0, false);

            return res;

            void Helper(int index, int sum, bool prevIsOne)
            {
                if (index == count)
                {
                    if (sum <= clone)
                        res++;
                    return;
                }
                if (!prevIsOne)
                {
                    Helper(index + 1, sum * 2 + 1, true);
                }
                Helper(index + 1, sum * 2, false);

            }
        }

    }
}
