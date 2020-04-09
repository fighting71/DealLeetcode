using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2020 11:23:39 AM
    /// @source : https://leetcode.com/problems/find-median-from-data-stream/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Sort)]
    public class Find_Median_from_Data_Stream
    {

        #region otherSolution

        /** java  PriorityQueue - 排序队列
        private Queue<Long> small = new PriorityQueue(),
                        large = new PriorityQueue();

        public void addNum(int num)
        {
            large.add((long)num);// 借助提供的类特性
            small.add(-large.poll());
            if (large.size() < small.size())
                large.add(-small.poll());
        }

        public double findMedian()
        {
            return large.size() > small.size()
                   ? large.peek()
                   : (large.peek() - small.peek()) / 2.0;
        }

        */
        #endregion

        /// <summary>
        /// Runtime: 316 ms, faster than 62.46% of C# online submissions for Find Median from Data Stream.
        /// Memory Usage: 53.4 MB, less than 20.00% of C# online submissions for Find Median from Data Stream.
        /// 
        /// Runtime: 304 ms, faster than 83.38% of C# online submissions for Find Median from Data Stream.
        /// Memory Usage: 53.4 MB, less than 20.00% of C# online submissions for Find Median from Data Stream.
        /// 
        /// 差不多了...
        /// 
        /// Runtime: 300 ms, faster than 88.83% of C# online submissions for Find Median from Data Stream.
        /// Memory Usage: 53 MB, less than 20.00% of C# online submissions for Find Median from Data Stream.
        /// 
        /// </summary>
        /// <param name="num"></param>
        public void AddNum(int num)
        {

            if(list.Count == 0)
            {
                list.Add(num);
                median = num;
                return;
            }
            int l = 0, r = list.Count - 1,mid;
            while (true)
            {
                if(num <= list[l])
                {
                    list.Insert(l, num);
                    break;
                }
                
                if(num >= list[r])
                {
                    list.Insert(r + 1, num);
                    break;
                }
                // optmize
                if(l == r - 1)
                {
                    list.Insert(r, num);
                    break;
                }
                mid = (l + r) / 2;
                if (num == list[mid])
                {
                    list.Insert(mid, num);
                    break;
                }
                else if(num > list[mid]) l = mid;
                else r = mid;
            }

            median = list.Count % 2 == 0 ? (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2.0 : list[list.Count / 2];

        }

        // time limit 看来只靠FindMedian是不现实的 还是要靠AddNum
        public double FindMedian()
        {
            return median.Value;
        }

        public void TryAddNum2(int num)
        {
            list.Add(num);
            median = null;
        }

        // time limit 看来只靠FindMedian是不现实的 还是要靠AddNum
        public double TryFindMedian2()
        {
            if (median == null)
            {
                list.Sort();
                for (int i = 0; i < list.Count; i++)
                {
                    int than = 0, same = 0, minThan = int.MaxValue;
                    for (int j = 0; j < list.Count && than <= list.Count / 2; j++)
                    {
                        if (i == j) continue;
                        if (list[j] > list[i])
                        {
                            than++;
                            minThan = Math.Min(list[j], minThan);
                        }
                        else if (list[j] == list[i])
                        {
                            same++;
                        }
                    }
                    if (than == list.Count / 2)
                    {
                        median = list.Count % 2 == 0 ? (list[i] + minThan) / 2.0 : list[i];
                        break;
                    }
                    else if (than < list.Count / 2 && same >= list.Count / 2 - than)
                    {
                        median = list[i];
                        break;
                    }
                }
            }
            return median.Value;
        }

        public void TryAddNum(int num)
        {
            list.Add(num);
            median = null;
        }

        // time limit
        public double TryFindMedian()
        {
            if (median == null)
            {

                list.Sort();

                if (list.Count % 2 == 0)
                {
                    median = (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2.0;
                }
                else
                {
                    median = list[list.Count / 2];
                }
            }

            return median.Value;
        }

        #region simple
        // Runtime: 876 ms, faster than 7.45% of C# online submissions for Find Median from Data Stream.
        // Memory Usage: 53 MB, less than 20.00% of C# online submissions for Find Median from Data Stream.
        // kindness test case 
        private List<int> list;

        private double? median;

        public Find_Median_from_Data_Stream()
        {
            list = new List<int>();
        }

        public void SimpleAddNum(int num)
        {
            if (list.Count == 0) list.Insert(0, num);
            else if (list[list.Count - 1] <= num) list.Add(num);
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] >= num)
                    {
                        list.Insert(i, num);
                        break;
                    }
                }
            }

            if (list.Count % 2 == 0)
            {
                median = (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2.0;
            }
            else
            {
                median = list[list.Count / 2];
            }

        }

        public double SimpleFindMedian()
        {
            return median.Value;
        }
        #endregion

    }
}
