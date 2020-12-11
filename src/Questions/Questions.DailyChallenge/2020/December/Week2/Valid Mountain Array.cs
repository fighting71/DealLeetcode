using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/11/2020 11:18:23 AM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3561/
    /// @des : 
    /// </summary>
    public class Valid_Mountain_Array
    {

        // 1 <= arr.length <= 10^4
        // 0 <= arr[i] <= 10^4

        // Your runtime beats 18.16 % of 
        public bool Simple(int[] arr)
        {
            if (arr.Length < 3) return false;
            if (arr[0] > arr[1]) return false;
            bool isAdd = true;

            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1]) return false;
                if (arr[i] > arr[i - 1])
                {
                    if (!isAdd) return false;
                }
                else if (isAdd) isAdd = false;
            }
            return true;
        }

        // oh shit...
        public bool OtherSolution(int[] arr)
        {
            if (arr.Length < 3) return false;
            int i = 0, j = arr.Length - 1;
            while (i + 1 < arr.Length && arr[i] < arr[i + 1]) i++;
            while (j - 1 >= 0 && arr[j] < arr[j - 1]) j--;
            return i > 0 && j < arr.Length - 1 && i == j;
        }


    }
}
