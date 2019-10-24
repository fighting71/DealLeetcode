using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/19 星期一 下午 2:25:20
    /// @source : https://leetcode.com/problems/my-calendar-iii/
    /// @des : 
    /// </summary>
    public class MyCalendarThree
    {

        // 记录区间预定最大值，用于返回。
        private int _maxCount;

        // 记录每个不同的区间
        private List<int[]> _list = new List<int[]>();

        public MyCalendarThree()
        {
        }

        /**
         * Runtime: 308 ms, faster than 83.33% of C# online submissions for My Calendar III.
         * Memory Usage: 31 MB, less than 100.00% of C# online submissions for My Calendar III.
         */
        public int Book(int start, int end)
        {

            Console.WriteLine($"传入：{start} - {end}");

            // 如果历史记录无区间
            if (_list.Count == 0)
            {
                _list.Add(new[] {start, end, 1});
                _maxCount = 1;
            }
            else
                // 遍历区间中的元素
                for (int i = 0; i < _list.Count; i++)
                {
                    if (start >= _list[i][1])// 如果左边界>=元素右边界 
                    {
                        if (i == _list.Count - 1)// 遍历结束则直接保存
                        {
                            _list.Add(new[] {start, end, 1});
                            _maxCount = Math.Max(_maxCount, 1);
                            break;
                        }

                        continue;
                    }

                    if (end <= _list[i][0])// 如果右边界>=元素左边界  则直接添加
                    {
                        _list.Insert(i, new[] {start, end, 1});
                        _maxCount = Math.Max(_maxCount, 1);
                        break;
                    }

                    // 区间完全重合 直接预订数++
                    if (start == _list[i][0] && end == _list[i][1])
                    {
                        _list[i][2]++;
                        _maxCount = Math.Max(_list[i][2], _maxCount);
                        break;
                    }

                    //区间部分重合
                    if (end > _list[i][1])// 右边界>元素右边界 则操作后任需要处理 元素右边界 -> 右边界
                    {
                        var prev = _list[i][1];
                        Helper(start, _list[i][1], _list, i);
                        start = prev;
                    }
                    else
                    {
                        Helper(start, end, _list, i);
                        break;
                    }
                }

            Console.WriteLine($@"
res : {_maxCount}
list : {JsonConvert.SerializeObject(_list)}
");

            return _maxCount;
        }

        // 区间重合处理
        private void Helper(int start, int end, List<int[]> list, int i)
        {
            int[][] areaArr;

            if (start > list[i][0])
            {
                areaArr = new[]
                {
                    new[] {list[i][0], start, list[i][2]},
                    new[] {start, end, list[i][2] + 1},
                    new[] {end, list[i][1], list[i][2]},
                };
            }
            else
            {
                areaArr = new[]
                {
                    new[] {start, list[i][0], 1},
                    new[] {list[i][0], end, list[i][2] + 1},
                    new[] {end, list[i][1], list[i][2]},
                };
            }

            _maxCount = Math.Max(list[i][2] + 1, _maxCount);

            list.RemoveAt(i);// 移除原有区间

            for (int j = 0; j < areaArr.Length; j++)
            {
                // 值相同->略过。
                if (areaArr[j][0] == areaArr[j][1]) continue; 
                list.Insert(i++, areaArr[j]);
            }
        }

        #region test

        public void Test()
        {
            Console.WriteLine(Book(10, 20)); // returns 1
            Console.WriteLine(Book(50, 60)); // returns 1
            Console.WriteLine(Book(10, 40)); // returns 2
            Console.WriteLine(Book(5, 15)); // returns 3
            Console.WriteLine(Book(5, 10)); // returns 3
            Console.WriteLine(Book(25, 55)); // returns 3
        }

        #endregion
    }
}