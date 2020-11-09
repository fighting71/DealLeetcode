using Command.Attr;
using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week1
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/9/2020 2:49:42 PM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3522/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Add_Two_Numbers_II
    {

        // 差不多。
        public ListNode Optimize(ListNode l1, ListNode l2)
        {

            if (l1.val == 0) return l2;
            if (l2.val == 0) return l1;

            Stack<int> stack = new Stack<int>(), stack2 = new Stack<int>();

            bool flag, flag2;

            int count = 0, count2 = 0;

            while (true)
            {
                flag = l1 == null;
                flag2 = l2 == null;
                if (flag && flag2) break;

                if (flag)
                {
                    stack2.Push(l2.val);
                    l2 = l2.next;
                    count2++;
                }
                else if (flag2)
                {
                    stack.Push(l1.val);
                    l1 = l1.next;
                    count++;
                }
                else
                {
                    count++;
                    count2++;
                    stack.Push(l1.val);
                    l1 = l1.next;
                    stack2.Push(l2.val);
                    l2 = l2.next;
                }
            }

            ListNode res = null;
            int num = 0;

            if (count2 > count)
            {
                for (int i = 0; i < count; i++)
                {
                    num += stack.Pop() + stack2.Pop();
                    res = new ListNode(num % 10, res);
                    num /= 10;
                }
                for (int i = count; i < count2; i++)
                {
                    num += stack2.Pop();
                    res = new ListNode(num % 10, res);
                    num /= 10;
                }
            }
            else
            {
                for (int i = 0; i < count2; i++)
                {
                    num += stack.Pop() + stack2.Pop();
                    res = new ListNode(num % 10, res);
                    num /= 10;
                }
                for (int i = count2; i < count; i++)
                {
                    num += stack.Pop();
                    res = new ListNode(num % 10, res);
                    num /= 10;
                }
            }

            if (num > 0)
            {
                return new ListNode(num, res);
            }

            return res;
        }

        // Runtime: 112 ms
        // Memory Usage: 28.2 MB
        // Your runtime beats 45.57 % of csharp submissions.
        public ListNode Simple(ListNode l1, ListNode l2)
        {

            if (l1.val == 0) return l2;
            if (l2.val == 0) return l1;

            Stack<int> stack = new Stack<int>(), stack2 = new Stack<int>();

            while (true)
            {
                bool flag = l1 == null, flag2 = l2 == null;

                if (flag && flag2) break;

                if (flag)
                {
                    stack2.Push(l2.val);
                    l2 = l2.next;
                }
                else if (flag2)
                {
                    stack.Push(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    stack.Push(l1.val);
                    l1 = l1.next;
                    stack2.Push(l2.val);
                    l2 = l2.next;
                }
            }

            ListNode res = null;
            int num = 0;

            while (true)
            {
                bool flag = stack.Count == 0, flag2 = stack2.Count == 0;

                if (flag && flag2) break;
                if(flag)
                {
                    num += stack2.Pop();
                }
                else if (flag2)
                {
                    num += stack.Pop();
                }
                else
                {
                    num += stack.Pop() + stack2.Pop();
                }

                var node = new ListNode(num % 10, res);
                res = node;
                num /= 10;
            }

            if(num > 0)
            {
                res = new ListNode(num, res);
            }

            return res;
        }

    }
}
