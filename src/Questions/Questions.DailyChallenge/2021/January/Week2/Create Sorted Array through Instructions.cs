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
    ///     https://leetcode.com/problems/create-sorted-array-through-instructions/
    /// @des : 
    /// 
    ///     给定一个整数数组指令，要求您根据指令中的元素创建一个已排序的数组。你从一个空容器nums开始。对于指令中从左到右的每个元素，将其插入nums中。每次插入的费用是下列各项中的最小值:
    ///     当前nums中严格小于指令[i] 的元素数。
    ///     当前nums中严格大于指令[i] 的元素数。
    ///     例如，如果将元素3插入nums =[1,2,3,5]，则插入的代价是min(2,1)(元素1和2小于3，元素5大于3)，nums将变成[1, 2, 3, 3, 5]。
    ///     返回将指令中的所有元素插入nums的总代价。因为答案可能很大，所以以109 + 7取模返回它
    /// 
    /// </summary>
    [Obsolete("time limit")]
    public class Create_Sorted_Array_through_Instructions
    {

        // 1 <= instructions.length <= 10^5
        // 1 <= instructions[i] <= 10^5
        //Return the total cost to insert all elements from instructions into nums. Since the answer may be large, return it modulo 10^9 + 7

        #region other solution
        // /?/>???
        // source : https://leetcode.com/problems/create-sorted-array-through-instructions/discuss/927531/JavaC%2B%2BPython-Binary-Indexed-Tree
        int[] c;
        public int createSortedArray(int[] A)
        {
            int res = 0, n = A.Length, mod = (int)1e9 + 7;
            c = new int[100001];
            for (int i = 0; i < n; ++i)
            {
                res = (res + Math.Min(get(A[i] - 1), i - get(A[i]))) % mod;
                update(A[i]);
            }
            return res;
        }

        public void update(int x)
        {
            while (x < 100001)
            {
                c[x]++;
                x += x & -x;
            }
        }

        public int get(int x)
        {
            int res = 0;
            while (x > 0)
            {
                res += c[x];
                x -= x & -x;
            }
            return res;
        }
        #endregion

        // Runtime: 2236 ms, faster than 11.11% of C# online submissions for Create Sorted Array through Instructions.
        // Memory Usage: 46.7 MB, less than 55.56% of C# online submissions for Create Sorted Array through Instructions.
        // .... 干碎
        public int Try3(int[] instructions)
        {

            int res = 0, len = instructions.Length;
            Dictionary<int, int> countDic = new Dictionary<int, int>();

            List<int> list = new List<int>(len);

            int prev = 0, prevIndex = 0,prevNeed = 0,min,index;

            for (int i = 0; i < len; i++)
            {
                var num = instructions[i];
            //}
            //foreach (var num in instructions)
            //{

                if(prev == num)
                {
                    min = prevNeed;
                    index = prevIndex;
                    countDic[num]++;
                }
                else
                {
                    if (num > prev)
                    {
                        index = GetIndex(list, num, prevIndex, list.Count - 1) + 1;
                    }
                    else
                    {
                        index = GetIndex(list, num, 0, prevIndex) + 1;
                    }

                    min = index;
                    if (countDic.TryGetValue(num, out var count))
                    {
                        min = Math.Min(min, list.Count - min - count);
                        countDic[num]++;
                    }
                    else
                    {
                        min = Math.Min(min, list.Count - min);
                        countDic[num] = 1;
                    }
                }

                if (min != emptyCache[i])
                {

                }
                res = (res + min) % 1000_000_007;
                
                list.Insert(index, num);
                prev = num;
                prevIndex = index;
                prevNeed = min;

            }

            return res;
        }

        int[] emptyCache;

        // slow
        public int Try2(int[] instructions)
        {
            int res = 0, len = instructions.Length;

            List<int> list = new List<int>(len);
            emptyCache = new int[len];

            Dictionary<int, int> countDic = new Dictionary<int, int>();
            for (int i = 0; i < len; i++)
            //foreach (var num in instructions)
            {
                int num = instructions[i];
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
                //min = Math.Min(min, list.Count - min);
                emptyCache[i] = min;
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

        private int GetIndex(List<int> list, int target,int left ,int right)
        {
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
        private int GetIndex(List<int> list,int target)
        {
            return GetIndex(list, target, 0, list.Count - 1);

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
