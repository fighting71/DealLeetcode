using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 10:50:54 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class BalancedBinaryTree
    {

        bool flag = true;
        public bool Solution(TreeNode root)
        {
            var flag = true;
            Help(root, 0, ref flag);
            return flag;
        }

        private int Help(TreeNode node, int depth)
        {
            if (node == null) return depth;

            int l = Help(node.left, depth + 1), r = Help(node.right, depth + 1);
            if (flag)
                flag = Math.Abs(l - r) < 2;
            return Math.Max(l, r);

        }

        private int Help(TreeNode node, int depth,ref bool flag)
        {
            if (!flag) return 0;
            if (node == null) return depth;

            int l = Help(node.left, depth + 1,ref flag);
            if (!flag) return 0;

            int r = Help(node.right, depth + 1, ref flag);
            if (!flag) return 0;
            else if (!(flag = Math.Abs(l - r) < 2)) return 0;
            return Math.Max(l, r);

        }

    }
}
