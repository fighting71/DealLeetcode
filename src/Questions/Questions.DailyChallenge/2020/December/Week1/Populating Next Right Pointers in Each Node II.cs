using System;
using System.Collections.Generic;
using System.Text;
using Node = Command.CommonStruct.TreeNode;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/7/2020 2:53:02 PM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3556/
    /// @des : 
    /// </summary>
    public class Populating_Next_Right_Pointers_in_Each_Node_II
    {
        // The number of nodes in the given tree is less than 6000.
        // -100 <= node.val <= 100
        // Your memory usage beats 41.94 %
        public Node Connect(Node root)
        {
            if (root == null) return root;
            Queue<(int, Node)> queue = new Queue<(int, Node)>();
            queue.Enqueue((0, root));

            int deep, prevDeep = -1;
            Node prev = null, node;

            while (queue.Count > 0)
            {
                (deep, node) = queue.Dequeue();
                if (prevDeep == deep) node.next = prev;
                prev = node;
                prevDeep = deep;
                if (node.right != null) queue.Enqueue((deep + 1, node.right));
                if (node.left != null) queue.Enqueue((deep + 1, node.left));
            }
            return root;
        }
    }
}
