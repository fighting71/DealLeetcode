using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/5/2021 4:01:44 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3660/
    /// @des : 
    /// </summary>
    public class Intersection_of_Two_Linked_Lists
    {
        // Your runtime beats 92.47 %
        public ListNode Try2(ListNode headA, ListNode headB)
        {
            List<ListNode> listA = GetList(headA);
            List<ListNode> listB = GetList(headB);

            int len = listA.Count, len2 = listB.Count, i, j;

            if (len > len2)
            {
                i = len - len2;
                j = 0;
            }
            else
            {
                j = len2 - len;
                i = 0;
            }
            for (; i < len; i++, j++)
            {
                if (listA[i] == listB[j])
                    return listA[i];
            }
            return null;
            List<ListNode> GetList(ListNode node)
            {
                List<ListNode> list = new List<ListNode>();

                while (node != null)
                {
                    list.Add(node);
                    node = node.next;
                }

                return list;

            }
        }

        // bug: 香蕉指引用相等而不是值相等，题目也不说明白点。
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            List<ListNode> listA = GetList(headA);
            List<ListNode> listB = GetList(headB);

            ListNode res = null;

            for (int i = listA.Count - 1, j = listB.Count - 1; i > 0 && j > 0; i--, j--)
            {
                if (listA[i].val != listB[j].val) return res;
                res = listA[i];
            }

            return res;
            List<ListNode> GetList(ListNode node)
            {
                List<ListNode> list = new List<ListNode>();

                while (node != null)
                {
                    list.Add(node);
                    node = node.next;
                }

                return list;

            }

        }
    }
}
