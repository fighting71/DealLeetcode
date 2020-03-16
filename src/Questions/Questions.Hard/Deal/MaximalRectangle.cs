using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/9/2020 3:48:56 PM
    /// @source : https://leetcode.com/problems/maximal-rectangle/
    /// @des : 
    /// </summary>
    public class MaximalRectangle
    {

        /// <summary>
        /// 
        /// Runtime: 116 ms, faster than 98.26% of C# online submissions for Maximal Rectangle.
        /// Memory Usage: 28.9 MB, less than 100.00% of C# online submissions for Maximal Rectangle.
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int Solution(char[][] matrix)
        {

            if (matrix.Length == 0) return 0;

            int m = matrix.Length, n = matrix[0].Length;

            int[][] heights = new int[m][];

            for (int i = 0; i < m; i++)
            {
                heights[i] = new int[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '0') continue;
                    heights[i][j] = 1 + ((i == 0 || heights[i - 1][j] == '0') ? 0 : heights[i - 1][j]);
                }
            }

            int[] lessFromLeft = new int[n]; // idx of the first bar the left that is lower than current
            int[] lessFromRight = new int[n]; // idx of the first bar the right that is lower than current
            lessFromRight[n - 1] = n;
            lessFromLeft[0] = -1;
            int res = 0;

            for (int k = 0; k < m; k++)
            {
                res = OtherHelper(n, res, heights[k], lessFromLeft, lessFromRight);
            }

            return res;
        }

        /// <summary>
        /// @source : https://leetcode.com/problems/largest-rectangle-in-histogram/discuss/28902/5ms-O(n)-Java-solution-explained-(beats-96)
        /// 
        /// amazing~
        /// 
        /// <see cref="LargestRectangleInHistogram.OtherSolution(int[])"/>
        /// </summary>
        /// <returns></returns>
        private int OtherHelper(int n,int res,int[] height, int[] lessFromLeft, int[] lessFromRight)
        {
            for (int i = 1; i < n; i++)// foreach i=>n
            {
                int p = i - 1;// var index = [prev ele]

                while (p >= 0 && height[p] >= height[i]) // index 正常，且高度(p)>=高度(i) ; 由于存在f(p)>f(i)的情况 要循环包含小于f(p)但大于f(i)的元素
                {
                    p = lessFromLeft[p];// 左下标 切换到 [prev ele]的左下标 ： 大于f(p)的所有元素>=f(p)>=f(i) 故 left(p) >= left(i) 
                }
                lessFromLeft[i] = p;
            }

            for (int i = n - 2; i >= 0; i--)
            {
                int p = i + 1;

                while (p < height.Length && height[p] >= height[i])
                {
                    p = lessFromRight[p];
                }
                lessFromRight[i] = p;
            }

            for (int i = 0; i < height.Length; i++)
            {
                res = Math.Max(res, height[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
            }

            return res;
        }

    }
}
