using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/30/2021 3:34:42 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/607/week-5-june-29th-june-30th/3797/
    /// @des : 
    ///     给定一颗二叉树，和树中的两个节点p,q
    ///     target: 
    ///         返回两个节点最低共同祖先(LCA)（最近的共同父节点，若p为q的父节点，则共同祖先为p）
    /// </summary>
    public class Lowest_Common_Ancestor_of_a_Binary_Tree
    {

        // Your runtime beats 88.01 % of csharp submission
        // 
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode res = root;

            Help(root);

            return res;

            bool Help(TreeNode node)
            {
                if (node == null) return false;

                bool l = Help(node.left);
                bool r = Help(node.right);

                bool curr = node == p || node == q;

                if (l && r)
                {
                    res = node;
                    return false;
                }
                else if(curr && (l || r))
                {
                    res = node;
                    return false;
                }
                return curr || l || r;
            }

        }

    }
}
