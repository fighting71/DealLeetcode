using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/30/2020 3:22:39 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3577/
    /// @des : 
    ///     给定一棵二叉树，确定它是否是高度平衡的。
    ///     对于这个问题，一个高度平衡二叉树定义为:
    ///     一种二叉树，其中每个节点的左子树和右子树的高度差不超过1。
    /// </summary>
    public class Balanced_Binary_Tree
    {
        // Your runtime beats 94.02 % 
        public bool IsBalanced(TreeNode root)
        {
            return Helper(root).Item1;
        }

        private (bool,int) Helper(TreeNode node)
        {
            if (node == null) return (true, 0);

            //if(node.left == null && node.right == null)
            //{
            //    return (true, 1);
            //}

            //if(node.left == null)
            //{
            //    return Helper(node.right);
            //}

            //if (node.right == null)
            //{
            //    return Helper(node.left);
            //}

            (bool, int) leftRes = Helper(node.left);

            if (!leftRes.Item1) return (false, 0);

            (bool, int) rightRes = Helper(node.right);

            if (!rightRes.Item1) return (false, 0);

            if(Math.Abs(leftRes.Item2 - rightRes.Item2) > 1) return (false, 0);

            return (true, 1 + Math.Max(leftRes.Item2, rightRes.Item2));
        }

    }
}
