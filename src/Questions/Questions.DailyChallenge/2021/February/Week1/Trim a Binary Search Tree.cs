using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/3/2021 10:40:36 AM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3626/
    /// @des : 
    /// </summary>
    public class Trim_a_Binary_Search_Tree
    {

        // The number of nodes in the tree in the range [1, 10^4].
        //0 <= Node.val <= 10^4
        //The value of each node in the tree is unique.
        //root is guaranteed to be a valid binary search tree.
        //0 <= low <= high <= 10^4

        // Your runtime beats 14.41 %
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null) return null;

            if(root.val < low)
            {
                return TrimBST(root.right, low, high);
            }

            if(root.val > high)
            {
                return TrimBST(root.left, low, high);
            }

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
            return root;

        }

    }
}
