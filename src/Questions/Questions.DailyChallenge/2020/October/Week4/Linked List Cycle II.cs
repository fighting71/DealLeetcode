using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/27/2020 4:03:57 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3509/
    /// @des : 
    /// </summary>
    public class Linked_List_Cycle_II
    {
        //Runtime: 100 ms
        //Memory Usage: 27.3 MB
        // Your runtime beats 53.60 % of csharp submissions.
        public ListNode Simple(ListNode head)
        {
            if (head == null) return null;
            ISet<ListNode> set = new HashSet<ListNode>() { head };

            ListNode next = head.next;
            while (next != null)
            {
                if (set.Contains(next)) return next;
                set.Add(next);
                next = next.next;
            }
            return null;
        }

        // Runtime: 100 ms
        // Memory Usage: 27.2 MB
        // @before optimize 没多大变化... ?

        // Runtime: 88 ms
        // Memory Usage: 27.3 MB
        // Your runtime beats 97.88 % of csharp submissions
        // nice!
        public ListNode Optimize(ListNode head)
        {
            if (head == null) return null;
            // stack 先进后出
            Stack<ListNode> stack = new Stack<ListNode>(), fastStack = new Stack<ListNode>();
            // core think : 
            //      slow : 一个一个跳跃
            //      fast : 两个两个跳跃
            //  理论依据：只要是循环的，总有一天 slow会等于fast
            ListNode slow = head, fast = head.next, res;

            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    res = slow;
                    while (stack.Count > 0)// 此处不能直接返回，可能重合的是后面的项
                    {
                        if(stack.Count > 1) // *** optimize
                        {
                            var next = stack.Pop();
                            slow = stack.Pop();
                            fast = fastStack.Pop();
                            if (slow == fast) res = slow;// key code:如果前一个相等==>后一个肯定相等
                            else if (next == fast.next) res = next;
                            else break;
                        }
                        else
                        {
                            slow = stack.Pop();
                            fast = fastStack.Pop();
                            if (slow == fast.next) res = slow;
                            else break;
                        }
                    }
                    return res;
                }
                stack.Push(slow);
                fastStack.Push(fast);
                slow = slow.next;
                fast = fast.next.next;
            }

            return null;
        }

    }
}
