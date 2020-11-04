using Command.Attr;
using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/2/2020 4:56:54 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3517/
    /// @des : 
    /// </summary>
    public class Insertion_Sort_List
    {
        // Runtime: 92 ms
        // Memory Usage: 26.1 MB
        // Your runtime beats 97.48 % of csharp submissions.
        // eiheihei...
        public ListNode Optimize(ListNode head)
        {

            if (head == null) return head;

            ListNode root = head, curr = head.next;
            root.next = null;
            ListNode last = root;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = null;

                if (root.val > curr.val)
                {
                    curr.next = root;
                    root = curr;
                }
                else if(last.val <= curr.val)
                {
                    last.next = curr;
                    last = curr;
                }
                else
                {
                    ListNode node = root.next, prev = root;
                    while (true)
                    {
                        if (node.val > curr.val)
                        {
                            curr.next = node;
                            prev.next = curr;
                            break;
                        }
                        prev = node;
                        node = node.next;
                    }

                }
                curr = next;
            }

            return root;
        }

        // Runtime: 420 ms
        // Memory Usage: 26.6 MB
        public ListNode Solution(ListNode head)
        {

            ListNode root = head, curr = head;

            Stack<ListNode> stack = new Stack<ListNode>();

            while (curr != null)
            {
                ListNode next = curr.next;
                ListNode node = null;
                curr.next = null;

                while (true)
                {
                    if (stack.Count == 0)
                    {
                        root = curr;
                        if (node != null)
                            curr.next = node;
                        break;
                    }
                    node = stack.Pop();
                    if (node.val > curr.val) continue;
                    curr.next = node.next;
                    node.next = curr;
                    stack.Push(node);
                    break;

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

        // 以前做过...
        //188 ms	23.8 MB
        public ListNode OldSolution(ListNode head)
        {
            if (head == null) return head;

            var node = head;

            List<ListNode> list = new List<ListNode>();

            while (node != null)
            {
                var index = -1;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (node.val < list[i].val)
                    {
                        index = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (index != -1)
                {
                    if (index != 0)
                        list[index - 1].next = node;

                    list.Insert(index, node);
                    node = node.next;
                    list[index].next = list[index + 1];

                    list[list.Count - 1].next = null;
                }
                else
                {
                    if (list.Count > 0) list[list.Count - 1].next = node;
                    list.Add(node);
                    node = node.next;
                }
            }

            return list[0];
        }
    }
}
