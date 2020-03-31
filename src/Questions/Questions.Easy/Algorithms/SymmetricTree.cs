using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 10:17:54 AM
    /// @source : https://leetcode.com/problems/symmetric-tree/
    /// @des : 
    /// </summary>
    public class SymmetricTree
    {

        public bool Solution(TreeNode root)
        {
            if (root == null) return true;
            return IsSame(root.left, root.right);
        }

        /// <summary>
        /// Runtime: 92 ms, faster than 81.37% of C# online submissions for Symmetric Tree.
        /// Memory Usage: 25.3 MB, less than 27.27% of C# online submissions for Symmetric Tree.
        /// 
        /// Runtime: 88 ms, faster than 94.19% of C# online submissions for Symmetric Tree.
        /// Memory Usage: 25 MB, less than 27.27% of C# online submissions for Symmetric Tree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        private bool IsSame(TreeNode node,TreeNode node2)
        {
            if (node == null && node2 == null) return true;
            if (node2 == null && node != null) return false;
            if (node == null && node2 != null) return false;
            if (node.val != node2.val) return false;
            return IsSame(node.right, node2.left) && IsSame(node.left, node2.right);
        }

        /// <summary>
        /// Runtime: 92 ms, faster than 81.37% of C# online submissions for Symmetric Tree.
        /// Memory Usage: 25.1 MB, less than 27.27% of C# online submissions for Symmetric Tree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        private bool IsSame2(TreeNode node, TreeNode node2)
        {
            bool flag = node == null, flag2 = node2 == null;
            if (flag && flag2) return true;
            if (flag != flag2 || node.val != node2.val) return false;
            return IsSame2(node.right, node2.left) && IsSame(node.left, node2.right);
        }

    }
}
