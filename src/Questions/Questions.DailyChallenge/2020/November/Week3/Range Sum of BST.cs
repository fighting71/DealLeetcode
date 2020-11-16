using Command.Attr;
using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/16/2020 10:43:11 AM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3532/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Range_Sum_of_BST
    {

        // The number of nodes in the tree is in the range [1, 2 * 104].
        //1 <= Node.val <= 105
        //1 <= low <= high <= 105
        //All Node.val are unique.

        // Runtime: 180 ms
        // Memory Usage: 45 MB
        // Your runtime beats 64.43 % of csharp submissions.
        public int Simple(TreeNode root, int low, int high)
        {
            if (root == null) return 0;
            return (root.val <= high && root.val >= low ? root.val : 0) + Simple(root.left, low, high) + Simple(root.right, low, high);
        }

    }
}
