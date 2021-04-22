using Node = Command.CommonStruct.ChildrenNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/20/2021 5:27:37 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3714/
    /// @des : 
    /// </summary>
    public class N_ary_Tree_Preorder_Traversal
    {

        // The number of nodes in the tree is in the range [0, 104].
        //0 <= Node.val <= 104
        //The height of the n-ary tree is less than or equal to 1000.

        // Your runtime beats 88.89 %
        // 按题意不走递归...
        public IList<int> Try(Node root)
        {
            IList<int> res = new List<int>();
            if (root == null) return res;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count> 0)
            {
                Node node = stack.Pop();
                res.Add(node.val);
                if(node.children != null)
                {
                    for (int i = node.children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(node.children[i]);
                    }
                }
            }
            return res;

        }

        /// <summary>
        /// 递归解决
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        // Your runtime beats 33.89 %
        public IList<int> Preorder(Node root)
        {
            IList<int> res = new List<int>();

            Help(root);

            return res;

            void Help(Node node)
            {
                if (node == null) return;
                res.Add(node.val);
                if (node.children != null)
                {
                    foreach (var item in node.children)
                    {
                        Help(item);
                    }
                }
            }

        }

    }
}
