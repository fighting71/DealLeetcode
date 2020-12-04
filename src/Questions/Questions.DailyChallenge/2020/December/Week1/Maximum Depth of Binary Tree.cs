using Command.CommonStruct;
using System;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/2/2020 2:44:19 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3551/
    /// @des : 
    /// </summary>
    public class Maximum_Depth_of_Binary_Tree
    {
        // The number of nodes in the tree is in the range [0, 104].
        // -100 <= Node.val <= 100
        // 按照国际惯例，第一题往往是送分题.
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }
}
