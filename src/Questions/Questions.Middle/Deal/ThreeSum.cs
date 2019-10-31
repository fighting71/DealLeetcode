using System;
using System.Collections.Generic;
using System.Text;
using Command.Attr;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/28 11:17:42
    /// @source : https://leetcode.com/problems/3sum/
    /// @des : 
    /// </summary>
    [FavoriteAttribute("引发思考，注意细节.")]
    public class ThreeSum
    {
        /**
         * Runtime: 312 ms, faster than 93.39% of C# online submissions for 3Sum.
         * Memory Usage: 34.8 MB, less than 15.00% of C# online submissions for 3Sum.
         *
         * 312ms ??? 。。。
         *
         * source:https://leetcode.com/problems/3sum/discuss/7380/Concise-O(N2)-Java-solution
         * 
         */
        public IList<IList<int>> OtherSolution(int[] num)
        {
            Array.Sort(num);
            List<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < num.Length - 2; i++)
            {
                // if (i == 0 || (i > 0 && num[i] != num[i - 1]))
                if (i == 0 || num[i] != num[i - 1])
                {
                    int lo = i + 1, hi = num.Length - 1, sum = 0 - num[i];
                    while (lo < hi)
                    {
                        // 充分利用排序特点 避免重复遍历... 
                        if (num[lo] + num[hi] == sum)
                        {
                            res.Add(new List<int>() {num[i], num[lo], num[hi]});
                            while (lo < hi && num[lo] == num[lo + 1]) lo++;
                            while (lo < hi && num[hi] == num[hi - 1]) hi--;
                            lo++;
                            hi--;
                        }
                        else if (num[lo] + num[hi] < sum) lo++;
                        else hi--;
                    }
                }
            }

            return res;
        }

        /**
         * Runtime: 344 ms, faster than 40.94% of C# online submissions for 3Sum.
         * Memory Usage: 35 MB, less than 15.00% of C# online submissions for 3Sum.
         *
         * 细微提升...
         * 
         */
        public IList<IList<int>> Solution(int[] nums)
        {
            Array.Sort(nums);

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            var len = nums.Length;
            // 对应数量替换为最大下标
            for (int i = 0; i < len; i++)
            {
                if (dictionary.ContainsKey(nums[i])) dictionary[nums[i]] = i;
                else dictionary.Add(nums[i], i);
            }

            IList<IList<int>> res = new List<IList<int>>();

            for (int i = 0; i < len - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < len - 1; j++)
                {
                    if (nums[i] + nums[j] > 0 || nums[j] > -nums[i] - nums[j]) break;
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    var need = nums[i] + nums[j];
                    if (dictionary.ContainsKey(-need))
                    {
                        if (dictionary[-need] > j)
                            res.Add(new List<int>() {nums[i], nums[j], -need});
                    }
                }
            }

            return res;
        }

        /**
         * Runtime: 352 ms, faster than 37.29% of C# online submissions for 3Sum.
         * Memory Usage: 35.2 MB, less than 10.00% of C# online submissions for 3Sum.
         *
         * 稍微快了点  continue ~
         * 
         */
        public IList<IList<int>> Try2(int[] nums)
        {
            Array.Sort(nums);

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dictionary.ContainsKey(num)) dictionary[num]++;
                else dictionary.Add(num, 1);
            }

            var len = nums.Length;

            IList<IList<int>> res = new List<IList<int>>();

            for (int i = 0; i < len - 2 && nums[i] <= 0; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < len - 1; j++)
                {
                    // 考虑排序的特点 x_0 + x_1 > 0 那么 x_0 + x_2 肯定 > 0
                    if (nums[i] + nums[j] > 0) break;
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    var need = nums[i] + nums[j];
                    // c>b>a
                    if (-need < nums[j]) break;
                    if (dictionary.ContainsKey(-need))
                    {
                        // 此处使用数量验证
                        if (dictionary[-need] > (nums[i] == -need ? 1 : 0) + (nums[j] == -need ? 1 : 0))
                            res.Add(new List<int>() {nums[i], nums[j], -need});
                    }
                }
            }

            return res;
        }

        /**
         * 
         * Runtime: 416 ms, faster than 25.55% of C# online submissions for 3Sum.
         * Memory Usage: 35.3 MB, less than 5.00% of C# online submissions for 3Sum.
         *
         * 至少通过了...
         * 
         */
        public IList<IList<int>> SimpleSolution(int[] nums)
        {
            // 利用排序特性 下标验证 跳过重复 -> 避免重复添加。。

            // 排序数组
            Array.Sort(nums);

            var len = nums.Length;

            // 将数组值放入map中 对应 值 -下标列表
            Dictionary<int, IList<int>> dictionary = new Dictionary<int, IList<int>>();

            for (int i = 0; i < len; i++)
            {
                if (dictionary.ContainsKey(nums[i]))
                    dictionary[nums[i]].Add(i);
                else
                    dictionary.Add(nums[i], new List<int>() {i});
            }

            IList<IList<int>> res = new List<IList<int>>();

            // 遍历集合 令 a + b + c = 0  且 c>b>a
            // 故 a ∈ {x_0...x_n-2} b ∈ {x_1...x_n-1} c ∈ {x_2...x_n}
            for (int i = 0; i < len - 2; i++)
            {
                // 避免重复 且不排除第一位
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < len - 1; j++)
                {
                    // 同i跳过
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    var num = nums[i] + nums[j];
                    if (dictionary.ContainsKey(-num))
                    {
                        foreach (var item in dictionary[-num])
                        {
                            // 是否符合 c>b(b>a已知.)
                            if (item > j)
                            {
                                res.Add(new List<int>() {nums[i], nums[j], nums[item]});
                                break;
                            }
                        }
                    }
                }
            }

            return res;
        }
    }
}