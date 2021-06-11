using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/7/2021 11:12:39 AM
    /// @source :https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/603/week-1-june-1st-june-7th/3769/ 
    /// @des : 给定一个未排序的整数数组nums，返回最长的连续元素序列的长度。
    /// </summary>
    [Optimize(FlagConst.Slow)]
    public class Longest_Consecutive_Sequence
    {

        // 0 <= nums.length <= 10^5
        //-10^9 <= nums[i] <= 10^9

        // Your runtime beats 33.76 % 
        public int Try(int[] nums)
        {
            /*
             * 只有最大+最小的数会（通过next 或prev）被访问到 =>  只有最大+最小的数有意义
             */
            int res = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dic.ContainsKey(num)) continue;

                bool existsPrev = dic.TryGetValue(num - 1, out var prev), existsNext = dic.TryGetValue(num + 1, out var next);

                int count = 1;
                if (existsNext && existsPrev)
                {
                    count = 1 + prev + next;
                    dic[num - prev] = dic[num + next] = count;
                }
                else if (existsNext)
                {
                    count = 1 + next;
                    dic[num + next] = count;
                }
                else if (existsPrev)
                {
                    count = 1 + prev;
                    dic[num - prev] = count;
                }
                dic[num] = count;
                res = Math.Max(res, count);
            }

            return res;

        }

        class Item
        {
            public int Index { get; set; }
        }

        // bug: [0,3,7,2,5,8,4,6,0,1]
        public int LongestConsecutive(int[] nums)
        {

            List<int> countList = new List<int>();

            Dictionary<int, Item> dic = new Dictionary<int, Item>();

            foreach (var num in nums)
            {
                if (dic.ContainsKey(num)) continue;

                bool existsPrev = dic.TryGetValue(num - 1, out var prev), existsNext = dic.TryGetValue(num + 1, out var next);

                if (existsNext && existsPrev)
                {
                    int count = countList[prev.Index] + 1 + countList[next.Index];
                    countList.Add(count);

                    next.Index = prev.Index = countList.Count - 1;
                    dic[num] = prev;
                }
                else if (existsNext)
                {
                    countList[next.Index]++;
                    dic[num] = next;
                }
                else if (existsPrev)
                {
                    countList[prev.Index]++;
                    dic[num] = prev;
                }
                else
                {
                    countList.Add(1);
                    dic[num] = new Item { Index = countList.Count - 1 };
                }
            }

            return countList.Max();

        }

    }
}
