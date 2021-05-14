using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/14/2021 6:15:05 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3742/
    /// @des : 
    ///     将tree作为链表展开
    /// </summary>
    [Serie(FlagConst.Tree)]
    public class Flatten_Binary_Tree_to_Linked_List
    {
        // Your runtime beats 95.20 %
        // 88ms
        public void Flatten(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            TreeNode pre = null;

            while (stack.Count > 0)
            {

                TreeNode node = stack.Pop();

                if (pre != null)
                {
                    pre.right = node;
                    pre.left = null;
                }

                while (node != null)
                {
                    if (node.right != null) stack.Push(node.right);
                    node.right = node.left;
                    node.left = null;
                    pre = node;
                    node = node.right;
                }

            }

        }
    }
}
