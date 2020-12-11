using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/10/2020 10:28:02 AM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3560/
    /// @des : 
    /// </summary>
    public class Binary_Search_Tree_Iterator
    {
        // Your runtime beats 70.45 % of csh

        // The number of nodes in the tree is in the range [1, 105].
        //0 <= Node.val <= 106
        //At most 105 calls will be made to hasNext, and next.
        public Binary_Search_Tree_Iterator(TreeNode root)
        {
            Help(root);
        }

        Queue<int> _queue = new Queue<int>();

        private void Help(TreeNode node)
        {
            if (node == null) return;
            // 借助bst的特点：
            // 当前节点 > 所有左子节点
            // 当前节点 < 所有右子节点
            // 故先添加所有左子节点 -> 添加当前节点 -> 所有右子节点
            // 即可保证有序性.
            Help(node.left);
            _queue.Enqueue(node.val);
            Help(node.right);
        }

        public int Next()
        {
            if (_queue.Count == 0) return -1;
            return _queue.Dequeue();
        }

        public bool HasNext()
        {
           return _queue.Count > 0;
        }
    }
}
