using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 11:37:39 AM
    /// @source : https://leetcode.com/problems/pascals-triangle-ii/
    /// @des : 
    /// </summary>
    public class Pascal_sTriangleII
    {

        /// <summary>
        /// Runtime: 196 ms, faster than 95.86% of C# online submissions for Pascal's Triangle II.
        /// Memory Usage: 25.3 MB, less than 16.67% of C# online submissions for Pascal's Triangle II.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> Solution(int rowIndex)
        {

            int[] res = new int[rowIndex + 1];

            for (int i = 0; i <= rowIndex; i++)
            {
                res[i] = 1;
                for (int j = i - 1; j > 0; j--)
                {
                    res[j] += res[j - 1];
                }
            }

            return res;
        }

    }
}
