using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/4/2021 10:00:46 AM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3627/
    /// @des : 
    ///     查看链表是否有循环 -> 
    ///         固定解法：
    ///         定义两个node : slow fast
    ///         slow 每次移动一个节点，fast每次移动两个(>1即可)节点
    ///         若slow == fast 则表示循环
    /// </summary>
    public class Linked_List_Cycle
    {

        // Your runtime beats 89.65 % 
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                if (fast == slow) return true;
                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }

    }
}
