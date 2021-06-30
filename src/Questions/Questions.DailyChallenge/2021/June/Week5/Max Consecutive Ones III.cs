using Command.Attr;
using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/29/2021 3:17:26 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/607/week-5-june-29th-june-30th/3796/
    /// @des : 
    /// </summary>
    [Serie(FlagConst.LimitValue, FlagConst.SlidingWindow), Favorite]
    public class Max_Consecutive_Ones_III
    {

        // Constraints:

        //1 <= nums.length <= 10^5
        //nums[i] is either 0 or 1.
        //0 <= k <= nums.length

        class Item
        {
            public bool IsZero { get; set; }
            public int Count { get; set; }

            public override string ToString()
            {
                return $"{(IsZero ? '-' : '+')}{Count}";
            }
        }
        public int Explain(int[] nums, int k)
        {
            // 用于保存当前节点组内的所有节点
            Queue<Item> queue = new Queue<Item>();

            // 当前
            Item curr = default;

            // 当前节点组总和 
            int sum = 0,
                // 最大总和
                res = 0;

            foreach (var num in nums)
            {
                bool isZero = num == 0;
                if (curr == default) // base case
                {
                    curr = new Item { IsZero = isZero, Count = 1 };
                }
                else if (curr.IsZero != isZero)
                {
                    if (curr.IsZero)
                    {
                        // 添加当前节点需要多少k
                        int need;
                        while ((need = curr.Count - k) > 0 && queue.Count > 0)
                        {
                            // 获取最值
                            res = Math.Max(res, sum + k);

                            // 获取最早的节点
                            Item prev = queue.Peek();

                            if (prev.IsZero)
                            {
                                // 节点值 > 所需值
                                if (prev.Count > need)
                                {
                                    // 将prev节点节点值中的need部分转移
                                    sum -= need;
                                    prev.Count -= need;
                                    k += need;
                                    break;
                                }
                                else
                                {
                                    // 移除prev节点，并转移至k上
                                    sum -= prev.Count;
                                    k += prev.Count;
                                }
                            }
                            else
                            {
                                sum -= prev.Count;
                            }
                            queue.Dequeue();
                        }

                        if (k >= curr.Count)
                        {
                            sum += curr.Count;
                            k -= curr.Count;
                        }
                        else
                        {
                            sum = k;
                            curr.Count = k;
                            k = 0;
                        }
                    }
                    else
                    {
                        sum += curr.Count;
                    }
                    // 获取最值
                    res = Math.Max(res, sum);
                    // 将当前节点加入节点组
                    queue.Enqueue(curr);

                    curr = new Item { IsZero = isZero, Count = 1 };
                }
                else
                {
                    curr.Count++;
                }

            }

            if (curr.IsZero)
            {
                res = Math.Max(res, sum + Math.Min(curr.Count, k));
            }
            else
            {
                res = Math.Max(res, sum + curr.Count);
            }

            return res;
        }

        // Your runtime beats 44.95 % of csharp submissions.
        public int Try2(int[] nums, int k)
        {
            Queue<Item> queue = new Queue<Item>();

            Item curr = default;

            int sum = 0, res = 0;

            foreach (var num in nums)
            {
                bool isZero = num == 0;
                if (curr == default)
                {
                    curr = new Item { IsZero = isZero, Count = 1 };
                }
                else if (curr.IsZero != isZero)
                {
                    if (curr.IsZero)
                    {
                        int need;
                        while ((need = curr.Count - k) > 0 && queue.Count > 0)
                        {
                            res = Math.Max(res, sum + k);
                            Item prev = queue.Peek();

                            if (prev.IsZero)
                            {
                                if (prev.Count > need)
                                {
                                    sum -= need;
                                    prev.Count -= need;
                                    k += need;
                                    break;
                                }
                                else
                                {
                                    sum -= prev.Count;
                                    k += prev.Count;
                                }
                            }
                            else
                            {
                                sum -= prev.Count;
                            }
                            queue.Dequeue();
                        }

                        if (k >= curr.Count)
                        {
                            sum += curr.Count;
                            k -= curr.Count;
                        }
                        else
                        {
                            sum = k;
                            curr.Count = k;
                            k = 0;
                        }
                    }
                    else
                    {
                        sum += curr.Count;
                    }
                    res = Math.Max(res, sum);
                    queue.Enqueue(curr);

                    curr = new Item { IsZero = isZero, Count = 1 };
                }
                else
                {
                    curr.Count++;
                }

            }

            if (curr.IsZero)
            {
                res = Math.Max(res, sum + Math.Min(curr.Count, k));
            }
            else
            {
                res = Math.Max(res, sum + curr.Count);
            }

            return res;
        }

        // bug
        public int Try(int[] nums, int k)
        {

            List<Item> list = new List<Item>();

            Item prev = default;

            foreach (var item in nums)
            {
                bool isZero = item == 0;
                if (prev == default || prev.IsZero != isZero)
                {
                    list.Add(prev = new Item { IsZero = isZero, Count = 1 });
                }
                else
                {
                    prev.Count++;
                }
            }

            int res = 0;

            Queue<(Item, int useK)> queue = new Queue<(Item, int useK)>();

            int sum = 0;

            Console.WriteLine(string.Join(',', list));

            foreach (var item in list)
            {
                if (item.IsZero)
                {

                    while (queue.Count > 0 && k < item.Count)
                    {
                        res = Math.Max(res, sum + k);
                        (Item, int useK) p = queue.Dequeue();

                        if (p.useK > 0)
                        {
                            k += p.useK;
                            sum -= p.useK;
                        }
                        else
                        {
                            sum -= p.Item1.Count;
                        }
                    }

                    if (k >= item.Count)
                    {
                        k -= item.Count;
                        sum += item.Count;
                        queue.Enqueue((item, item.Count));
                    }
                    else
                    {
                        sum = k;
                        k = 0;
                        queue.Enqueue((item, k));
                    }
                }
                else
                {
                    sum += item.Count;
                    queue.Enqueue((item, 0));
                }
                res = Math.Max(sum, res);
            }

            return res;

        }
        public int Simple(int[] nums, int k)
        {
            List<Item> list = new List<Item>();

            Item prev = default;

            foreach (var item in nums)
            {
                bool isZero = item == 0;
                if(prev == default || prev.IsZero != isZero)
                {
                    prev = new Item { IsZero = isZero, Count = 1 };
                    list.Add(prev);
                }
                else
                {
                    prev.Count++;
                }
            }
            int res = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int sum = 0,remindK = k;
                for (int j = i; j < list.Count; j++)
                {
                    var curr = list[j];
                    if (curr.IsZero)
                    {
                        if (curr.Count <= remindK)
                        {
                            remindK -= curr.Count;
                            sum += curr.Count;
                        }
                        else
                        {
                            sum += remindK;
                            break;
                        }
                    }
                    else sum += curr.Count;
                }
                res = Math.Max(sum, res);
            }
            return res;

        }

    }
}
