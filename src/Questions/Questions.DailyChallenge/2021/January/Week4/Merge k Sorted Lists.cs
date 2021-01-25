using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/24/2021 6:00:17 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3615/
    /// @des : <see cref="Questions.Hard.Deal.MergeKLists"/>
    /// </summary>
    public class Merge_k_Sorted_Lists
    {

        // k == lists.length
        //0 <= k <= 10^4
        //0 <= lists[i].length <= 500
        //-10^4 <= lists[i][j] <= 10^4
        //lists[i] is sorted in ascending order.
        //The sum of lists[i].length won't exceed 10^4.

        #region time limit
        public ListNode Try(ListNode[] lists)
        {
            ListNode root = null, curr = root;

            List<int> indexList = Enumerable.Range(0, lists.Length).ToList();

            while (true)
            {
                int minIndex = -1;
                ListNode min = null;
                for (int i = 0; i < indexList.Count; i++)
                {
                    var index = indexList[i];
                    if (lists[index] != null)
                    {
                        if (minIndex == -1 || lists[index].val < min.val)
                        {
                            min = lists[minIndex = index];
                        }
                    }
                    else
                    {
                        indexList.RemoveAt(i--);
                    }
                }

                if (minIndex == -1) break;

                if (root == null)
                {
                    root = curr = min;
                }
                else
                {
                    curr.next = min;
                    curr = min;
                }

                lists[minIndex] = min.next;

                if (indexList.Count == 1) break;

            }
            return root;
        }

        public ListNode Simple(ListNode[] lists)
        {
            ListNode root = null, curr = root;
            int len = lists.Length;
            while (true)
            {
                int minIndex = -1;
                ListNode min = null;
                for (int i = 0; i < len; i++)
                {
                    if(lists[i] != null)
                    {
                        if (minIndex == -1 || lists[i].val < min.val)
                        {
                            min = lists[minIndex = i];
                        }
                    }
                }

                if (minIndex == -1) break;

                if(root == null)
                {
                    root = curr = min;
                }
                else
                {
                    curr.next = min;
                    curr = min;
                }

                lists[minIndex] = min.next;
            }
            curr.next = null;
            return root;
        }
        #endregion

    }
}
