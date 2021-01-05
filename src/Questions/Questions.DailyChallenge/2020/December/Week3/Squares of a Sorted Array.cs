using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/15/2020 6:51:14 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3567/
    /// @des : 
    /// </summary>
    public class Squares_of_a_Sorted_Array
    {

        // 1 <= nums.length <= 10^4
        //-10^4 <= nums[i] <= 10^4
        //nums is sorted in non-decreasing order.

        // Your runtime beats 88.72 %
        public int[] Solution(int[] nums)
        {
            int len = nums.Length;
            int[] res = new int[len];

            Stack<int> stack = new Stack<int>(); // nums已经排过序，只需在此处缓存<0的项，并借助先入后出特点保持顺序.

            int index = 0;
            foreach (var item in nums)
            {
                if (item < 0) stack.Push(-item);
                else
                {
                    while (stack.Count > 0 && stack.Peek() <= item)
                    {
                        int prev = stack.Pop();
                        res[index++] = prev * prev;
                    }
                    res[index++] = item * item;
                }
            }

            while (stack.Count > 0) // 避免stack还有剩余
            {
                int prev = stack.Pop();
                res[index++] = prev * prev;
            }

            return res;
        }

        public int[] Simple(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                ref int num = ref nums[i];
                num = num * num;
            }
            Array.Sort(nums);
            return nums;
        }
    }
}
