using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/23/2020 10:20:46 AM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3504/
    /// @des : 
    /// </summary>
    public class Minimum_Depth_of_Binary_Tree
    {

        //52 / 52 test cases passed.
        //Status: Accepted
        //Runtime: 264 ms
        //Memory Usage: 50.9 MB
        // 100%?
        public int Optimize(TreeNode root)
        {

            if (root == null) return 0;

            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 1));

            while (queue.Count > 0)
            {
                (TreeNode node, int deep) = queue.Dequeue();

                bool hasLeft = node.left != null, hasRight = node.right != null;
                if (!hasLeft && !hasRight) return deep;
                if (hasLeft)
                    queue.Enqueue((node.left, deep + 1));
                if (hasRight)
                    queue.Enqueue((node.right, deep + 1));

            }
            return default;
            
            //Queue<TreeNode> queue = new Queue<TreeNode>();
            //queue.Enqueue(root);

            //while (queue.Count > 0)
            //{
            //    TreeNode node = queue.Dequeue();

            //    bool hasLeft = node.left != null, hasRight = node.right != null;
            //    if (!hasLeft && !hasRight) return 0;
            //    if (hasLeft)
            //        queue.Enqueue(node.left);
            //    if (hasRight)
            //        queue.Enqueue(node.right);

            //}

        }

        public int Simple(TreeNode root)
        {
            return Help(root, 1);
        }

        private int Help(TreeNode node, int deep)
        {
            if (node == null) return deep - 1;
            return Math.Min(Help(node.left, deep + 1),
                Help(node.right, deep + 1));
        }

    }
}
