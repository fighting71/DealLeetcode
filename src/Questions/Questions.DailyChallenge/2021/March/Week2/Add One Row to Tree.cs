using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/10/2021 9:51:43 AM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3666/
    /// @des : 给定一个二叉树根节点、值v、深度d
    ///         将二叉树中深度为d的替换为值为v的新节点
    /// </summary>
    public class Add_One_Row_to_Tree
    {
        // The given d is in range [1, maximum depth of the given tree + 1].
        // The given binary tree has at least one tree node.

        // Your runtime beats 79.41 % of csharp submissions
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            return Help(root, 1);

            TreeNode Help(TreeNode node, int depth, bool isLeft = true)
            {
                bool isNull = node == null;
                if (depth == d)
                {
                    if (isNull) return new TreeNode(v);
                    if (isLeft) return new TreeNode(v, node, null);
                    return new TreeNode(v, null, node);
                }

                if (isNull) return null;

                node.left = Help(node.left, depth + 1);
                node.right = Help(node.right, depth + 1, false);
                return node;
            }

        }

    }
}
