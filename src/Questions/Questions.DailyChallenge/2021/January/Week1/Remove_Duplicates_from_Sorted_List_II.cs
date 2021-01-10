using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/5/2021 5:09:54 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3593/
    /// @des : 
    /// </summary>
    public class Remove_Duplicates_from_Sorted_List_II
    { /*
         * The number of nodes in the list is in the range [0, 300].
         * -100 <= Node.val <= 100
         * The list is guaranteed to be sorted in ascending order.
         */

        // Your runtime beats 33.80 %
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode node = head, next, root = null, prev = null;

            while (node != null)
            {
                next = node.next;

                if (next == null || next.val != node.val)
                {
                    if (prev != null)
                        prev.next = node;
                    if (root == null) root = node;
                    prev = node;
                    node = node.next;
                }
                else
                {
                    while ((node = node.next) != null && node.val == next.val)
                    {

                    }
                    if (prev != null)
                        prev.next = null;
                }
            }
            return root;
        }
    }
}
