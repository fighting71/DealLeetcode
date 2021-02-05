using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{

    public static class EmptyExt
    {
        public static void AddRange2(this List<char> list, List<char> collection)
        {
            if (collection == null) return;
            list.AddRange(collection);
        }
    }

    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 3:52:31 PM
    /// @source : https://leetcode.com/problems/strange-printer/
    /// @des : 
    ///     又是一道像是祖玛的游戏...
    ///     有一台奇怪的打印机，有以下两个特殊要求:
    ///     打印机每次只能打印相同字符的序列。
    ///     在每一个回合，打印机可以打印新的字符开始和结束在任何地方，并将覆盖原有的字符。
    ///     给定一个只包含较低的英文字母的字符串，你的工作是数一数打印机打印它所需的最少次数。
    /// </summary>
    public class Strange_Printer
    {

        // Hint: Length of the given string will not exceed 100.

        #region 不玩了.. 先入为主了
        class Item
        {
            public char Box { get; set; }
            /// <summary>
            /// 当前有{count}个{Box}颜色的盒子连在一起
            /// </summary>
            public int Count { get; set; }
        }
        public int Try2(string s)
        {
            Dictionary<int, List<int>> indexDic = new Dictionary<int, List<int>>();
            #region format board
            List<Item> list = new List<Item>();
            Item prev = default;

            foreach (var box in s)
            {
                if (prev != default && prev.Box == box) prev.Count++;
                else
                {
                    if (indexDic.ContainsKey(box))
                        indexDic[box].Add(list.Count);
                    else
                        indexDic[box] = new List<int>() { list.Count };
                    list.Add(prev = new Item { Box = box, Count = 1 });
                }
            }
            #endregion

            int len = list.Count;

            int[][] dp = new int[len][];
            List<char>[][] charDp = new List<char>[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                var count = list[i].Count;
                dp[i][i] = count * count;
                charDp[i] = new List<char>[len];
                charDp[i][i] = new List<char>(list[i].Box);
            }

            for (int k = 1; k < len; k++)
            {
                for (int left = 0; left < len - k; left++)
                {
                    int right = left + k;

                    Item leftItem = list[left], rightItem = list[right];

                    List<char> currList = new List<char>();
                    currList.Add(leftItem.Box);
                    currList.Add(rightItem.Box);
                    currList.AddRange2(charDp[left + 1][right - 1]);
                    int max = dp[left][left] + dp[right][right] + dp[left + 1][right - 1],prevMax = max;
                    max = Math.Max(dp[left][left] + dp[left + 1][right], max);
                    if(max > prevMax)
                    {
                        currList.Clear();
                        currList.Add(leftItem.Box);
                        currList.AddRange2(charDp[left + 1][right]);
                        prevMax = max;
                    }
                    max = Math.Max(dp[right][right] + dp[left][right - 1], max);
                    if (max > prevMax)
                    {
                        currList.Clear();
                        currList.Add(rightItem.Box);
                        currList.AddRange2(charDp[left][right - 1]);
                        prevMax = max;
                    }

                    if (leftItem.Box == rightItem.Box)
                    {
                        int count = leftItem.Count + rightItem.Count;
                        max = Math.Max(count * count + dp[left + 1][right - 1], max);
                        if (max > prevMax)
                        {
                            currList.Clear();
                            currList.Add(rightItem.Box);
                            currList.AddRange2(charDp[left + 1][right - 1]);
                            prevMax = max;
                        }
                        int empty = 0;
                        IEnumerable<int> enumerable = indexDic[leftItem.Box].Where(u => u > left && u < right);
                        int prevLeft = left;
                        List<char> emptyList = new List<char>();
                        foreach (var item in enumerable)
                        {
                            var mid = list[item];

                            count += mid.Count;

                            empty += dp[prevLeft + 1][item - 1];
                            emptyList.AddRange2(charDp[prevLeft + 1][item - 1]);

                            max = Math.Max(max, empty + count * count + dp[item + 1][right - 1]);
                            if (max > prevMax)
                            {
                                currList.Clear();
                                currList.Add(leftItem.Box);
                                currList.AddRange2(emptyList);
                                emptyList.AddRange2(charDp[item + 1][right - 1]);
                                prevMax = max;
                            }
                            prevLeft = item;

                        }
                    }
                    else
                    {
                        {
                            int count = leftItem.Count;

                            int empty = 0;
                            List<char> emptyList = new List<char>();
                            IEnumerable<int> enumerable = indexDic[leftItem.Box].Where(u => u > left && u < right);
                            int prevLeft = left;
                            foreach (var item in enumerable)
                            {
                                var mid = list[item];

                                count += mid.Count;

                                empty += dp[prevLeft + 1][item - 1];
                                emptyList.AddRange2(charDp[prevLeft + 1][item - 1]);

                                max = Math.Max(max, empty + count * count + dp[item + 1][right]);
                                if (max > prevMax)
                                {
                                    currList.Clear();
                                    currList.Add(leftItem.Box);
                                    currList.AddRange2(emptyList);
                                    emptyList.AddRange2(charDp[item + 1][right]);
                                    prevMax = max;
                                }
                                prevLeft = item;

                            }
                        }
                        {
                            int count = rightItem.Count;

                            int empty = 0;
                            List<char> emptyList = new List<char>();
                            IEnumerable<int> enumerable = indexDic[rightItem.Box].Where(u => u > left && u < right);
                            int prevLeft = left;
                            foreach (var item in enumerable)
                            {
                                var mid = list[item];

                                count += mid.Count;

                                empty += dp[prevLeft][item - 1];
                                emptyList.AddRange2(charDp[prevLeft][item - 1]);

                                max = Math.Max(max, empty + count * count + dp[item + 1][right - 1]);
                                if (max > prevMax)
                                {
                                    currList.Clear();
                                    currList.Add(rightItem.Box);
                                    currList.AddRange2(emptyList);
                                    emptyList.AddRange2(charDp[item + 1][right - 1]);
                                    prevMax = max;
                                }
                                prevLeft = item + 1;

                            }
                        }
                    }

                    dp[left][right] = max;
                    charDp[left][right] = currList;
                }
            }

            return list.Count - charDp[0][len - 1].Count;

        }

        public int Try(string s)
        {
            Dictionary<int, List<int>> indexDic = new Dictionary<int, List<int>>();
            #region format board
            List<char> list = new List<char>();
            char prev = default;

            foreach (var c in s)
            {
                if (prev != default && prev == c) continue;
                else
                {
                    if (indexDic.ContainsKey(c))
                        indexDic[c].Add(list.Count);
                    else
                        indexDic[c] = new List<int>() { list.Count };
                    list.Add(prev = c);
                }
            }
            #endregion

            int len = list.Count;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                dp[i][i] = 1;
            }

            for (int k = 1; k < len; k++)
            {
                for (int left = 0; left < len - k; left++)
                {
                    int right = left + k;
                    char leftItem = list[left], rightItem = list[right];
                    int min = Math.Min(1 + dp[left + 1][right], 1 + dp[left][right - 1]);

                    if(leftItem == rightItem)
                    {
                        min = Math.Min(1 + dp[left + 1][right - 1], min);

                        IEnumerable<int> enumerable = indexDic[leftItem].Where(u => u > left && u < right);

                        foreach (var item in enumerable)
                        {
                            min = Math.Min(min, 1 + dp[left + 1][item - 1] + dp[item + 1][right - 1]);
                        }
                    }
                    else
                    {
                        min = Math.Min(2 + dp[left + 1][right - 1], min);
                        {

                            IEnumerable<int> enumerable = indexDic[leftItem].Where(u => u > left && u < right);
                            foreach (var item in enumerable)
                            {
                                min = Math.Min(min, 1 + dp[left + 1][item - 1] + dp[item + 1][right - 1]);
                            }
                        }
                        {

                            IEnumerable<int> enumerable = indexDic[rightItem].Where(u => u > left && u < right);
                            foreach (var item in enumerable)
                            {
                                min = Math.Min(min, 1 + dp[left + 1][item - 1] + dp[item + 1][right - 1]);
                            }
                        }
                    }

                    dp[left][right] = min;

                }
            }

            return dp[0][len - 1];

        }
        #endregion

        public int Simple(string s)
        {
            return Helper(s.ToList());
        }

        private int Helper(List<char> list)
        {
            int res = list.Count;
            int curr = 0;
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var box = list[i];
                if (box == curr)
                {
                    count++;
                }
                else
                {
                    curr = box;
                    count = 1;
                }

                List<char> clone = new List<char>(list);

                for (int j = 0; j < count; j++)
                {
                    clone.RemoveAt(i - j);
                }
                res = Math.Min(res, 1 + Helper(clone));

            }
            return res;
        }

    }
}
