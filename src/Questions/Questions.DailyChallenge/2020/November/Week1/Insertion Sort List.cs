using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/2/2020 4:56:54 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Insertion_Sort_List
    {

        public ListNode Solution(ListNode head)
        {

            ListNode root = head, curr = head;

            Stack<ListNode> stack = new Stack<ListNode>();

            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = null;

                if (stack.Count == 0)
                {
                    root = curr;
                    continue;
                }

                ListNode node = stack.Pop(), last = node;

                while (last.val > curr.val && stack.Count > 0)
                {
                    node = stack.Pop();
                }
                if(node != null)
                {
                    node.next = curr.next;
                    curr.next = node;
                }
                if (stack.Count == 0)
                {
                    root = curr;
                }
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.next;
                }
                curr = next;
            }

            return root;
        }

    }
}
