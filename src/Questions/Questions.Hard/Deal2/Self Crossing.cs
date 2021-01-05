using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/16/2020 6:13:17 PM
    /// @source : https://leetcode.com/problems/self-crossing/
    /// @des : 贪吃蛇判断是否吃到自己尾巴/duzi/tou...【bt版(啥位置都eat)】可以移动0... 和反向移动
    ///     无边界就很烦》
    /// </summary>
    [Obsolete("告辞")]
    public class Self_Crossing
    {

        private enum Direction
        {
            Top = 0,
            Right = 1,
            Bottom = 2,
            Left = 3
        }

        public const int Top = 0;
        public const int Right = 1;
        public const int Bottom = 2;
        public const int Left = 3;

        #region try2
        // 计算每次移动所必须的长度
        public bool Try2(int[] moveArr)
        {
            int x = 0, y = 0;
            int direction = 0;

            foreach (var move in moveArr)
            {
                if(move != 0)
                {
                    if(direction == Top)
                    {

                    }
                    else if(direction == Bottom)
                    {

                    }
                    else if (direction == Left)
                    {

                    }
                    else if (direction == Right)
                    {

                    }
                }
                direction = ++direction % 4;
            }

            return true;
        }
        #endregion

        #region try
        public bool Try(int[] moveArr)
        {

            int direction = 0;

            Dictionary<int, (int, int)> xLine = new Dictionary<int, (int, int)>();
            Dictionary<int, (int, int)> yLine = new Dictionary<int, (int, int)>();

            int x = 0, y = 0,nextX,nextY;
            foreach (var move in moveArr)
            {
                if(move != 0)
                {
                    if(direction == Top)
                    {
                        nextX = x;
                        nextY = y + move;
                    } 
                    else if(direction == Bottom)
                    {
                        nextX = x;
                        nextY = y - move;
                    }
                    else if(direction == Left)
                    {
                        nextX = x - move;
                        nextY = y;
                    }
                    else
                    {
                        nextX = x + move;
                        nextY = y;
                    }
                }
                direction =  (++direction) % 4;
            }

            return true;
        }
        #endregion

        // ↑←↓→
        // [2147483647,0,0,2,2147483647] 允许 还要考虑越界...

        /*
         * 2d平面的检测是否相连
         * 
         * thinking 1 :
         * 
         * 保留每一条线段,每次移动时判断有没有碰到之前的线段
         * O(1+2+..+n)  
         * 
         * thinking 2 :
         * 根据x,y保存一个map,通过map降低查询路径
         * ==>占用空间过多，当移动距离过长时会出现大量的不必要的空间(例如一下移动int.MaxValue map(x) 或 map(y) 直接爆炸),==>ex_out_of_memory
         * 
         */

        private int _x;
        private int _y;

        private bool ToTop(int[] x,int index)
        {
            if (index == x.Length) return true;
            if (x[index++] != 0)
            {

            }
            return ToLeft(x, index);
        }
        private bool ToLeft(int[] x, int index)
        {
            if (index == x.Length) return true;
            if (x[index++] != 0)
            {

            }
            return ToBottom(x, index);
        }
        private bool ToBottom(int[] x, int index)
        {
            if (index == x.Length) return true;
            if (x[index++] != 0)
            {

            }
            return ToRight(x, index);
        }
        private bool ToRight(int[] x, int index)
        {
            if (index == x.Length) return true;
            if (x[index++] != 0)
            {

            }
            return ToTop(x, index);
        }

    }
}
