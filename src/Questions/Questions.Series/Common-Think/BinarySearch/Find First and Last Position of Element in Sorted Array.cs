using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Common_Think.BinarySearch
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 11:44:05 AM
    /// @source : https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
    /// @des : 
    /// </summary>
    public class Find_First_and_Last_Position_of_Element_in_Sorted_Array
    {
        //0 <= nums.length <= 105
        //-109 <= nums[i] <= 109
        //nums is a non-decreasing array.
        //-109 <= target <= 109

        // Runtime: 248 ms, faster than 45.75% of C# online submissions for Find First and Last Position of Element in Sorted Array.
        public int[] SearchRange(int[] arr, int target)
        {
            if (arr.Length == 0) return new[] { -1, -1 };

            int len = arr.Length, left = 0, right = len;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var num = arr[mid];
                if (num == target) right = mid;
                else if (num > target) right = mid;
                else left = mid + 1;
            }

            int leftRes = right != len && arr[right] == target ? right : -1;

            if (leftRes == -1) return new[] { -1, -1 };

            left = right;
            right = len;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var num = arr[mid];
                if (num == target) left = mid + 1;
                else if (num > target) right = mid;
                else left = mid + 1;
            }

            return new []{ leftRes, left - 1 };


        }

        // 240ms ≈ 90%
        public int[] SearchRange2(int[] arr, int target)
        {
            if (arr.Length == 0) return new[] { -1, -1 };

            int len = arr.Length, left = 0, right = len, rightStart = -1;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var num = arr[mid];
                if (num == target)
                {
                    if(rightStart == -1)
                        rightStart = right;
                    right = mid;
                }
                else if (num > target) right = mid;
                else left = mid + 1;
            }

            if (right == len || arr[right] != target) return new[] { -1, -1 };

            int leftRes = left = right;
            right = rightStart;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var num = arr[mid];
                if (num == target) left = mid + 1;
                else if (num > target) right = mid;
                else left = mid + 1;
            }

            return new[] { leftRes, left - 1 };


        }

        // 244ms
        public int[] Clear(int[] arr, int target)
        {
            if (arr.Length == 0) return new[] { -1, -1 };

            int len = arr.Length, left = 0, right = len,left2 = 0,right2 = len,mid,num;

            bool hasLeft = false, hasRight = false;

            while (true)
            {
                if (!hasLeft)
                {
                    if (left == right)
                    {
                        if (hasRight) return new[] { right, left2 - 1 };

                        if (right != len && arr[right] == target)
                        {
                            hasLeft = true;
                        }
                        else return new[] { -1, -1 };
                    }
                    else
                    {
                        mid = left + (right - left) / 2;
                        num = arr[mid];
                        if (num == target) right = mid;
                        else if (num > target) right = mid;
                        else left = mid + 1;
                    }
                }

                if (!hasRight)
                {
                    if(left2 == right2)
                    {
                        if (hasLeft) return new[] { right, left2 - 1 };

                        if(left2 == 0 || arr[left2 - 1] != target) return new[] { -1, -1 };

                        hasRight = true;
                    }
                    else
                    {
                        mid = left2 + (right2 - left2) / 2;
                        num = arr[mid];
                        if (num == target) left2 = mid + 1;
                        else if (num > target) right2 = mid;
                        else left2 = mid + 1;
                    }
                }

            }

        }

    }
}
