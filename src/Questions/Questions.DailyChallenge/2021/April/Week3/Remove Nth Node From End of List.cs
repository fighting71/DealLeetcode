using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/19/2021 2:08:52 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3712/
    /// @des : 
    /// </summary>
    public class Remove_Nth_Node_From_End_of_List
    {

        // The number of nodes in the list is sz.
        //1 <= sz <= 30
        //0 <= Node.val <= 100
        //1 <= n <= sz

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            List<ListNode> list = new List<ListNode>();

            while (head != null)
            {
                list.Add(head);
                head = head.next;
            }

            if (list.Count == 0) return null;

            if(n == list.Count)
            {
                if(n == 1)
                {
                    return null;
                }
                return list[1];
            }

            var i = list.Count - n;

            if(n != 1)
            {
                list[i - 1].next = list[i + 1];
            }
            else
            {
                list[i - 1].next = null;
            }
            return list[0];

        }

    }
}
