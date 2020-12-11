using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020September.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 3:08:29 PM
    /// @source : https://leetcode.com/problems/majority-element-ii/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.BoyerMoore)]
    public class Majority_Element_II
    {

        #region other solution

        /**
         * source: https://leetcode.com/problems/majority-element-ii/discuss/63520/Boyer-Moore-Majority-Vote-algorithm-and-my-elaboration
         * https://gregable.com/2013/10/majority-vote-algorithm-find-majority.html
         * http://www.cs.rug.nl/~wim/pub/whh348.pdf
         * Boyer-Moore多数表决算法
         */
        // Runtime: 244 ms, faster than 91.28% of C# online submissions for Majority Element II.
        // 666
        public IList<int> OtherSolution(int[] nums)
        {
            // a. 为什么是两个数？
            // 数量>总数量的1/3  的数最多有两个数
            // b. 处理时间:
            //  遍历n次
            //  查找n*2次
            //  总：3*n 因为n固定，故复杂度为O(1)

            // 1. 通过算法找出出现最为频繁的两个数
            int candidate = 0, candidate2 = 1, count = 0, count2 = 0;
            foreach (var num in nums)
            {
                if (num == candidate) count++;
                else if (num == candidate2) count2++;
                else if(count == 0)
                {
                    candidate = num;
                    count = 1;
                }
                else if(count2 == 0)
                {
                    candidate2 = num;
                    count2 = 1;
                }
                else
                {
                    count--;
                    count2--;
                }
            }

            // 2. 查看这两个数是否符合题意.
            count = nums.Where(u => u == candidate).Count();
            count2 = nums.Where(u => u == candidate2).Count();
            int condition = nums.Length / 3;

            if (count > condition && count2 > condition) return new []{ candidate, candidate2 };
            if (count > condition) return new []{ candidate };
            if (count2 > condition) return new []{ candidate2 };

            return Array.Empty<int>();
        }

        #endregion

        // 1 <= nums.length <= 5 * 104
        // -10^9 <= nums[i] <= 10^9

        // 稍微好点
        public IList<int> Optimize2(int[] nums)
        {
            Dictionary<int, int> _dic = new Dictionary<int, int>();

            IList<int> res = new List<int>();

            int condition = nums.Length / 3;

            foreach (var item in nums)
            {
                int count;
                if (_dic.ContainsKey(item)) count = ++_dic[item];
                else count = _dic[item] = 1;
                if (count == condition + 1) res.Add(item);
            }

            return res;

        }

        public IList<int> MajorityElement(int[] nums)
        {

            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic[item] = 1;
                }
            }

            return dic.Where(u => u.Value > nums.Length / 3).Select(u => u.Key).ToArray();

        }

        public IList<int> Optimize(int[] nums)
        {

            Dictionary<int, int> dic = new Dictionary<int, int>();

            int max = nums.Length / 3;

            foreach (var item in nums)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic[item] = 1;
                }
            }

            IList<int> res = new List<int>();

            foreach (var item in dic)
            {
                if(item.Value > max)
                {
                    res.Add(item.Key);
                }
            }

            return res;

        }

    }
}
