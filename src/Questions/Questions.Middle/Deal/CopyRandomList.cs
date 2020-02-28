using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/1 15:30:11
    /// @source : https://leetcode.com/problems/copy-list-with-random-pointer/
    /// @des : 
    /// </summary>
    public class CopyRandomList
    {
        /**
         * Runtime: 144 ms, faster than 99.75% of C# online submissions for Copy List with Random Pointer.
         * Memory Usage: 26.9 MB, less than 16.67% of C# online submissions for Copy List with Random Pointer.
         *
         * nice 一发入魂~
         * 
         */
        public Node Solution(Node head)
        {
            // 头为空则直接返回 避免后续变量生成...
            if (head == null) return null;
            Node prev = null, root = null, node = head;
            Dictionary<Node, Node> dictionary = new Dictionary<Node, Node>();

            // 遍历node
            while (node != null)
            {
                // 复制val和random
                var newNode = new Node();
                newNode.val = node.val;
                newNode.random = node.random;
                
                // 保存新node的root
                if (root == null) root = newNode;
                
                // 如果存在上一个node 则替换上个node的next指向
                if (prev != null)
                    prev.next = newNode;

                prev = newNode;
                
                // 保留old node -> 指向 new node
                dictionary.Add(node, newNode);
                
                
                // 由于random的指向随机 即可能指向后面的节点 
                //    如果在此处更新random指向，可能在dictionary找不到(old->new)指向
                
                node = node.next;
            }

            node = root;
            // 遍历node 更新 random 指向
            while (node != null)
            {
                if (node.random != null)
                    node.random = dictionary[node.random];
                node = node.next;
            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node()
            {
            }

            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }

        }
    }
}