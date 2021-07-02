using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.July.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 7/2/2021 4:58:49 PM
    /// @source : https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3800/
    /// @des : 
    /// 
    ///     给定一个有序整数数组arr，两个整数k和x，返回数组中最接近x的k个整数。结果也应该按升序排序。
    ///     整数a比整数b更接近x，如果:
    ///     
    ///     |a - x| < |b - x|, or
    ///     |a - x| == |b - x| and a<b
    /// 
    /// </summary>
    [Serie(FlagConst.Slow, FlagConst.Sort)]
    public class Find_K_Clsest_Elements
    {

        // Constraints:

        //1 <= k <= arr.length
        //1 <= arr.length <= 10^4
        //arr is sorted in ascending order.
        //-10^4 <= arr[i], x <= 10^4

        class Item
        {
            public int Num { get; set; }
            public int Diff { get; set; }
        }

        // todo
        public IList<int> Try3(int[] arr, int k, int x)
        {
            LinkedList<Item> link = new LinkedList<Item>();

            LinkedListNode<Item> maxNode = default;

            int maxDiff = 0;

            foreach (var num in arr)
            {
                var diff = Math.Abs(x - num);

                if(link.Count == 0)
                {
                    maxNode = new LinkedListNode<Item>(new Item() { Diff = diff, Num = num });
                    link.AddLast(maxNode);
                }
                else
                {
                    // todo..... 
                    //if (diff < maxNode.Value.Diff)
                    //{
                    //    link.RemoveLast();

                    //    var curr = maxNode = link.First;

                    //    while (curr != null)
                    //    {
                    //        //if(maxNode)
                    //    }

                    //}
                    //else if(diff == maxNode.Value.Diff && num < maxNode.Value.Num)
                    //{
                    //    maxNode.Value.Num = num;
                    //}
                }

            }
            return link.Select(u => u.Num).OrderBy(u => u).ToArray();

        }

        // %12 + more slow
        public IList<int> Try2(int[] arr, int k, int x)
        {
            List<(int num, int diff)> list = new List<(int num, int diff)>();

            foreach (var num in arr)
            {
                var diff = Math.Abs(x - num);

                int index = BinarySearch(num, diff);

                if (index == k)
                {
                    continue;
                }
                list.Insert(index, (num, diff));

                if (list.Count > k)
                {
                    list.RemoveAt(k);
                }
            }

            return list.Select(u => u.num).OrderBy(u => u).ToArray();

            int BinarySearch(int num, int diff)
            {
                if (list.Count == 0) return 0;

                int len = list.Count, left = 0, right = len;

                while (left < right)
                {
                    var mid = left + (right - left) / 2;
                    var curr = list[mid];
                    if (curr.diff == diff)
                    {
                        if (curr.num == num) return mid;
                        else if (curr.num > num) return right = mid;
                        else left = mid + 1;
                    }
                    else if (curr.diff > diff) right = mid;// **
                    else left = mid + 1;
                }

                return right;
            }

        }


        // Your runtime beats 24.89 % of csharp submissions.
        public IList<int> Simple(int[] arr, int k, int x)
        {
            return arr.OrderBy(u => Math.Abs(u - x)).ThenBy(u => u).Take(k).OrderBy(u => u).ToArray();
        }

    }
}
