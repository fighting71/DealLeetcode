using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/6/2020 3:52:02 PM
    /// @source : https://leetcode.com/problems/largest-rectangle-in-histogram/
    /// @des : 
    /// </summary>
    [Obsolete("slow")]
    public class LargestRectangleInHistogram
    {

        /**
         * https://leetcode.com/problems/largest-rectangle-in-histogram/discuss/28902/5ms-O(n)-Java-solution-explained-(beats-96)
         */
        public static int OtherSolution(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }
            int[] lessFromLeft = new int[height.Length]; // idx of the first bar the left that is lower than current
            int[] lessFromRight = new int[height.Length]; // idx of the first bar the right that is lower than current
            lessFromRight[height.Length - 1] = height.Length;
            lessFromLeft[0] = -1;

            for (int i = 1; i < height.Length; i++)
            {
                int p = i - 1;

                while (p >= 0 && height[p] >= height[i])
                {
                    p = lessFromLeft[p];
                }
                lessFromLeft[i] = p;
            }

            for (int i = height.Length - 2; i >= 0; i--)
            {
                int p = i + 1;

                while (p < height.Length && height[p] >= height[i])
                {
                    p = lessFromRight[p];
                }
                lessFromRight[i] = p;
            }

            int maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                maxArea = Math.Max(maxArea, height[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
            }

            return maxArea;
        }

        public int Solution(int[] heights)
        {

            int res = 0, n = heights.Length, h;

            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                dic[heights[i]]++;
            }



            return res;

        }


        /**
         * Runtime: 1532 ms, faster than 18.81% of C# online submissions for Largest Rectangle in Histogram.
         * Memory Usage: 26.4 MB, less than 100.00% of C# online submissions for Largest Rectangle in Histogram.
         * 
         * wc... 测试案例真仁慈
         * 
         * time limit
         * 
         */
        public int Simple(int[] heights)
        {

            int res = 0, n = heights.Length, h;

            for (int i = 0; i < n; i++)
            {
                h = heights[i];
                res = Math.Max(res, h);
                for (int j = i + 1; j < n; j++)
                {
                    h = Math.Min(heights[j], h);
                    res = Math.Max(res, h * (j - i + 1));
                }
            }

            return res;

        }

    }
}
