using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/8/2020 3:24:12 PM
    /// @source : https://leetcode.com/problems/sliding-window-maximum/
    /// @des : 
    /// </summary>
    public class Sliding_Window_Maximum
    {

        /// <summary>
        /// Runtime: 260 ms, faster than 95.09% of C# online submissions for Sliding Window Maximum.
        /// Memory Usage: 35.5 MB, less than 50.00% of C# online submissions for Sliding Window Maximum.
        /// 
        /// emm??? 还以为要继续大战三百回合，比期望中的快
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] Solution(int[] nums, int k)
        {
            int[] res = new int[nums.Length - k + 1];

            int max = nums[0];

            for (int i = 1; i < k - 1; i++)
                max = Math.Max(max, nums[i]);

            for (int i = k - 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                res[i - k + 1] = max;
                if (nums[i - k + 1] == max)
                {
                    max = int.MinValue;
                    for (int j = 0; j < k - 1; j++)
                        max = Math.Max(max, nums[i - j]);
                }
            }

            return res;

        }

        /// <summary>
        /// Runtime: 420 ms, faster than 10.12% of C# online submissions for Sliding Window Maximum.
        /// Memory Usage: 35.6 MB, less than 50.00% of C# online submissions for Sliding Window Maximum.
        /// 
        /// 仁慈的测试案例.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] Simple(int[] nums, int k)
        {
            int[] res = new int[nums.Length - k + 1];

            List<int> list = new List<int>(k);

            for (int i = 0; i < k - 1; i++)
            {
                if (list.Count == 0) list.Add(nums[i]);
                else if (list[list.Count - 1] <= nums[i]) list.Add(nums[i]);
                else
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] >= nums[i])
                        {
                            list.Insert(j, nums[i]);
                            break;
                        }
                    }
                }
            }

            for (int i = k - 1; i < nums.Length; i++)
            {
                if (list.Count == 0) list.Add(nums[i]);
                else if (list[0] >= nums[i]) list.Insert(0, nums[i]);
                else if (list[list.Count - 1] <= nums[i]) list.Add(nums[i]);
                else
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] >= nums[i])
                        {
                            list.Insert(j, nums[i]);
                            break;
                        }
                    }
                }
                res[i - k + 1] = list[k - 1];
                list.Remove(nums[i - k + 1]);
            }

            return res;

        }

    }
}
