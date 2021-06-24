using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/23/2021 4:50:00 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3789/
    /// @des : 
    /// 
    ///     给定一个列表，将列表进行局部反转（反转第left个元素到第right个元素）
    /// 
    /// </summary>
    [Serie(FlagConst.LinkedList, FlagConst.Reverse)]
    public class Reverse_Linked_List_II
    {

        // Constraints:

        //The number of nodes in the list is n.
        //1 <= n <= 500
        //-500 <= Node.val <= 500
        //1 <= left <= right <= n

        //Follow up: Could you do it in one pass?

        //  1 2 3 4

        // Your runtime beats 88.97 % of csharp submissions.
        // over  optimize => 拆分循环，规避if
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) return head;

            ListNode prev = null, curr = head, front = null, first = null;

            for (int i = 1; i < right; i++)
            {
                ListNode next = curr.next;
                if (i > left)
                {
                    next = curr.next;
                    curr.next = prev;
                }
                else if(i == left)
                {
                    first = curr;
                    front = prev;
                }
                prev = curr;
                curr = next;
            }
            first.next = curr.next;
            curr.next = prev;
            if(front != null)
            {
                front.next = curr;
                return head;
            }
            else
            {
                return curr;
            }
        }
    }
}
