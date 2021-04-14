using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/14/2021 4:43:15 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3707/
    /// @des : 
    /// </summary>
    [Serie(FlagConst.ListNode)]
    public class Partition_List
    {

        // The number of nodes in the list is in the range [0, 200].
        //-100 <= Node.val <= 100
        //-200 <= x <= 200

        // Your runtime beats 36.68 % 
        public ListNode Partition(ListNode head, int x)
        {
            ListNode root = null, left = null, rightRoot = null, right = null;

            while (head != null)
            {
                var node = head;
                head = head.next;
                node.next = null;
                var curr = node.val;
                if (curr < x)
                {
                    if (root == null)
                    {
                        root = left = node;
                    }
                    else
                    {
                        left = left.next = node;
                    }
                }
                else
                {
                    if (rightRoot == null)
                    {
                        rightRoot = right = node;
                    }
                    else
                    {
                        right = right.next = node;
                    }
                }
            }

            if (root != null)
            {
                left.next = rightRoot;
                return root;
            }
            else
            {
                return rightRoot;
            }

        }

    }
}
