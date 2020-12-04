using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/4/2020 9:47:00 AM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3553/
    /// @des : 
    /// </summary>
    public class Increasing_Order_Search_Tree
    {
        //The number of nodes in the given tree will be in the range [1, 100].
        //0 <= Node.val <= 1000

        // 92 ms
        // Your runtime beats 75.35 %
        // 学到了
        public TreeNode Simple(TreeNode root)
        {
            return Help(root)?[0];
        }
        // [0] => root
        // [1] => tail
        private TreeNode[] Help(TreeNode node)
        {
            if (node == null) return null;

            TreeNode curr = new TreeNode(node.val), root = curr, tail = curr;

            TreeNode[] leftNodes = Help(node.left);

            if (leftNodes != null)
            {
                leftNodes[1].right = curr;
                root = leftNodes[0];
            }

            TreeNode[] rightNodes = Help(node.right);

            if (rightNodes != null)
            {
                curr.right = rightNodes[0];
                tail = rightNodes[1];
            }
            return new[] { root, tail };
        }
    }
}
