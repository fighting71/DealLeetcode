using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.June.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/10/2021 3:44:32 PM
    /// @source : https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/604/week-2-june-8th-june-14th/3774/
    /// @des : 
    /// </summary>
    public class My_Calendar_I
    {

        // Note:

        //The number of calls to MyCalendar.book per test case will be at most 1000.
        //In calls to MyCalendar.book(start, end), start and end are integers in the range [0, 10^9].

        public interface IMyCalendar
        {
            public bool Book(int start, int end);
        }

        // Your runtime beats 35.26 %
        // Runtime: 388 ms
        // Memory Usage: 44.6 MB
        // optimize : 
        //      a.int[] 替换成类 减少索引查询   b. 使用其他结构替换Link 避免for 所有节点
        public class MyCalendar : IMyCalendar
        {

            public MyCalendar()
            {

            }

            private LinkedList<int[]> list = new LinkedList<int[]>();

            public bool Book(int start, int end)
            {
                
                LinkedListNode<int[]> node = list.First;

                while (node != null)
                {
                    int currStart = node.Value[0];
                    int currEnd = node.Value[1];

                    if (start == currStart || end == currEnd) return false;
                    if (start < currStart && end > currStart) return false;
                    if (start > currStart && start < currEnd) return false;

                    if (currEnd == start)
                    {

                        var next = node.Next;

                        if (next != null)
                        {
                            if (next.Value[0] == end)
                            {
                                node.Value[1] = next.Value[1];
                                // 无须此操作...
                                //list.AddAfter(node, next.Next);
                                list.Remove(next);
                                return true;
                            }

                            if (next.Value[0] < end) return false;
                        }

                        node.Value[1] = end;

                        return true;
                    }
                    if (end < currStart)
                    {
                        list.AddBefore(node, new[] { start, end });
                        return true;
                    }

                    if (end == currStart)
                    {
                        node.Value[0] = start;
                        return true;
                    }
                    node = node.Next;

                }

                list.AddLast(new[] { start, end });
                return true;
            }
        }


    }
}
