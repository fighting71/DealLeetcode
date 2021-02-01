using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/1/2021 2:58:33 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3623/
    /// @des : 
    ///     给定一个数字用数组表示，例如  132=[1,3,2]
    ///     获取此数字的下一个更大的数，若不存在则返回排序后的结果, 例如  123 -> 132 -> 213 -> 231 -> 312 -> 321 -> 123
    /// </summary>
    public class Next_Permutation
    {

        // 1 <= nums.length <= 100
        // 0 <= nums[i] <= 100

        public void Optimize(int[] nums)
        {
            /*
             * think
             * 
             * 不可替换=》直接翻转
             * 可替换=》
             *  1.找最小替换值，(由于后面的部分已经具有递增性)可进行简化【例如2分查找】
             *  2.排序数组(由于后面的部分已经具有递增性)可进行简化【例如翻转】
             * 
             */

            /*
             * think(slow)
             * 可能的结果有两种：
             * 1. 存在可替换
             *      a.找出大于当前值的最小值
             *      b.替换后将后面的部分进行排序
             * 2. 直接排序/翻转数组
             * 
             * 故-> 可初始创建一个集合(有序)
             * 每次遍历时：
             *      获取集合的插入索引
             *      若可替换（索引值非最后一个），则通过索引直接找到下一个比它大的并进行替换，最后用集合剩下的项替换数组
             *          结束循环.
             * 
             * diff: try 在最终进行替换 排序，而此方法在每次遍历时进行排序.
             * 
             */


            throw new NotImplementedException();
        }


        public void Explain(int[] nums)
        {
            var len = nums.Length;
            if (len == 1) return;

            var max = nums[len - 1];

            for (int i = len - 2; i >= 0; i--) // 从末尾遍历数组
            {
                var curr = nums[i];
                if (max > curr) // 若后面有数字大于当前数字则表示符合替换   :  有 k,j ∈ [0,100]  若 k > j then kj > jk
                {
                    int index = i + 1;
                    for (int j = i + 2; j < len; j++) // ** 找出大于当前的最小的数，从而获取最小的下一个Permutation
                    {
                        if (nums[j] > curr && nums[j] < nums[index])
                        {
                            index = j;
                        }
                    }
                    nums[i] = nums[index];

                    // 将后面的数字进行排序 从而获取最小的下一个Permutation
                    List<int> list = new List<int>() { curr };
                    for (int j = i + 1; j < len; j++)
                    {
                        if (j == index) continue;
                        list.Add(nums[j]);
                    }

                    list.Sort();

                    for (int j = i + 1; j < len; j++)
                    {
                        nums[j] = list[j - i - 1];
                    }

                    return;
                }
                max = curr;
            }

            // 若当前数已经是最大了，则直接排序[因为已经是有序的则直接翻转即可]
            for (int i = 0; i < nums.Length / 2; i++)
            {
                var temp = nums[i];
                nums[i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = temp;
            }

        }

        // slow
        public void Try(int[] nums)
        {
            var len = nums.Length;
            if (len == 1) return;

            var max = nums[len - 1];

            for (int i = len - 2; i >= 0; i--)
            {
                var curr = nums[i];
                if (max > curr)
                {
                    int index = i + 1;
                    for (int j = i + 2; j < len; j++)
                    {
                        if (nums[j] > curr && nums[j] < nums[index])
                        {
                            index = j;
                        }
                    }
                    nums[i] = nums[index];

                    List<int> list = new List<int>() { curr };
                    for (int j = i + 1; j < len; j++)
                    {
                        if (j == index) continue;
                        list.Add(nums[j]);
                    }

                    list.Sort();

                    for (int j = i + 1; j < len; j++)
                    {
                        nums[j] = list[j - i - 1];
                    }

                    return;
                }
                max = curr;
            }

            for (int i = 0; i < nums.Length / 2; i++)
            {
                var temp = nums[i];
                nums[i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = temp;
            }

        }

        // bug
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1) return;

            var last = nums.Length - 1;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                var num = nums[i];
                if (num == nums[last]) last = i;
                else if (num < nums[last])
                {
                    var temp = num;
                    nums[i] = nums[last];
                    nums[last] = temp;
                    return;
                }
            }

            for (int i = 0; i < nums.Length / 2; i++)
            {
                var temp = nums[i];
                nums[i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = temp;
            }

        }

    }
}
