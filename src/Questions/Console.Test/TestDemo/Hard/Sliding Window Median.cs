using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/26/2021 4:12:56 PM
    /// @source : https://leetcode.com/problems/sliding-window-median/
    /// @des : 滑动窗口，获取每次滑动时窗口的中位数
    /// </summary>
    [Optimize]
    public class Sliding_Window_Median
    {

        // bug
        public double[] Try(int[] nums, int k)
        {
            return default;
            if (nums.Length == 0) return new double[0];

            if (k == 1) return nums.Select(u => (double)u).ToArray();

            List<double> list = new List<double>(k);

            for (int i = 0; i < k; i++)
            {
                AddOne(nums[i]);
            }

            double[] res = new double[nums.Length - k + 1];

            bool isOdd = k % 2 == 1;
            var mid = k / 2;
            res[0] = isOdd ? list[mid] : (list[mid] + list[mid - 1]) / 2;

            for (int i = k; i < nums.Length; i++)
            {
                list.Remove(nums[i - k]);
                AddOne(nums[i]);
                res[i - k + 1] = isOdd ? list[mid] : (list[mid] + list[mid - 1]) / 2;

            }

            void AddOne(int num)
            {
                if (list.Count == 0 || num >= list[^1]) list.Add(num);
                else
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (num <= list[j])
                        {
                            list.Insert(j, num);
                            break;
                        }
                    }
                }
            }

            return res;
        }


        // Runtime: 880 ms, faster than 7.32%
        public double[] Simple(int[] nums, int k)
        {
            if (nums.Length == 0) return new double[0];

            if (k == 1) return nums.Select(u => (double)u).ToArray();

            List<double> list = new List<double>(k);

            for (int i = 0; i < k; i++)
            {
                list.Add(nums[i]);
            }

            list.Sort();

            double[] res = new double[nums.Length - k + 1];

            bool isOdd = k % 2 == 1;
            var mid = k / 2;
            res[0] = isOdd ? list[mid] : (list[mid] + list[mid - 1]) / 2;

            for (int i = k; i < nums.Length; i++)
            {
                list.Remove(nums[i - k]);

                var num = nums[i];

                if (num >= list[k - 2])
                {
                    list.Add(num);
                }
                else
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (num <= list[j])
                        {
                            list.Insert(j, num);
                            break;
                        }
                    }
                }
                res[i - k + 1] = isOdd ? list[mid] : (list[mid] + list[mid - 1]) / 2;

            }
            return res;

        }

    }
}
