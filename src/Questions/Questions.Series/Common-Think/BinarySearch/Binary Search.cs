using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Common_Think.BinarySearch
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 11:40:30 AM
    /// @source : https://leetcode.com/problems/binary-search/
    /// @des : 
    /// </summary>
    public class Binary_Search
    {
        //You may assume that all elements in nums are unique.
        //n will be in the range[1, 10000].
        //The value of each element in nums will be in the range[-9999, 9999].


        // Runtime: 116 ms, faster than 99.83% of C# online submissions for Binary Search.
        public int Search(int[] arr, int target)
        {
            if (arr.Length == 0) return -1;

            int len = arr.Length, left = 0, right = len - 1;

            while (left <= right) 
            {
                var mid = left + (right - left) / 2;
                var num = arr[mid];
                if (num == target) return mid;
                if (num > target) right = mid - 1;
                else left = mid + 1;
            }

            return -1;
        }
    }
}
