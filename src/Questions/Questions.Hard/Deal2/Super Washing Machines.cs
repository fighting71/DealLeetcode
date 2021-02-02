using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/2/2021 10:23:51 AM
    /// @source : https://leetcode.com/problems/super-washing-machines/
    /// @des : 
    /// </summary>
    [Obsolete("bug")]
    public class Super_Washing_Machines
    {

        // The range of n is [1, 10000].
        // The range of dresses number in a super washing machine is [0, 1e5].

        class Item
        {
            public int Diff { get; set; }
            public int Need { get; set; }
        }

        public int Try3(int[] machines)
        {

            int len = machines.Length, sum = machines.Sum();

            if (sum % len != 0) return -1;

            int avg = sum / len, res = 0;

            (int diff, int need)[] arr = new (int diff, int need)[len];

            var diff = machines[0] - avg;
            var prev = arr[0] = (diff, Math.Abs(diff));

            for (int i = 1; i < len; i++)
            {
                int curr = machines[i] - avg; // 当前差值

                if (prev.diff == 0)
                {
                    prev = arr[i] = (curr, Math.Abs(curr));
                    continue;
                }

                if (curr == 0)
                {
                    prev = arr[i] = (prev.diff, prev.need + 1);
                    continue;
                }
                if (prev.diff < 0 == curr < 0)
                {
                    diff = prev.diff + curr;
                    prev = arr[i] = (diff, Math.Max(prev.need, Math.Abs(diff)));
                }
                else
                {
                    int currDiff = prev.diff + curr, currNeed = prev.need;
                    if (i > 1 && curr > 0)
                    {
                        var first = arr[i - 2];
                        if (first.diff > 0)
                        {
                            currNeed = Math.Max(-machines[i - 1] - Math.Min(first.diff, curr), Math.Max(first.need, curr));
                            res = Math.Max(res, currNeed);
                            currNeed = Math.Abs(currDiff);
                        }
                    }
                    currNeed = Math.Max(currNeed, Math.Abs(curr));
                    if (currDiff == 0)
                    {
                        res = Math.Max(res, currNeed);
                    }
                    prev = arr[i] = (currDiff, currNeed);
                }

            }
            return res;
        }

        public int Try2(int[] machines)
        {
            int len = machines.Length, sum = machines.Sum();

            if (sum % len != 0) return -1;

            int avg = sum / len, res = 0;

            (int diff,int need)[] arr = new (int diff, int need)[len];

            var diff = machines[0] - avg;
            var prev = arr[0] = (diff, Math.Abs(diff));

            for (int i = 1; i < len; i++)
            {
                int curr = machines[i] - avg; // 当前差值

                if(prev.diff == 0)
                {
                    prev = arr[i] = (curr, Math.Abs(curr));
                    continue;
                }

                if (curr == 0)
                {
                    prev = arr[i] = (prev.diff, prev.need + 1);
                    continue;
                }
                if (prev.diff < 0 == curr < 0)
                {
                    diff = prev.diff + curr;
                    prev = arr[i] = (diff, Math.Max(prev.need, Math.Abs(diff)));
                }
                else
                {
                    int currDiff = prev.diff + curr, currNeed = prev.need;
                    if(i > 1 && curr > 0)
                    {
                        var first = arr[i - 2];
                        if (first.diff > 0)
                        {
                            currNeed = Math.Max(-machines[i-1] - Math.Min(first.diff, curr), Math.Max(first.need, curr));
                            res = Math.Max(res, currNeed);
                            currNeed = Math.Abs(currDiff);
                        }
                    }
                    currNeed = Math.Max(currNeed, Math.Abs(curr));
                    if (currDiff == 0)
                    {
                        res = Math.Max(res, currNeed);
                    }
                    prev = arr[i] = (currDiff, currNeed);
                }

            }

            Console.WriteLine(string.Join(",", machines.Select(u => u - avg)));

            //ShowTools.ShowMulti(new Dictionary<string, object>()
            //{
            //    {nameof(avg),avg },
            //    {nameof(arr),arr }
            //});

            return res;

        }
        // bug: [5,2,5] => [5>2<5] => 1
        public int Try(int[] machines)
        {
            int len = machines.Length;
            int sum = machines.Sum();

            if (sum % len != 0) return -1;

            int avg = sum / len;

            int diff = 0, need = 0, res = 0;

            for (int i = 0; i < len; i++)
            {
                int curr = machines[i] - avg; // 当前差值
                Console.WriteLine(curr);
                if (diff == 0)
                {
                    diff = curr;
                    need = Math.Abs(diff);
                    continue;
                }

                if (curr == 0)
                {
                    need++;// 距离+1,所需+1
                    continue;
                }

                bool nonnegative = diff > 0, currNonnegative = curr > 0;
                diff += curr; 
                if (nonnegative == currNonnegative) // 符号相同
                {
                    need = Math.Max(need, Math.Abs(diff));
                }
                else
                {
                    if (diff == 0) // 刚好抵消
                    {
                        res += need;
                        need = 0;
                        continue;
                    }
                    bool flag2 = diff > 0;
                    if (nonnegative != flag2)// 符号更改，重新计算need
                    {
                        need = Math.Max(need, Math.Abs(curr));
                    }
                }
            }
            return res;

        }

    }
}
