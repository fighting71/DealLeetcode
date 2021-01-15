using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 4:13:54 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3603/
    /// @des : 
    ///     给定一个数组+数字x 
    ///     每次操作你可以：删除最左边的数字，并让x减去此值  或  删除最右边的数字，并让x减去此值
    ///     target: 最少进行几次操作 令x=0 
    ///     ps:不存在则返回-1
    /// </summary>
    public class Minimum_Operations_to_Reduce_X_to_Zero
    {

        // 1 <= nums.length <= 10^5
        //1 <= nums[i] <= 10^4
        //1 <= x <= 10^9

        // Your runtime beats 52.63 %
        public int Try2(int[] nums, int x)
        {
            if (x == 0) return 0;
            int len = nums.Length;
            int res = int.MaxValue;

            // 使用dic 保存 {num,从最左边开始使用了多少个数字}
            Dictionary<int, int> dic = new Dictionary<int, int>();

            int num = 0;
            int i = 0;
            for (; i < len; i++)
            {
                num += nums[i];
                if (num > x) break;
                if (num == x)
                {
                    res = Math.Min(res, i + 1);
                    break;
                }
                dic[num] = i + 1;
            }

            num = 0;
            for (int j = len - 1; j > i ; j--) // && j < res
            {
                num += nums[j];
                if (num > x) break;
                if (num == x)
                {
                    res = Math.Min(res, len - j);
                    break;
                }
                var diff = x - num;
                if (dic.ContainsKey(diff))
                {
                    res = Math.Min(res, len - j + dic[diff]);
                }
            }

            return res > nums.Length ? -1 : res;
        }

        public int Try(int[] nums, int x)
        {
            int len = nums.Length;
            if (x == 0) return 0;

            int res = int.MaxValue;

            int left = 0;
            for (int i = 0; i < len; i++)
            {
                left += nums[i];
                if (left == x)
                {
                    res = Math.Min(res, i + 1);
                    break;
                }
                if (left > x) break;
            }
            int right = 0;
            for (int i = 0; i < len; i++)
            {
                right += nums[len - 1 - i];
                if (right == x)
                {
                    res = Math.Min(res, i + 1);
                    break;
                }
                if (right > x) break;
            }

            left = 0;
            for (int i = 0; i < len; i++)
            {
                left += nums[i];

                if(left == x)
                {
                    res = Math.Min(res, i + 1);
                    break;
                }
                right = left;
                for (int j = len - 1; j > i; j--)
                {
                    right += nums[i];

                    if(right == x)
                    {
                        res = Math.Min(res, i + 1 + len - j);
                        break;
                    }

                    if (right > x) break;
                }

            }

            return res == int.MaxValue ? -1 : res;

        }

        public int Simple(int[] nums, int x)
        {
            int res = Help(nums, x, 0, 0, nums.Length - 1);
            return res == int.MaxValue ? -1 : res;
        }

        private int Help(int[] nums, int x, int count, int l, int r)
        {
            if (x == 0) return count;
            if (x < 0 || l > r) return int.MaxValue;
            if (l == r) return Help(nums, count + 1, x - nums[l], l++, r);

            return Math.Min(Help(nums, count + 1, x - nums[l], l + 1, r), Help(nums, count + 1, x - nums[r], l, r - 1));

        }

    }
}
