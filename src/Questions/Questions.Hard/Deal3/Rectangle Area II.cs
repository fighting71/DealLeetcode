using Command.Attr;
using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/24/2021 12:01:55 PM
    /// @source : https://leetcode.com/problems/rectangle-area-ii/
    /// @des : 
    /// 
    ///     我们得到了一个(轴对齐的)矩形列表。每个矩形[i] = [xi1, yi1, xi2, yi2]，其中(xi1, yi1)为左下角的坐标，(xi2, yi2)为第i个矩形的右上角的坐标。
    ///     求平面上所有矩形所覆盖的总面积。因为答案可能太大了，用109 + 7取模返回它。
    /// 
    /// </summary>
    [Favorite(FlagConst.Matrix, FlagConst.AreaSum)]
    public class Rectangle_Area_II
    {

        //1 <= rectangles.length <= 200
        //rectanges[i].length = 4
        //0 <= rectangles[i][j] <= 10^9
        //The total area covered by all rectangles will never exceed 2^63 - 1 and thus will fit in a 64-bit signed integer.

        // rectanges[i] = { xi1, yi1, xi2, yi2 }

        const int Mod = 1000_000_007;

        // Runtime: 92 ms, faster than 100.00% of C# online submissions for Rectangle Area II.
        // Memory Usage: 26.2 MB, less than 44.44% of C# online submissions for Rectangle Area II.
        // alal
        // 重合情况见 images/矩阵重合示例图
        // 思路概况 ： 遍历所有矩阵，将当前矩阵与其他矩阵进行去除重复面积处理   再将不重合部分面积计入总和
        /**
         * step: 
         * 
         *      1. 将所有矩形按照xi1进行排序 （简化条件判断）
         *      
         *      2. 遍历矩形  i = 0 -> rectangles.Length
         *          
         *          curr = rectangles[i]
         *          
         *          (stack 表示 当前不重合的所有矩形，next 表示下次遍历的stack)
         *          stack = new Stack(){ curr }, next = new Stack();
         *          
         *          2.1 遍历之前的矩形  j = 0 -> i -1 
         *              
         *              prev = rectangles[i]
         * 
         *              2.1.1 遍历stack  rect = stack.Pop()
         *              
         *                  对比 rect 与 prev
         *                  
         *                  if prev 与 rect没有重合部分
         *                      将rect 放入 next 用于下次遍历
         *                  
         *                  else if prev 完全包含 rect 
         *                      直接跳过
         *                     
         *                  else 根据重合情况添加 不重合的部分到next
         *              
         *              交换stack与next 用于下次遍历
         *      
         *          2.2 遍历不重合的矩形，将面积和算入res
         * 
         */

        public int RectangleArea(int[][] rectangles)
        {
            int len = rectangles.Length;

            long res = 0;

            rectangles = rectangles.OrderBy(u => u[0]).ToArray();

            for (int i = 0; i < len; i++)
            {

                var curr = rectangles[i];

                Stack<int[]> stack = new Stack<int[]>(), next = new Stack<int[]>();

                stack.Push(curr);

                for (int j = i - 1; j >= 0; j--)
                {
                    var prev = rectangles[j];

                    while (stack.Count > 0)
                    {
                        int[] rect = stack.Pop();

                        if(prev[2] <= rect[0] || prev[1] >= rect[3] || prev[3] <= rect[1])
                        {
                            next.Push(rect);
                            continue;
                        }
                        if (prev[2] >= rect[2] && prev[1] <= rect[1] && prev[3] >= rect[3])
                        {
                            continue;
                        }

                        if(prev[2] >= rect[2])
                        {

                            if(prev[1] >= rect[1])
                            {
                                if (prev[3] >= rect[3])
                                {
                                    next.Push(new[] { rect[0], rect[1], rect[2], prev[1] });
                                }
                                else
                                {
                                    next.Push(new[] { rect[0], rect[1], rect[2], prev[1] });
                                    next.Push(new[] { rect[0], prev[3], rect[2], rect[3] });
                                }
                            }
                            else
                            {
                                next.Push(new[] { rect[0], prev[3], rect[2], rect[3] });
                            }
                        }
                        else
                        {
                            if (prev[1] <= rect[1] && prev[3] >= rect[3])
                            {
                                next.Push(new[] { prev[2], rect[1], rect[2], rect[3] });
                            }
                            else if (prev[1] >= rect[1])
                            {
                                if (prev[3] >= rect[3])
                                {
                                    next.Push(new[] { rect[0], rect[1], prev[2], prev[1] });
                                    next.Push(new[] { prev[2], rect[1], rect[2], rect[3] });
                                }
                                else
                                {
                                    next.Push(new[] { rect[0], rect[1], prev[2], prev[1] });
                                    next.Push(new[] { prev[2], rect[1], rect[2], rect[3] });
                                    next.Push(new[] { rect[0], prev[3], prev[2], rect[3] });
                                }
                            }
                            else
                            {
                                next.Push(new[] { rect[0], prev[3], prev[2], rect[3] });
                                next.Push(new[] { prev[2], rect[1], rect[2], rect[3] });
                            }
                        }

                    }
                    var t = stack;
                    stack = next;
                    next = t;

                }

                while (stack.Count > 0)
                {
                    int[] area = stack.Pop();
                    res += Math.Abs((area[2] - area[0]) * (long)(area[3] - area[1]));
                }

            }

            return (int)(res % Mod);
        }

    }
}
