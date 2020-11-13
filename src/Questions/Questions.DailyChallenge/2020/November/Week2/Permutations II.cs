using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/13/2020 12:25:04 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3528/
    /// @des : 
    /// </summary>
    public class Permutations_II
    {

        // 1 <= nums.length <= 8
        // -10 <= nums[i] <= 10

        // Runtime: 244 ms
        // Memory Usage: 33.4 MB
        // Your runtime beats 84.66 % of csharp submissions.
        public IList<IList<int>> Simple(int[] nums)
        {
            int[] arr = new int[20];// 根据note定义范围

            foreach (var num in nums)
                arr[num + 10]++;
            IList<IList<int>> res = new List<IList<int>>();

            // Help(nums.Length, -1, arr, new int[nums.Length], res);
            Help2(nums.Length, -1, arr, new int[nums.Length], res);
            return res;

        }

        private void Help(int n, int index, int[] arr, int[] bulider, IList<IList<int>> res)
        {
            if (n == index + 1) // 遍历完成
            {// *** builder因为长度固定可直接复用.
                res.Add(new List<int>(bulider));// copy to res
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                var count = arr[i];
                if (count > 0)
                {
                    if (index != -1 && bulider[index] == i - 10) continue; // 已经处理过了，直接skip  避免处理 a... 后处理 a...
                    for (int j = 0; j < count; j++)
                    {
                        bulider[index + j + 1] = i - 10;
                        arr[i]--;
                        Help(n, index + j + 1, arr, bulider, res);
                    }
                    arr[i] = count;
                }
            }
        }

        private void Help2(int n,int index, int[] arr, int[] bulider, IList<IList<int>> res)
        {
            if (n == index + 1) // 比较bulider.Length 不如比较n...
            {
                res.Add(new List<int>(bulider));
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                var count = arr[i];
                if (count > 0)
                {
                    bulider[index + 1] = i - 10;
                    arr[i]--;
                    Help(n, index + 1, arr, bulider, res);
                    arr[i]++;
                }
            }
        }

        // 差不多.
        private void Help(int index, int[] arr, int[] bulider, IList<IList<int>> res)
        {
            if (bulider.Length == index + 1) // 比较bulider.Length 不如比较n...
            {
                res.Add(new List<int>(bulider));
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                var count = arr[i];
                if (count > 0) // 因为有arr顺序保证，故无须验证重复遍历...
                {
                    bulider[index + 1] = i - 10;
                    arr[i]--;
                    Help(index + 1, arr, bulider, res);
                    arr[i]++;
                }
            }
        }

    }
}
