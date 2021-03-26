using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/23/2021 12:28:23 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3678/
    /// @des : 
    /// </summary>
    public class Design_Underground_System
    {

        // Your runtime beats 90.85 % of csharp submissions.
        // Runtime: 376 ms
        // Memory Usage: 49.2 MB
        // over~
        class UndergroundSystem
        {

            public UndergroundSystem()
            {

            }

            /// <summary>
            /// 一位旅客上车了
            /// </summary>
            /// <param name="id">旅客id</param>
            /// <param name="stationName">站台</param>
            /// <param name="t">时间刻度(不考虑24小时轮回，只有+没有-)</param>
            public void CheckIn(int id, string stationName, int t)
            {
                _startDic[id] = (stationName, t);
            }

            /// <summary>
            /// 一位旅客下车了
            /// </summary>
            /// <param name="id">旅客id</param>
            /// <param name="stationName">站台</param>
            /// <param name="t">时间刻度</param>
            public void CheckOut(int id, string stationName, int t)
            {
                if (_startDic.Remove(id, out var info))
                {
                    string key = GetKey(info.stationName, stationName);

                    if (_dic.TryGetValue(key, out var item))
                    {
                        item.Count++;
                        item.Total += t - info.t;
                    }
                    else
                    {
                        _dic[key] = new Item()
                        {
                            Count = 1,
                            Total = t - info.t
                        };
                    }

                }
            }

            /// <summary>
            /// 获取在startStation上车&在endStation下车的平均耗时时长
            /// </summary>
            /// <param name="startStation"></param>
            /// <param name="endStation"></param>
            /// <returns></returns>
            public double GetAverageTime(string startStation, string endStation)
            {
                string key = GetKey(startStation, endStation);

                if (_dic.TryGetValue(key, out var item))
                {
                    return item.Total / (double)item.Count;
                }
                return 0;
            }

            private static string GetKey(string start, string end) => $"{start}_{end}";

            class Item
            {
                /// <summary>
                /// 总有多少旅客
                /// </summary>
                public int Count { get; set; }
                /// <summary>
                /// 总耗时
                /// </summary>
                public int Total { get; set; }
            }

            // {startStation-endStation} -> Item
            Dictionary<string, Item> _dic = new Dictionary<string, Item>();

            // id => (startStation,t)
            Dictionary<int, (string stationName, int t)> _startDic = new Dictionary<int, (string stationName, int t)>();

        }

    }
}
