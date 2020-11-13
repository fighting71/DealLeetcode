using System;
using System.Collections.Generic;
using System.Text;
using Node = Command.CommonStruct.TreeNode;

namespace Questions.DailyChallenge._2020.November.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/13/2020 5:59:33 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Populating_Next_Right_Pointers_in_Each_Node
    {

        // The number of nodes in the given tree is less than 4096.
        //-1000 <= node.val <= 1000

        // Runtime: 104 ms
        // Memory Usage: 30.1 MB
        // Your runtime beats 63.85 % of csharp submissions
        public Node Simple(Node root)
        {

            if (root == null) return root;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            int count = 0, rightCount = 1;
            Node prev = null;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (++count == rightCount)
                {
                    rightCount *= 2;
                }
                else
                {
                    node.next = prev;
                }
                prev = node;
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    queue.Enqueue(node.left);

                }
            }
            return root;
        }

    }
}
