using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 3:28:31 PM
    /// @source : https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Sort)]
    public class TwoSumII
    {

        /// <summary>
        /// Runtime: 556 ms, faster than 5.20% of C# online submissions for Two Sum II - Input array is sorted.
        /// Memory Usage: 31.2 MB, less than 16.67% of C# online submissions for Two Sum II - Input array is sorted.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] Solution(int[] numbers, int target)
        {

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (target - numbers[i] == numbers[j]) return new[] { i + 1, j + 1 };
                    else if (target - numbers[i] < numbers[j]) break;
                }
            }

            return null;
        }

        /// <summary>
        /// Runtime: 244 ms, faster than 60.98% of C# online submissions for Two Sum II - Input array is sorted.
        /// Memory Usage: 31 MB, less than 16.67% of C# online submissions for Two Sum II - Input array is sorted.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] Solution2(int[] numbers, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (dic.TryGetValue(target - numbers[i], out var prev)) return new[] { prev + 1, i + 1 };
                dic[numbers[i]] = i;
            }

            return null;
        }

        /// <summary>
        /// Runtime: 244 ms, faster than 60.98% of C# online submissions for Two Sum II - Input array is sorted.
        /// Memory Usage: 30.9 MB, less than 16.67% of C# online submissions for Two Sum II - Input array is sorted.
        /// 
        /// Runtime: 228 ms, faster than 98.05% of C# online submissions for Two Sum II - Input array is sorted.
        /// Memory Usage: 30.9 MB, less than 16.67% of C# online submissions for Two Sum II - Input array is sorted.
        /// 
        /// 最终方案了.
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] Solution3(int[] numbers, int target)
        {

            int i = 0, j = numbers.Length - 1;
            while (numbers[i] + numbers[j] != target)
            {
                // 考虑排序的特性..
                if (numbers[i] + numbers[j] > target) j--;
                else i++;
            }
            return new[] { i + 1, j + 1 };
        }

    }
}
