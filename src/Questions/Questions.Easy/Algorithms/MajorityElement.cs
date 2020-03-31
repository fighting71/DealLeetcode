using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 4:28:32 PM
    /// @source : https://leetcode.com/problems/majority-element/
    /// @des : 
    /// </summary>
    public class MajorityElement
    {

        /// <summary>
        /// Runtime: 120 ms, faster than 59.36% of C# online submissions for Majority Element.
        /// Memory Usage: 29.6 MB, less than 50.00% of C# online submissions for Majority Element.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Solution(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                    if (dic[item] > nums.Length / 2) return item;
                }
                else dic.Add(item, 1);
            }

            return 0;
        }

        /// <summary>
        /// Runtime: 116 ms, faster than 76.42% of C# online submissions for Majority Element.
        /// Memory Usage: 29.4 MB, less than 50.00% of C# online submissions for Majority Element.
        /// 差别不大...
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Solution2(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - nums.Length / 2; i++)
            {
                if (nums[i] == nums[i + nums.Length / 2]) return nums[i];
            }

            return 0;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/majority-element/discuss/51613/O(n)-time-O(1)-space-fastest-solution
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int OtherSolution(int[] num)
        {

            int major = num[0], count = 1;
            for (int i = 1; i < num.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    major = num[i];
                }
                else if (major == num[i])
                {
                    count++;
                }
                else count--;

            }
            return major;
        }

    }
}
