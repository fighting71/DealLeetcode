using Command.CommonStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2020 11:44:02 AM
    /// @source : https://leetcode.com/problems/reverse-nodes-in-k-group/
    /// @des : 
    /// </summary>
    public class ReverseKGroup
    {

        /// <summary>
        /// Runtime: 100 ms, faster than 63.58% of C# online submissions for Reverse Nodes in k-Group.
        /// Memory Usage: 26.3 MB, less than 20.00% of C# online submissions for Reverse Nodes in k-Group.
        /// 
        /// Runtime: 88 ms, faster than 99.34% of C# online submissions for Reverse Nodes in k-Group.
        /// Memory Usage: 26.5 MB, less than 20.00% of C# online submissions for Reverse Nodes in k-Group.
        /// 
        /// 一次通关~
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode Solution(ListNode head, int k)
        {

            // think: 每过k个节点 进行一次反转
            // 反转=》需要将前k个元素进行反转
            //  故需要一个临时区存放k个元素
            //  然后从后往前取进行反转
            //  反转后清空临时区

            ListNode root = null, node = head, prev = null, eachNode;

            // 考虑临时区的特性 stack的先进后出 最为符合.
            Stack<ListNode> stack = new Stack<ListNode>(k);

            // 用于验证是否经过k个节点
            int num = 0;

            while (node!=null)
            {
                num++;
                stack.Push(node);
                // 反转不影响遍历的下一个节点 故先进行赋值
                node = node.next;

                if (num % k == 0)
                {
                    if(root == null)
                    {
                        root = prev = stack.Pop();
                    }
                    else
                    {
                        prev = prev.next = stack.Pop();
                    }

                    while (stack.Count != 0 && (eachNode = stack.Pop()) != null)
                    {
                        prev = prev.next = eachNode;
                    }
                    //prev.next = null;//避免循环嵌套
                    //避免多余的未包含/next重新指向
                    prev.next = node;
                }

            }

            // k>count(head)
            return root ?? head;

        }

        /// <summary>
        /// Runtime: 88 ms, faster than 99.34% of C# online submissions for Reverse Nodes in k-Group.
        /// Memory Usage: 26.4 MB, less than 20.00% of C# online submissions for Reverse Nodes in k-Group.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode Clear(ListNode head, int k)
        {

            ListNode root = null, node = head, prev = null;

            Stack<ListNode> stack = new Stack<ListNode>(k);

            while (node != null)
            {

                // 缓冲区已有k-1个元素则表示满k 则进行一次反转
                if (stack.Count == k - 1)
                {
                    if (root == null)
                        root = prev = node;
                    else
                        prev = prev.next = node;

                    node = node.next;

                    for (int i = 1; i < k; i++)
                        prev = prev.next = stack.Pop();

                    prev.next = node;
                }
                else
                {
                    stack.Push(node);
                    node = node.next;
                }

            }

            return root ?? head;

        }

    }
}
