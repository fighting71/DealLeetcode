using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/2/2021 3:52:37 PM
    /// @source : https://leetcode.com/problems/remove-boxes/
    /// @des : 
    /// 给你几个不同颜色的盒子，用不同的正数表示。
    /// 你可能会经历几轮移除盒子直到没有盒子留下。每次你可以选择一些连续的相同颜色的盒子(即k个盒子组成的盒子，k &gt;= 1)，移除它们，得到k* k分。
    /// 返回你能得到的最大分数。
    /// </summary>
    [Favorite(FlagConst.DP, FlagConst.Complex)]
    public class Remove_Boxes
    {

        // 1 <= boxes.length <= 100
        // 1 <= boxes[i] <= 100


        public int Explain(int[] boxes)
        {
            // box -> index_list
            // 方便查找box颜色的盒子
            Dictionary<int, List<int>> indexDic = new Dictionary<int, List<int>>();

            #region format board
            // boxes缩进  111->(1,3)
            List<Item> list = new List<Item>();
            Item prev = default;

            foreach (var box in boxes)
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

            // 此题和戳气球类型，一看就是典型的动态规划,可参见Burst_Balloons
            // dp[i][j] i,j -> 下标 = 可获取的最大分数
            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                var count = list[i].Count;
                // 初始值 当前项可获分数 = count * count
                dp[i][i] = count * count;
            }

            for (int k = 1; k < len; k++) // k 表示长度 从2开始(1已经直接计算了)
            {
                for (int left = 0; left < len - k; left++)
                {
                    int right = left + k;

                    // 获取left , right 项
                    Item leftItem = list[left], rightItem = list[right];

                    // left -> l right -> r
                    // max  = [left,left] + [r,r] + [l + 1][r - 1](中间部分)
                    int max = dp[left][left] + dp[right][right] + dp[left + 1][right - 1];
                    // [l,l] + [l + 1, r]
                    max = Math.Max(dp[left][left] + dp[left + 1][right], max);
                    // [r, r] + [l, r - 1]
                    max = Math.Max(dp[right][right] + dp[left][right - 1], max);

                    if (leftItem.Box == rightItem.Box) // 若l,r相同
                    {
                        // 直接叠加
                        int count = leftItem.Count + rightItem.Count;
                        // 不考虑中间部分  [l + 1, r - 1] + count^2
                        max = Math.Max(count * count + dp[left + 1][right - 1], max);

                        int empty = 0;
                        IEnumerable<int> enumerable = indexDic[leftItem.Box].Where(u => u > left && u < right);
                        int prevLeft = left;
                        // 遍历中间部分，(仅考虑匹配项，故使用indexDic即可)
                        foreach (var item in enumerable)
                        {
                            var mid = list[item];

                            count += mid.Count;
                            // 缝隙 -> 中间部分
                            // 每次保留中间的缝隙，因为后面部分会使用之前的部分作为计算
                            empty += dp[prevLeft + 1][item - 1];

                            // 缝隙 + 叠加^2 + 最后的一个缝隙
                            max = Math.Max(max, empty + count * count + dp[item + 1][right - 1]);

                            prevLeft = item;

                        }
                    }
                    else // 若不相同
                    {
                        // 则需要考虑2种情况：
                        { // 1.用left的box去匹配中间部分
                            int count = leftItem.Count;

                            int empty = 0;
                            IEnumerable<int> enumerable = indexDic[leftItem.Box].Where(u => u > left && u < right);
                            int prevLeft = left;
                            foreach (var item in enumerable)
                            {
                                var mid = list[item];

                                count += mid.Count;

                                empty += dp[prevLeft + 1][item - 1];

                                max = Math.Max(max, empty + count * count + dp[item + 1][right]);

                                prevLeft = item;

                            }
                        }
                        { // 2.用right的box去匹配中间部分
                            int count = rightItem.Count;

                            int empty = 0;
                            IEnumerable<int> enumerable = indexDic[rightItem.Box].Where(u => u > left && u < right);
                            int prevLeft = left;
                            foreach (var item in enumerable)
                            {
                                var mid = list[item];

                                count += mid.Count;

                                empty += dp[prevLeft][item - 1];

                                max = Math.Max(max, empty + count * count + dp[item + 1][right - 1]);

                                prevLeft = item + 1;

                            }
                        }
                    }

                    dp[left][right] = max;
                }
            }

            return dp[0][len - 1];

        }

        // Runtime: 120 ms, faster than 100.00% of C# online submissions for Remove Boxes.
        // Memory Usage: 28.5 MB, less than 100.00% of C# online submissions for Remove Boxes.
        // 愛了愛了
        public int Try3(int[] boxes)
        {
            Dictionary<int, List<int>> indexDic = new Dictionary<int, List<int>>();
            #region format board
            List<Item> list = new List<Item>();
            Item prev = default;

            foreach (var box in boxes)
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

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
                var count = list[i].Count;
                dp[i][i] = count * count;
            }

            for (int k = 1; k < len; k++)
            {
                for (int left = 0; left < len - k; left++)
                {
                    int right = left + k;

                    Item leftItem = list[left], rightItem = list[right];

                    int max = dp[left][left] + dp[right][right] + dp[left + 1][right - 1];
                    max = Math.Max(dp[left][left] + dp[left + 1][right], max);
                    max = Math.Max(dp[right][right] + dp[left][right - 1], max);

                    if (leftItem.Box == rightItem.Box)
                    {
                        int count = leftItem.Count + rightItem.Count;
                        max = Math.Max(count * count + dp[left + 1][right - 1], max);

                        int empty = 0;
                        IEnumerable<int> enumerable = indexDic[leftItem.Box].Where(u => u > left && u < right);
                        int prevLeft = left;
                        foreach (var item in enumerable)
                        {
                            var mid = list[item];

                            count += mid.Count;

                            empty += dp[prevLeft + 1][item - 1];

                            max = Math.Max(max, empty + count * count + dp[item + 1][right - 1]);

                            prevLeft = item;

                        }
                    }
                    else
                    {
                        {
                            int count = leftItem.Count;

                            int empty = 0;
                            IEnumerable<int> enumerable = indexDic[leftItem.Box].Where(u => u > left && u < right);
                            int prevLeft = left;
                            foreach (var item in enumerable)
                            {
                                var mid = list[item];

                                count += mid.Count;

                                empty += dp[prevLeft + 1][item - 1];

                                max = Math.Max(max, empty + count * count + dp[item + 1][right]);

                                prevLeft = item;

                            }
                        }
                        {
                            int count = rightItem.Count;

                            int empty = 0;
                            IEnumerable<int> enumerable = indexDic[rightItem.Box].Where(u => u > left && u < right);
                            int prevLeft = left;
                            foreach (var item in enumerable)
                            {
                                var mid = list[item];

                                count += mid.Count;

                                empty += dp[prevLeft][item - 1];

                                max = Math.Max(max, empty + count * count + dp[item + 1][right - 1]);

                                prevLeft = item + 1;

                            }
                        }
                    }

                    dp[left][right] = max;
                }
            }

            return dp[0][len - 1];

        }

        class Item
        {
            /// <summary>
            /// Box颜色
            /// </summary>
            public int Box { get; set; }
            /// <summary>
            /// 当前有{count}个{Box}颜色的盒子连在一起
            /// </summary>
            public int Count { get; set; }
        }

        // time limit
        public int Try2(int[] boxes)
        {
            #region format board
            List<Item> list = new List<Item>();
            Item prev = default;

            foreach (var box in boxes)
            {
                if (prev != default && prev.Box == box) prev.Count++;
                else list.Add(prev = new Item { Box = box, Count = 1 });
            }
            #endregion

            int res = 0;
            Helper(list, 0, 0);
            return res;

            void Helper(List<Item> list, int i, int score)
            {
                if (i == list.Count)
                {
                    res = Math.Max(score, res);
                    return;
                }

                // clone list
                var clone = new List<Item>(list.Count);

                foreach (var item in list)
                    clone.Add(new Item { Box = item.Box, Count = item.Count });

                ReduceList(clone, i, score);

                Helper(list, i + 1, score);

            }

            void ReduceList(List<Item> list, int i, int score)
            {
                int count = list[i].Count;
                score += count * count;
                list.RemoveAt(i);

                if (list.Count == 0)
                {
                    res = Math.Max(score, res);
                    return;
                }

                while (true)
                {
                    if (i >= list.Count || i - 1 < 0) break;

                    var curr = list[i];
                    var prev = list[i - 1];
                    if (curr.Box != prev.Box) break;

                    prev.Count += curr.Count;
                    list.RemoveAt(i--);

                    Helper(list, i, score);

                    count = list[i].Count;

                    score += count * count;

                    list.RemoveAt(i);

                }

                Helper(list, i, score);
            }
        }

        // bug.
        public int Try(int[] boxes)
        {
            int len = boxes.Length;

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

                    int leftNum = boxes[left], rightNum = boxes[right];
                    bool isSame = leftNum == rightNum;
                    if (isSame && dp[left + 1][right] == k * k)
                    {
                        dp[left][right] = (k + 1) * (k + 1);
                        continue;
                    }

                    int sameLeft = 1, sameRight = 1;
                    for (int i = left + 1; i < right; i++)
                    {
                        if (boxes[i] != leftNum) break;
                        sameLeft++;
                    }

                    for (int i = right - 1; i > left; i--)
                    {
                        if (boxes[i] != rightNum) break;
                        sameRight++;
                    }

                    int max;

                    if (isSame)
                    {
                        var count = sameLeft + sameRight;
                        max = count * count + dp[left + sameLeft][right - sameRight];
                    }
                    else
                    {
                        max = sameRight * sameRight + sameLeft * sameLeft + dp[left + sameLeft][right - sameRight];
                    }

                    max = Math.Max(sameRight * sameRight + dp[left][right - sameRight], max);
                    max = Math.Max(sameLeft * sameLeft + dp[left + sameLeft][right], max);
                    dp[left][right] = max;
                }
            }

            foreach (var item in dp)
            {
                Console.WriteLine(string.Join(",", item));
            }

            return dp[0][len - 1];

        }


        public int Simple(int[] boxes)
        {
            return Helper(boxes.ToList());
        }

        private int Helper(List<int> boxes)
        {
            int res = 0;
            int curr = 0;
            int count = 0;
            for (int i = 0; i < boxes.Count; i++)
            {
                var box = boxes[i];
                if (box == curr)
                {
                    count++;
                }
                else
                {
                    curr = box;
                    count = 1;
                }

                List<int> clone = new List<int>(boxes);

                for (int j = 0; j < count; j++)
                {
                    clone.RemoveAt(i - j);
                    res = Math.Max(res, count * count + Helper(clone));
                }

            }
            return Math.Max(res, boxes.Count);
        }

    }
}
