using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/29/2020 11:36:54 AM
    /// @source : https://leetcode.com/problems/count-of-range-sum/
    /// @des : 
    /// </summary>
    public class Count_of_Range_Sum
    {


        public int Optimize(int[] nums, int lower, int upper)
        {

            int len = nums.Length, res = 0;

            for (int i = 0; i < len; i++)
            {
                long num = 0;
                for (int j = i; j < len; j++)
                {
                    num += nums[j];

                    if (num >= int.MinValue && num <= int.MaxValue && num >= lower && num <= upper)
                    {
                        res++;
                    }
                }
            }

            return res;

        }

        public int Simple(int[] nums, int lower, int upper)
        {

            int len = nums.Length, res = 0;

            for (int i = 0; i < len; i++)
            {
                long num = 0;
                for (int j = i; j < len; j++)
                {
                    num += nums[j];

                    if(num >= lower && num <= upper)
                    {
                        res++;
                    }
                }
            }

            return res;
        }

    }
}
