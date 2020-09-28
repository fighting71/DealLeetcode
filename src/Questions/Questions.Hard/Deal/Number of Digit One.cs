using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/28/2020 3:08:52 PM
    /// @source : https://leetcode.com/problems/number-of-digit-one/
    /// @des : 
    /// </summary>
    [Obsolete("题意不明确")]
    public class Number_of_Digit_One
    {

        int[] arr = new[] { 0, 0, 1, 3, 6, 10, 15, 21, 28, 36 };

        public int Solution(int n)
        {
            return n / 10 * 45 + arr[n % 10];
        }
        public int Simple(int n)
        {
            int sum = 0;

            for (int i = 1; i < n; i++)
            {
                sum += i % 10;
            }

            return sum;
        }

    }
}
