using Command.Attr;
using Command.Const;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/26/2021 4:13:55 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3721/
    /// @des : 
    /// 
    ///     给定一个整数数组高度，表示建筑物、一些砖块和一些梯子的高度。
    ///     你从建筑0开始，可能使用砖块或梯子移动到下一个建筑。 (梯子可以代替任意数量的砖块)
    ///     当从建筑i移动到建筑i+1(0索引)时，
    ///     如果当前建筑的高度大于或等于下一个建筑的高度，你不需要梯子或砖块。
    ///     如果当前建筑的高度低于下一个建筑的高度，你可以使用一个梯子或(h[i + 1] - h[i])砖块。
    ///     返回最远的建筑索引(0索引)，如果你使用给定的梯子和砖块。
    /// 
    /// </summary>
    [Favorite(FlagConst.Special, "类似game")]
    public class Furthest_Building_You_Can_Reach
    {

        // 1 <= heights.length <= 10^5
        //1 <= heights[i] <= 10^6
        //0 <= bricks <= 10^9
        //0 <= ladders <= heights.length

        // Runtime: 300 ms
        // Memory Usage: 44.7 MB
        // Your runtime beats 64.71 %
        public int Try2(int[] heights, int bricks, int ladders)
        {
            int prevH = heights[0];
            IList<int> useRecord = new List<int>(ladders);
            for (int i = 1; i < heights.Length; i++)
            {
                var h = heights[i];

                if (prevH < h)
                {
                    var diff = h - prevH;
                    if (ladders > 0)
                    {
                        ladders--;
                        AddOne(diff);
                    }
                    else if (useRecord.Count == 0)
                    {
                        if (bricks < diff)
                        {
                            return i - 1;
                        }
                        bricks -= diff;
                    }
                    else
                    {
                        var min = useRecord[0];
                        if (diff <= min)
                        {
                            if (bricks < diff)
                            {
                                return i - 1;
                            }
                            bricks -= diff;
                        }
                        else
                        {
                            if (bricks < min)
                            {
                                return i - 1;
                            }
                            bricks -= min;
                            useRecord.RemoveAt(0);
                            AddOne(diff);
                        }
                    }
                }
                prevH = h;

            }

            return heights.Length - 1;

            void AddOne(int target)
            {
                if (useRecord.Count == 0)
                {
                    useRecord.Add(target);
                    return;
                }

                int len = useRecord.Count, left = 0, right = len - 1;

                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    var num = useRecord[mid];
                    if (num == target)
                    {
                        useRecord.Insert(mid, target);
                        return;
                    }
                    if (num > target) right = mid - 1;
                    else left = mid + 1;
                }

                useRecord.Insert(left, target);
            }

        }

        // time limit
        public int Try(int[] heights, int bricks, int ladders)
        {
            int prevH = heights[0];
            IList<int> useRecord = new List<int>();
            for (int i = 1; i < heights.Length; i++)
            {
                var h = heights[i];

                if (prevH < h)
                {
                    var diff = h - prevH;
                    if (ladders > 0) // 先将梯子用完
                    {
                        ladders--;
                        useRecord.Add(diff);
                    }
                    else if (useRecord.Count == 0)
                    {
                        if (bricks < diff) return i - 1;
                        bricks -= diff;
                    }
                    else
                    {
                        var min = useRecord.Min();// 取出一个最钻的梯子
                        if (diff <= min) // 当前高度比最矮的梯子还矮 ==> 直接用砖块
                        {
                            if (bricks < diff) return i - 1;
                            bricks -= diff;
                        }
                        else // 用同等的砖块替换出一个梯子，再用这个梯子升到diff,爬上此楼层
                        {
                            if (bricks < min) return i - 1;
                            bricks -= min;
                            useRecord.Remove(min);
                            useRecord.Add(diff);
                        }
                    }
                }
                prevH = h;

            }

            return heights.Length - 1;

        }

        // slow slow.... 3000 years later
        public int Simple(int[] heights, int bricks, int ladders)
        {
            return Help(1, bricks, ladders);
            int Help(int i, int bricks, int ladders)
            {
                if (i == heights.Length) return i - 1;
                var diff = heights[i] - heights[i - 1];
                if (diff < 1)
                {
                    return Help(i + 1, bricks, ladders);
                }
                if (ladders == 0)
                {
                    if (bricks >= diff)
                    {
                        return Help(i + 1, bricks - diff, ladders);
                    }
                    return i - 1;
                }

                if (bricks >= diff)
                {
                    return Math.Min(Help(i + 1, bricks - diff, ladders), Help(i + 1, bricks, ladders - 1));
                }
                else
                {
                    return Help(i + 1, bricks, ladders - 1);
                }

            }
        }

        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int prevH = heights[0];
            IList<int> useRecord = new List<int>();
            for (int i = 1; i < heights.Length; i++)
            {
                var h = heights[i];

                if (prevH < h)
                {
                    var diff = h - prevH;
                    if (bricks >= diff)
                    {
                        bricks -= diff;
                        useRecord.Add(diff);
                    }
                    else if (ladders == 0)
                    {
                        return i - 1;
                    }
                    else
                    {
                        if (useRecord.Count == 0)
                        {
                            ladders--;
                        }
                        else
                        {
                            ladders--;
                            var max = useRecord.Max();
                            if (max > diff)
                            {
                                bricks += max - diff;
                                useRecord.Remove(max); // bug : 替代后后面的可能不需要补充
                            }
                        }
                    }
                }
                prevH = h;

            }

            return heights.Length - 1;

        }




    }
}
