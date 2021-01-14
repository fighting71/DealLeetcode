using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/14/2021 2:47:29 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3601/
    /// @des : 说明不是很清晰...
    ///     给定两个链，将两个链相加
    ///     例如：
    ///         5->5->3 + 5->5->2->1 ==  0->1->6->1
    /// </summary>
    public class Add_Two_Numbers
    {
        // Your runtime beats 92.28
        public ListNode Simple(ListNode l1, ListNode l2)
        {

            ListNode root = null, node = null;
            int num = 0;
            while (true)
            {
                bool flag = l1 == null, flag2 = l2 == null;

                if (flag && flag2) break;
                if (!flag)
                {
                    num += l1.val;
                    l1 = l1.next;
                }
                if (!flag2)
                {
                    num += l2.val;
                    l2 = l2.next;
                }

                var curr = new ListNode(num % 10);

                num /= 10;

                if (root == null)
                    root = curr;
                else node.next = curr;

                node = curr;

            }

            if (num > 0)
            {
                node.next = new ListNode(num);
            }

            return root;
        }
    }
}
