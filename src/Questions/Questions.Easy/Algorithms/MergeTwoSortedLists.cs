using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/27/2020 5:22:54 PM
    /// @source : https://leetcode.com/problems/merge-two-sorted-lists/
    /// @des : 
    /// </summary>
    public class MergeTwoSortedLists
    {

        /// <summary>
        /// Runtime: 92 ms, faster than 80.30% of C# online submissions for Merge Two Sorted Lists.
        /// Memory Usage: 25.7 MB, less than 6.45% of C# online submissions for Merge Two Sorted Lists.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode Solution(ListNode l1, ListNode l2)
        {

            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode res = null,item = res;

            bool flag = l1 != null, flag2 = l2 != null,flag3;

            while (flag || flag2)
            {

                if (!flag)
                {
                    item.next = l2;
                    return res;
                }else if (!flag2)
                {
                    item.next = l1;
                    return res;
                }

                flag3 = l1.val <= l2.val;

                if(res == null)
                {
                    if (flag3)
                    {
                        res = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        res = l2;
                        l2 = l2.next;
                    }
                    item = res;
                }
                else
                {
                    if (flag3)
                    {
                        item.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        item.next = l2;
                        l2 = l2.next;
                    }
                    item = item.next;
                }
                flag = l1 != null;
                flag2 = l2 != null;
            }

            return res;

        }

    }
}
