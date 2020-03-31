using System;
using System.Collections.Generic;
using System.Text;
using Command.CommonStruct;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 10:02:34 AM
    /// @source : https://leetcode.com/problems/remove-duplicates-from-sorted-list/
    /// @des : 
    /// </summary>
    public class RemoveDuplicatesFromSortedList
    {

        /// <summary>
        /// Runtime: 96 ms, faster than 66.86% of C# online submissions for Remove Duplicates from Sorted List.\
        /// Memory Usage: 25.9 MB, less than 16.67% of C# online submissions for Remove Duplicates from Sorted List.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode Solution(ListNode head)
        {

            if (head == null) return head;

            ListNode prev = head, node = prev.next;

            while(node != null)
            {

                if(node.val == prev.val)
                    prev.next = node.next;
                else
                    prev = node;

                node = node.next;

            }

            return head;

        }

    }
}
