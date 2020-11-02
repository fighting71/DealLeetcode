using Command.Attr;
using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/2/2020 10:45:42 AM
    /// @source : https://leetcode.com/explore/featured/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3516/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Convert_Binary_Number_in_a_Linked_List_to_Integer
    {
        //The Linked List is not empty.
        //Number of nodes will not exceed 30.
        //Each node's value is either 0 or 1.

        // Runtime: 92 ms
        // Memory Usage: 25.1 MB
        // Your runtime beats 49.73 % of csharp submissions
        public int Simple(ListNode head)
        {
            int res = 0;

            while (head != null)
            {
                res = res * 2 + head.val;
                head = head.next;
            }
            return res;
        }

    }
}
