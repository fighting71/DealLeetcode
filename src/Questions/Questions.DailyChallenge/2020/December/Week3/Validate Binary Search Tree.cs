using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/16/2020 5:23:59 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3568/
    /// @des : 
    ///     验证树是否为BST
    ///     BST:
    ///         节点的左子树只包含键小于节点的键的节点。
    ///         节点的右子树只包含键大于节点键的节点。
    ///         左右子树都必须是二叉搜索树。
    ///
    /// </summary>
    public class Validate_Binary_Search_Tree
    {

        // Constraints:

        //The number of nodes in the tree is in the range[1, 104].
        //-2^31 <= Node.val <= 2^31 - 1

        // Your runtime beats 91.24 %
        public bool IsValidBST(TreeNode root)
        {
            return Help(root, default, default);
        }

        private bool Help(TreeNode node, int? min, int? max)
        {
            if (node == null) return true;
            // *** 不包含等于
            if (min.HasValue && node.val <= min.Value) return false;
            if (max.HasValue && node.val >= max.Value) return false;

            return Help(node.left, min, max.HasValue ? Math.Min(max.Value, node.val) : node.val)
                && Help(node.right, min.HasValue ? Math.Max(min.Value, node.val) : node.val, max);

        }

        private bool ClearHelp(TreeNode node, int? min, int? max)
        {
            return node == null || (
                    (!min.HasValue || node.val > min.Value) &&
                    (!max.HasValue || node.val < max.Value) &&
                    Help(node.left, min, max.HasValue ? Math.Min(max.Value, node.val) : node.val) &&
                    Help(node.right, min.HasValue ? Math.Max(min.Value, node.val) : node.val, max)
                );

        }

    }
}
