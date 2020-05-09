using Command.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/30/2020 4:22:09 PM
    /// @source : https://leetcode.com/problems/count-of-smaller-numbers-after-self/
    /// @des : 
    /// </summary>
    [Obsolete("limit")]
    public class Count_of_Smaller_Numbers_After_Self
    {

        #region other solution by merge sort

        class Pair
        {
            public int index;
            public int val;
            public Pair(int index, int val)
            {
                this.index = index;
                this.val = val;
            }
        }

        /// <summary>
        /// Runtime: 240 ms, faster than 99.45% of C# online submissions for Count of Smaller Numbers After Self.
        /// Memory Usage: 34.9 MB, less than 100.00% of C# online submissions for Count of Smaller Numbers After Self.
        /// 
        /// 强大
        /// 
        /// source:https://leetcode.com/problems/count-of-smaller-numbers-after-self/discuss/76584/Mergesort-solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public List<int> countSmaller(int[] nums)
        {
            List<int> res = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return res;
            }
            Pair[] arr = new Pair[nums.Length];
            int[] smaller = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                arr[i] = new Pair(i, nums[i]);
            }
            mergeSort(arr, smaller);
            res.AddRange(smaller);
            return res;
        }
        private Pair[] mergeSort(Pair[] arr, int[] smaller)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }
            int mid = arr.Length / 2;
            Pair[] left = mergeSort(ArrayCopy(arr, 0, mid), smaller);
            Pair[] right = mergeSort(ArrayCopy(arr, mid, arr.Length), smaller);
            for (int i = 0, j = 0; i < left.Length || j < right.Length;)
            {
                if (j == right.Length || i < left.Length && left[i].val <= right[j].val)
                {
                    arr[i + j] = left[i];
                    smaller[left[i].index] += j;
                    i++;
                }
                else
                {
                    arr[i + j] = right[j];
                    j++;
                }
            }
            return arr;
        }

        private T[] ArrayCopy<T>(T[] source,int start,int end)
        {

            int len = end - start;

            T[] res = new T[len];

            Array.Copy(source, start, res, 0, len);
            return res;
        }

        #endregion

        public IList<int> Try3(int[] nums)
        {
            int len = nums.Length;

            int[] res = new int[len];
            int[] same = new int[len];

            Array.Fill(same, 1);

            for (int i = len - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        res[i] = Math.Max(res[i], res[j] + same[j]);
                    }
                    else if (nums[i] == nums[j])
                        same[i]++;
                    else same[j]++;
                }
            }

            return res;

        }

        // Time Limit
        public IList<int> Simple(int[] nums)
        {
            int len = nums.Length;

            int[] res = new int[len];

            for (int i = len - 2; i >= 0; i--)
            {
                int count = 0;
                for (int j = i + 1; j < len; j++)
                {
                    if (nums[i] > nums[j]) count++;
                }
                res[i] = count;
            }

            return res;
        }

        //Time Limit
        public IList<int> Try(int[] nums)
        {
            int len = nums.Length;

            int[] res = new int[len];

            if (len < 2) return res;

            IDictionary<int, int> dic = new SortedDictionary<int, int>();

            int min = nums[len - 1], num;
            dic[min] = 1;

            for (int i = len - 2; i >= 0; i--)
            {
                num = nums[i];
                if (num < min)
                {
                    min = num;
                    dic[min] = 1;
                    continue;
                }
                else if (num == min)
                {
                    dic[min]++;
                    continue;
                }

                foreach (var item in dic)
                {
                    if (item.Key >= nums[i]) break;
                    res[i] += item.Value;
                }
                if (dic.ContainsKey(num)) dic[num]++;
                else dic[num] = 1;
            }

            return res;
        }

        class Desc : IComparer<int>
        {
            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                return y - x;
            }
        }

        public IList<int> Try2(int[] nums)
        {
            int len = nums.Length;

            int[] res = new int[len];

            if (len < 2) return res;

            IDictionary<int, int[]> dic = new SortedDictionary<int, int[]>(new Desc());

            int num = nums[len - 1], min = num;
            dic[num] = new[] { len - 1, 1 };

            for (int i = len - 2; i >= 0; i--)
            {

                num = nums[i];

                if (dic.ContainsKey(num))
                {
                    res[i] = res[dic[num][1]];
                    dic[num][0] = i;
                    dic[num][1]++;
                }
                else if (num > min)
                {
                    foreach (var item in dic)
                    {
                        if (item.Key < num)
                        {
                            res[i] = res[item.Value[0]] + item.Value[1];
                            break;
                        }
                    }
                }
                else
                {
                    min = num;
                }

                dic[num] = new[] { i, 1 };

            }

            return res;
        }

    }
}
