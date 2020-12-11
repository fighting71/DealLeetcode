using System;
using System.Collections.Generic;
using System.Text;

namespace Command.CommonStruct.Tree
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/11/2020 2:00:37 PM
    /// @source : 
    /// @des : 红黑树
    /// </summary>
    // todo : late 3000 years...
    public class RedBlackTree
    {
        private class Node
        {
            public int Val { get; set; }
            
            /// <summary>
            /// 是否是红节点
            /// </summary>
            public bool IsRed { get; set; }
        }

        private TreeNode<Node> _root;

        public RedBlackTree()
        {

        }

        public void Add(int num)
        {
            if (_root == null)
            {
                _root = new Node { Val = num };
            }
            else InternalAdd(_root, num);
        }

        private void InternalAdd(TreeNode<Node> node,int num)
        {
            if(num >= node.val.Val)
            {
                if(node.right == null)
                {
                    node.right = new TreeNode<Node>(new Node { Val = num, IsRed = true }) { parent = node};

                    return;
                }
                InternalAdd(node.right, num);
            }
            else
            {
                if (node.left == null)
                {
                    node.left = new TreeNode<Node>(new Node { Val = num, IsRed = true }) { parent = node };
                    return;
                }
                InternalAdd(node.left, num);
            }
        }

    }
}
