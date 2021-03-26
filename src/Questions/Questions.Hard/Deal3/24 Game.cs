using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/23/2021 3:02:15 PM
    /// @source : https://leetcode.com/problems/24-game/
    /// @des : 
    ///     你有4张卡片，每张卡片上都有从1到9的数字。您需要判断它们是否可以通过*、/、+、-、(，)操作来获得24的值。
    /// </summary>
    public class _24_Game
    {

        const int target = 24;
        const int len = 4;
        public bool Try2(int[] nums)
        {
            return Help(nums.ToList(), 0, 1);
        }

        private bool Help(List<int> list, int num, int dividend)
        {
            if (list.Count == 0)
            {
                return dividend != 0 && num % dividend == 0 && num / dividend == 24;
            }
            for (int i = 0; i < list.Count; i++)
            {
                var clone = new List<int>(list);
                clone.RemoveAt(i);
                int curr = list[i];
                if (
                Help(clone, num + dividend * curr, dividend) ||
                Help(clone, num - dividend * curr, dividend) ||
                Help(clone, num * curr, dividend) ||
                Help(clone, num, dividend * curr)
                    )
                {
                    return true;
                }
            }
            return false;
        }
        // 4 /(1 - 2/3)
        /**
         * abcd
         * a(bcd)
         * ab(cd)
         * (ab)(cd)
         * (abc)d
         */
        // abcd
        //a+(bcd) a + b + (cd)

        // bug : 卡牌的组合是无序的... 即 1234 == 4132
        public bool Try(int[] nums)
        {

            List<(int num, int dividend)>[][] dp = new List<(int num, int dividend)>[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new List<(int num, int dividend)>[len + 1];
                dp[i][1] = new List<(int num, int dividend)>()
                {
                    {(nums[i],1) }
                };
            }

            for (int k = 2; k < 5; k++)
            {
                for (int i = 0; i < 5 - k; i++)
                {
                    List<(int num, int dividend)> list = new List<(int num, int dividend)>();

                    for (int count = 1; count < k; count++)
                    {

                        var left = dp[i][count];
                        var right = dp[i][k - count];

                        foreach (var itemL in left)
                        {
                            foreach (var itemR in right)
                            {
                                list.Add((itemL.num * itemR.dividend + itemR.num * itemL.dividend, itemL.dividend * itemR.dividend));
                                list.Add((itemL.num * itemR.dividend - itemR.num * itemL.dividend, itemL.dividend * itemR.dividend));
                                list.Add((itemL.num * itemR.num, itemL.dividend * itemR.dividend));
                                list.Add((itemL.num * itemR.dividend, itemL.dividend * itemR.num));
                            }
                        }
                    }
                    dp[i][k] = list;
                }
            }

            return dp[0][4].Any(u => u.dividend != 0 && u.num % u.dividend == 0 && u.num / u.dividend == 24);
        }

        public bool Think(int[] nums)
        {
            List<(int num, int dividend)> list = new List<(int num, int dividend)>();

            Help(1, len, nums[0], 1);

            if (list.Any(u => u.num % u.dividend == 0 && u.num / u.dividend == target)) return true;

            list.Clear();

            Help(2, len, nums[1], 1);

            if (list.Any(u => u.num * nums[0] % u.dividend == 0 && u.num * nums[0] / u.dividend == target)) return true;

            // ... 其他情况

            return true;
            void Help(int i, int end, int num, int dividend)
            {
                if (i == end)
                {
                    list.Add((num, dividend));
                    return;
                }

                var curr = nums[i];

                // +
                Help(i + 1, end, num + curr * dividend, dividend);
                // -
                Help(i + 1, end, num - curr * dividend, dividend);

                // *
                Help(i + 1, end, num * curr, dividend);

                // /
                Help(i + 1, end, num, dividend * curr);


            }

        }

    }
}
