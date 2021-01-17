using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/17/2021 10:10:11 AM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3606/
    /// @des : 
    ///     在一个未排序的数组中找到第k大的元素。
    /// </summary>
    public class Kth_Largest_Element_in_an_Array
    {

        // optimize:
        // 使用某个结构始终保留k个数字，然后遍历数组，使得此k个数字在数组中最大...

        // slowly
        public int Try(int[] nums, int k)
        {
            int len = nums.Length;

            int maxIndex = -1;

            bool[] visited = new bool[len];

            while (k-- > 0)
            {
                maxIndex = -1;
                for (int i = 0; i < len; i++)
                {
                    if (visited[i]) continue;
                    if (maxIndex == -1 || nums[i] > nums[maxIndex]) maxIndex = i;
                }
                visited[maxIndex] = true;
            }
            return nums[maxIndex];
        }

        // Your runtime beats 35.68 %
        public int Simple(int[] nums, int k)
        {
            Array.Sort(nums);

            return nums[^k];
        }

    }
}
