using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/11/2021 9:50:21 AM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3599/
    /// @des : 
    /// </summary>
    public class Create_Sorted_Array_through_Instructions
    {

        // 1 <= instructions.length <= 10^5
        // 1 <= instructions[i] <= 10^5
        //Return the total cost to insert all elements from instructions into nums. Since the answer may be large, return it modulo 10^9 + 7

        public int Optimize(int[] instructions)
        {
            int res = 0, len = instructions.Length;

            List<int> list = new List<int>(len);

            Dictionary<int, int> countDic = new Dictionary<int, int>();

            foreach (var num in instructions)
            {
                // GetIndex 主要耗时点.
                int index = GetIndex(list, num) + 1, min = index;
                if (countDic.ContainsKey(num))
                {
                    min = Math.Min(min, list.Count - min - countDic[num]);
                    countDic[num]++;
                }
                else
                {
                    min = Math.Min(min, list.Count - min);
                    countDic[num] = 1;
                }
                min = Math.Min(min, list.Count - min);
                res += min;
                res %= 1000_000_000 + 7;
                list.Insert(index, num);
            }

            return res;
        }

        // time limit...
        public int Try(int[] instructions)
        {
            int res = 0,len = instructions.Length;

            List<int> list = new List<int>(len);

            Dictionary<int, int> countDic = new Dictionary<int, int>();

            foreach (var num in instructions)
            {
                int index = GetIndex(list, num) + 1, min = index;
                if (countDic.ContainsKey(num))
                {
                    min = Math.Min(min, list.Count - min - countDic[num]);
                    countDic[num]++;
                }
                else
                {
                    min = Math.Min(min, list.Count - min);
                    countDic[num] = 1;
                }
                res += min;
                res %= 1000_000_000 + 7;
                list.Insert(index, num);
            }

            return res;
        }

        private int GetIndex(List<int> list,int target)
        {
            int left = 0, right = list.Count - 1;

            while (right >= left)
            {
                var mid = left + (right - left) / 2;// 等价于==> (left + right)/2  但前者能避免越界
                var num = list[mid];
                if (num == target) right = mid - 1;
                // a.由于mid已经查找过了，故没必要继续搜索
                else if (num > target) right = mid - 1;
                else left = mid + 1;
            }
            return right;

        }

        public int Simple(int[] instructions)
        {
            int res = 0;

            List<int> list = new List<int>();

            foreach (var item in instructions)
            {
                var min = list.Where(u => u < item).Count();
                min = Math.Min(list.Where(u => u > item).Count(), min);
                res += min;
            }

            return res;
        }

    }
}
