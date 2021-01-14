using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 3:43:56 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3600/
    /// @des : 
    /// </summary>
    public class Merge_Sorted_Array
    {

        //0 <= n, m <= 200
        //1 <= n + m <= 200
        //nums1.length == m + n
        //nums2.length == n
        //-109 <= nums1[i], nums2[i] <= 109

        // Your runtime beats 39.27 %
        public void Simple(int[] nums1, int m, int[] nums2, int n)
        {

            int index = nums1.Length - 1;

            m--;
            n--;
            while (index >= 0)
            {
                if (m < 0)
                {
                    nums1[index--] = nums2[n--];
                    while (index >= 0)// Your runtime beats 57.14 %
                    {
                        nums1[index--] = nums2[n--];
                    }
                    return;
                }
                if(n < 0)
                {
                    nums1[index--] = nums1[m--];
                    while (index >= 0)
                    {
                        nums1[index--] = nums1[m--];
                    }
                    return;
                }
                if(nums1[m] > nums2[n])
                {
                    nums1[index] = nums1[m--];
                }
                else
                {
                    nums1[index] = nums2[n--];
                }
                index--;
            }

        }
    }
}
