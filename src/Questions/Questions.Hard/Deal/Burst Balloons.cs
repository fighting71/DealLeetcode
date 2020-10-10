using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/26/2020 3:52:45 PM
    /// @source : https://leetcode.com/problems/burst-balloons/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.DP)]
    [Obsolete("on thinking。。。。。。。。。。")]
    public class Burst_Balloons
    {

        /**
         * You may imagine nums[-1] = nums[n] = 1. They are not real therefore you can not burst them.
0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100
         */

        // 不大行，如果n = 100, 光计算2个元素组合都会有 100*99 次...

        // bug : [35,16,83,87,84,59,48,41,20,54]
        // expected:1849648 output:1791124
        public int Try2(int[] nums)
        {
            var len = nums.Length;
            if (len == 0) return 0;
            if (len == 1) return nums[0];
            if (len == 2) return nums[0] > nums[1] ? nums[0] * (nums[1] + 1) : nums[1] * (nums[0] + 1);
            if (len == 3) return nums[0] * nums[1] * nums[2] + Try2(new[] { nums[0], nums[2] });


            int res = 0;

            //5 = 5
            //5,5 = 30
            //3,5,5 = 95    *** 此处是删除8而非最小的3...
            //3,5,8,5 = 295
            //3,5,8,1,5 = 335
            //3,1,5,8,1,5 = 350

            var list = nums.ToList();

            while (list.Count > 3)
            {

                // 找到3个最大的数

                int[] maxNum = list.Select((num, index) => new { num, index }).OrderByDescending(u => u.num).Take(3).OrderBy(u => u.index).Select(u => u.index).ToArray();

                while (maxNum[1] - maxNum[0] != 1)
                {
                    var min = maxNum[0] + 1;
                    for (int i = min + 1; i < maxNum[1]; i++)
                    {
                        if (list[i] <list[min]) min = i;
                    }

                    res += list[min] * (min == 0 ? 1 : list[min - 1]) * (min == list.Count - 1 ? 1 : list[min + 1]);
                    list.RemoveAt(min);
                    maxNum[1]--;
                    maxNum[2]--;
                }


                while (maxNum[2] - maxNum[1] != 1)
                {
                    var min = maxNum[1] + 1;
                    for (int i = min + 1; i < maxNum[2]; i++)
                    {
                        if (list[i] < list[min]) min = i;
                    }

                    res += list[min] * (min == 0 ? 1 : list[min - 1]) * (min == list.Count - 1 ? 1 : list[min + 1]);
                    list.RemoveAt(min);
                    maxNum[2]--;
                }

                res += list[maxNum[0]] * list[maxNum[1]] * list[maxNum[2]];
                list.RemoveAt(maxNum[1]);

                //int min = 0;

                //for (int i = 1; i < list.Count; i++)
                //{
                //    if (nums[list[i]] < nums[list[min]]) min = i;
                //}

                //res += nums[list[min]] * (min == 0 ? 1 : nums[list[min - 1]]) * (min == list.Count - 1 ? 1 : nums[list[min + 1]]);
                //list.RemoveAt(min);
            }

            return res + Try2(list.ToArray());
        }

        public int Try(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var res = Help2(nums, nums.Select((num, index) => index).ToList());

            foreach (var item in cache.OrderBy(u => u.Key.Length).ThenBy(u => u.Value))
            {
                Console.WriteLine($"{string.Join(',', item.Key.Split(',').Select(u => nums[int.Parse(u)]))} = {item.Value}");
            }

            return res;
        }

        Dictionary<string, int> cache = new Dictionary<string, int>();

        private int Help2(int[] nums, List<int> list)
        {
            string key = string.Join(',', list);
            if (cache.ContainsKey(key)) return cache[key];
            if (list.Count == 1) return cache[key] = nums[list[0]];
            int res = 0;
            for (int i = 0; i < list.Count; i++)
            {
                // break
                var reward = nums[list[i]] * (i == 0 ? 1 : nums[list[i - 1]]) * (i == list.Count - 1 ? 1 : nums[list[i + 1]]);
                var newList = new List<int>(list);
                newList.RemoveAt(i);
                res = Math.Max(res, reward + Help2(nums, newList));
            }

            cache[key] = res;
            return res;

        }

        public int Simple(int[] nums)
        {
            return Help(nums, nums.Select((num, index) => index).ToList());
        }

        // 递归只能用来当暴力破解的份了~
        private int Help(int[] nums,List<int> list)
        {
            if (list.Count == 1) return nums[list[0]];
            int res = 0;
            for (int i = 0; i < list.Count; i++)
            {
                // break
                var reward = nums[list[i]] * (i == 0 ? 1 : nums[list[i - 1]]) * (i == list.Count - 1 ? 1 : nums[list[i + 1]]);
                var newList = new List<int>(list);
                newList.RemoveAt(i);
                res = Math.Max(res, reward + Help(nums, newList));
            }

            return res;

        }

        public class Old
        {

            public int Try(int[] nums)
            {
                int len = nums.Length;
                if (len == 0) return 0;
                if (len == 1) return nums[0];
                if (len == 2) return nums[0] > nums[1] ? nums[0] * (nums[1] + 1) : nums[1] * (nums[0] + 1);
                //if (len == 3) return nums[0] * nums[1] * nums[2] + MaxCoins(new[] { nums[0], nums[2] });

                int first = nums[0], last = nums[len - 1];

                var coins = first > last ? first * (last + 1) : last * (first + 1);

                var arr = nums.Select((value, index) => new { index, value }).Where(u => u.index != 0 && u.index != len - 1).OrderBy(u => u.value).Select(u => u.index).ToArray();

                bool[] flag = new bool[len];

                int minIndex, prev, next;
                for (int i = 0; i < len - 3; i++)
                {
                    minIndex = arr[i];
                    prev = minIndex - 1;
                    next = minIndex + 1;
                    while (flag[prev])
                    {
                        prev--;
                    }

                    while (flag[next])
                    {
                        next++;
                    }

                    Console.WriteLine($"{nums[prev]} * {nums[minIndex]} *  {nums[next]}");

                    coins += nums[prev] * nums[minIndex] * nums[next];

                    flag[minIndex] = true;
                }

                int numA = arr[len - 3], numB = arr[len - 4], valueA = nums[numA], valueB = nums[numB];

                if (numA > numB)
                {
                    coins += Math.Max(valueA * last * valueB + first * valueB * last, valueA * valueB * first + first * valueB * last);
                }
                else
                {
                    coins += Math.Max(valueA * first * valueB + first * valueB * last, valueA * valueB * last + first * valueA * last);
                }

                return coins;

            }

            public int MaxCoins(int[] nums)
            {

                /**
                 * think:
                 *  
                 * first get center.
                 * 
                 */

                if (nums.Length == 0) return 0;
                if (nums.Length == 1) return nums[0];
                if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] * (nums[1] + 1) : nums[1] * (nums[0] + 1);
                if (nums.Length == 3) return nums[0] * nums[1] * nums[2] + MaxCoins(new[] { nums[0], nums[2] });
                var coins = 0;

                var orderArr = nums.Select((num, index) => new { index, num }).OrderBy(u => u.num).ToArray();

                bool[] flag = new bool[nums.Length];
                int count = 0;


                while (nums.Length - count > 3)
                {

                }

                coins += MaxCoins(new[] { orderArr[count++].num, orderArr[count++].num, orderArr[count].num });

                return coins;

            }

            private int GetValue(int[] nums, int index, bool[] flag)
            {

                int i = index - 1;
                while (i >= 0 && flag[i] == true)
                {
                    i--;
                }

                var l = i == -1 ? 1 : nums[i];

                i = index + 1;
                while (i < nums.Length && flag[i] == true)
                {
                    i++;
                }

                var r = i == nums.Length ? 1 : nums[i];

                flag[index] = true;

                return l * nums[index] + r;
            }
        }

    }
}
