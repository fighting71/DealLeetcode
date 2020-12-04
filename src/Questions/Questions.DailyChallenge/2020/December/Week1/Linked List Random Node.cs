using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.December.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/3/2020 9:27:49 AM
    /// @source : https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3552/
    /// @des : 
    /// </summary>
    public class Linked_List_Random_Node
    {
        private readonly ListNode head;

        /** @param head The linked list's head.
Note that the head is guaranteed to be not null, so it contains at least one node. */
        public Linked_List_Random_Node(ListNode head)
        {
            list.Add(this.head = head);
        }

        List<ListNode> list = new List<ListNode>();

        int realCount = int.MaxValue;

        Random rand = new Random();

        // Your runtime beats 80.65 %
        /** Returns a random node's value. */
        public int GetRandom()
        {
            var num = rand.Next(realCount);

            if (list.Count == 0)
            {
                var node = head;
                while (--num > 0 && node.next != null)
                {
                    node = node.next;
                    list.Add(node);
                }
                if (node.next == null) realCount = list.Count;
                return node.val;
            }
            else if (num < list.Count) return list[num].val;
            else
            {
                var node = list[list.Count - 1];
                num -= list.Count;
                while (--num > 0 && node.next != null)
                {
                    node = node.next;
                    list.Add(node);
                }
                if (node.next == null) realCount = list.Count;
                return node.val;
            }

        }
    }
}
