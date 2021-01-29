using Command.Attr;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/28/2021 2:30:16 PM
    /// @source : https://leetcode.com/problems/reverse-pairs/
    /// @des : 
    ///     给定一个无序的数组
    ///     若对应i,j 有 i > j && nums[i] > 2*nums[j] 则匹配成功
    ///     获取数组中存在多少个匹配组合
    /// </summary>
    [Optimize]
    public class Reverse_Pairs
    {
        // The length of the given array will not exceed 50,000.
        // All the numbers in the input array are in the range of 32-bit integer.

        // hwo can faster?

        // 差不多。 告辞
        public int Optimize2(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int res = 0, max = int.MaxValue / 2 + 1, min = int.MinValue / 2 - 1, zeroCount = 0;

            List<int> negative = new List<int>(), nonnegative = new List<int>();

            foreach (var num in nums)
            {
                if (num == 0)
                {
                    res += nonnegative.Count;
                    zeroCount++;
                }
                else if (num > 0)
                {
                    if (nonnegative.Count == 0)
                    {
                        nonnegative.Add(num);
                        continue;
                    }
                    if (num >= max)
                    {
                        nonnegative.Insert(GetIndex2(nonnegative, num, 0, nonnegative.Count - 1), num);
                        continue;
                    }
                    int addIndex = GetIndex2(nonnegative, num, 0, nonnegative.Count - 1);
                    res += nonnegative.Count - GetIndex(nonnegative, num * 2, Math.Max(0, addIndex - 1), nonnegative.Count - 1);
                    nonnegative.Insert(addIndex, num);
                }
                else
                {
                    res += nonnegative.Count + zeroCount;
                    if (negative.Count == 0)
                    {
                        negative.Add(num);
                        continue;
                    }

                    if (num <= min)
                    {
                        res += negative.Count;
                        negative.Insert(GetIndex2(negative, num, 0, negative.Count - 1), num);
                        continue;
                    }
                    int addIndex = GetIndex2(negative, num, 0, negative.Count - 1);
                    res += negative.Count - GetIndex(negative, num * 2, 0, addIndex - 1);
                    negative.Insert(addIndex, num);
                }
            }

            return res;
            int GetIndex(List<int> list, int num, int left, int right)
            {
                while (right >= left)
                {
                    var mid = (right + left) / 2;
                    if (list[mid] > num)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return left;
            }

            int GetIndex2(List<int> list, int num, int left, int right)
            {
                while (right >= left)
                {
                    var mid = (right + left) / 2;

                    var midNum = list[mid];

                    if (midNum == num) return mid;
                    if (list[mid] > num) right = mid - 1;
                    else left = mid + 1;
                }

                return left;

            }

        }

        // Runtime: 508 ms, faster than 22.22% of C# online submissions for Reverse Pairs.
        // Memory Usage: 44 MB, less than 83.33% of C# online submissions for Reverse Pairs.
        // 差不多。
        public int Optimize(int[] nums)
        {
            if (nums.Length == 0) return 0;
            List<int> list = new List<int>() { nums[0] };

            int res = 0, max = int.MaxValue / 2 + 1, min = int.MinValue / 2 - 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var num = nums[i];

                if (num >= max)
                {
                    list.Insert(GetIndex2(num, 0, list.Count - 1), num);
                    continue;
                }

                if (num <= min)
                {
                    res += list.Count;
                    list.Insert(GetIndex2(num, 0, list.Count - 1), num);
                    continue;
                }

                int addIndex = GetIndex2(num, 0, list.Count - 1);

                if (num >= 0)
                {
                    res += list.Count - GetIndex(num * 2, Math.Max(0, addIndex - 1), list.Count - 1);
                }
                else
                {
                    res += list.Count - GetIndex(num * 2, 0, addIndex - 1);
                }

                //Console.WriteLine($"{i}-{res}");

                list.Insert(addIndex, num);
            }

            return res;
            int GetIndex(int num, int left, int right)
            {
                while (right >= left)
                {
                    var mid = (right + left) / 2;
                    if (list[mid] > num)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return left;
            }

            int GetIndex2(int num, int left, int right)
            {
                while (right >= left)
                {
                    var mid = (right + left) / 2;

                    var midNum = list[mid];

                    if (midNum == num) return mid;
                    if (list[mid] > num) right = mid - 1;
                    else left = mid + 1;
                }

                return left;

            }

        }

        // Runtime: 664 ms, faster than 22.22% of C# online submissions for Reverse Pairs.
        public int Try4(int[] nums)
        {
            if (nums.Length == 0) return 0;
            List<int> list = new List<int>() { nums[0] };

            int res = 0, max = int.MaxValue / 2 + 1, min = int.MinValue / 2 - 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var num = nums[i];

                if (num >= max)
                {
                    list.Insert(GetIndex2(num, 0, list.Count - 1), num);
                    continue;
                }

                if (num <= min)
                {
                    res += list.Count;
                    list.Insert(GetIndex2(num, 0, list.Count - 1), num);
                    continue;
                }

                var find = num * 2;

                int index = GetIndex(find, 0, list.Count - 1);

                //Console.WriteLine($"{i}-{list.Count - index}");

                res += list.Count - index;

                list.Insert(GetIndex2(num, 0, list.Count - 1), num);
            }

            return res;
            int GetIndex(int num, int left, int right)
            {
                while (right >= left)
                {
                    var mid = (right + left) / 2;
                    if (list[mid] > num)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return left;
            }

            int GetIndex2(int num, int left, int right)
            {
                while (right >= left)
                {
                    var mid = (right + left) / 2;

                    var midNum = list[mid];

                    if (midNum == num) return mid;
                    if (list[mid] > num) right = mid - 1;
                    else left = mid + 1;
                }

                return left;

            }

        }

        #region bug 
        // bug: [-5,-5]
        public int Try3(int[] nums)
        {

            List<int> list = new List<int>();

            int res = 0;
            foreach (var num in nums)
            {
                var find = num * 2;

                if (find >= 0)
                {
                    int index = GetIndex(find, 0, list.Count - 1);
                    res += list.Count - index;
                    list.Insert(GetIndex(num, 0, Math.Min(list.Count - 1, index)), num);
                }
                else
                {
                    list.Insert(GetIndex(num, 0, list.Count - 1), num);
                }
            }

            return res;
            int GetIndex(int num, int left, int right)
            {
                if (list.Count == 0) return 0;
                while (right >= left)
                {
                    var mid = (right + left) / 2;
                    if (list[mid] > num)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return left;
            }
        }

        // 200ms 不给过，气急败坏#@&
        public int Try2(int[] nums)
        {
            Console.WriteLine(JsonConvert.SerializeObject(nums));
            // 先排序数组
            List<int> list = nums.OrderBy(u => u).ToList();

            int res = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                var num = nums[i];
                // 删除当前元素
                list.Remove(num);
                var find = num / 2 + (num % 2 == 0 ? 0 : 1);

                // 查看集合中有多少小于当前元素的1/2 由于遍历时会删除之前的元素故可直接相加
                int index = GetIndex(find);

                Console.WriteLine($"{i}--{index}");

                res += index;
            }

            return res;

            int GetIndex(int num)
            {
                int left = 0, right = list.Count - 1;
                while (right >= left)
                {
                    var mid = (right + left) / 2;
                    if (list[mid] >= num)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return left;
            }

        }

        // time limit
        public int Try(int[] nums)
        {
            List<int> list = nums.OrderBy(u => u).ToList();

            int res = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                var num = nums[i];
                list.Remove(num);
                var find = num / 2 + (num % 2 == 0 ? 0 : 1);

                var index = GetIndex(find);

                if (list[index] == find)
                {
                    res += index;
                }
                else if (list[index] < find)
                {
                    res += index + 1;
                }
                else if (index > 0 && list[index - 1] < find)
                {
                    res += index;
                }

            }

            return res;

            int GetIndex(int num)
            {
                int left = 0, right = list.Count - 1;
                while (right > left)
                {
                    var mid = (right + left) / 2;
                    if (list[mid] >= num)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                return left;
            }

        }

        // time limit
        public int Simple(int[] nums)
        {
            int res = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                var half = nums[i] / 2 + (nums[i] % 2 == 0 ? 0 : 1);

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < half) res++;
                }
            }

            return res;
        }
        #endregion

    }
}
