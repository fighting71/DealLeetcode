using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;
using Command.Tools;
using Newtonsoft.Json;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/22 16:15:35
    /// @source : https://leetcode.com/problems/n-queens-ii/
    ///     https://leetcode.com/problems/n-queens/ 内容差不多... 结果输出要求不一样
    /// @des : 
    /// </summary>
    [Level(Command.Menu.LevelTypes.Hard)]
    public class TotalNQueens
    {
        #region 测试参数

        private int[][] martix;
        private int index;

        #endregion

        private static int res;

        #region first try

        /**
         * Runtime: 44 ms, faster than 64.17% of C# online submissions for N-Queens II.
         * Memory Usage: 16.5 MB, less than 100.00% of C# online submissions for N-Queens II.
         * 
         * Runtime: 40 ms, faster than 90.42% of C# online submissions for N-Queens II.
         * Memory Usage: 14.1 MB, less than 100.00% of C# online submissions for N-Queens II.
         * 
         */
        public int SimpleSolution(int n)
        {
            // 重置结果值
            res = 0;

            // 测试
//            martix = new int[n][];
//            for (int i = 0; i < n; i++)
//            {
//                martix[i] = new int[n];
//            }

            // error 理解错误
            // Helper(-2, n, new bool[n], n);

            // 用于检查位置可用性
            bool[][] exists = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                exists[i] = new bool[n];
            }

            Helper(n, exists, n);

            return res;
        }

        private void Helper(int n, bool[][] exists, int num)
        {
            if (num == 0) // 所有位置都被占用时 ==> 成功放置
            {
                // test
                // ListTools.ShowMartix(martix);
                // Console.WriteLine("--------------------------------------");
                res++;
                return;
            }

            for (int j = 0; j < n; j++)
            {
                // 此位置不可用直接跳过
                if (exists[n - num][j]) continue;

                // 若可用则占用与此位置相关的位置
                // 创建list便于回退
                List<int[]> list = new List<int[]>();

                // 由于只关心在(n-num+1)之后的位置占用 则开始下标为n-num+1
                for (int i = n - num + 1; i < n; i++)
                {
                    // 同列占用 同行无意义
                    if (!exists[i][j])
                    {
                        list.Add(new[] {i, j});
                        exists[i][j] = true;
                    }

                    // \ 左下占用
                    var empty = j + i - (n - num);
                    if (empty >= 0 && empty < n && !(exists[i][empty]))
                    {
                        list.Add(new[] {i, empty});
                        exists[i][empty] = true;
                    }

                    // / 右下占用
                    empty = j - i + (n - num);
                    if (empty >= 0 && empty < n && !(exists[i][empty]))
                    {
                        list.Add(new[] {i, empty});
                        exists[i][empty] = true;
                    }
                }

                // test
                // Console.WriteLine("-----------------exists---S------------------");
                // Console.WriteLine($"j:{j} i:{n - num}");
                // ListTools.ShowMartix(exists);
                // Console.WriteLine("-----------------exists---E------------------");
                //martix[n - num][j] = 1;

                // 继续往下寻找可用
                Helper(n, exists, num - 1);
                //martix[n - num][j] = 0;

                // 占用回退
                foreach (var item in list)
                {
                    exists[item[0]][item[1]] = false;
                }
            }
        }

        // 题目有点坑 no two queens attack each other. 表示在上下对角线不会出现两个皇后...
        // 无考虑对角线 maybe
        [Obsolete("不符题意")]
        private void Helper(int i, int n, bool[] exists, int num)
        {
            if (num == 0)
            {
                res++;
                ListTools.ShowMartix(martix);
                Console.WriteLine("--------------------------------------");
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (exists[j] || j == i + 1 || j == i - 1) continue;
                exists[j] = true;
                martix[n - num][j] = 1;
                Helper(j, n, exists, num - 1);
                martix[n - num][j] = 0;
                exists[j] = false;
            }
        }

        #endregion

        #region plan B

        /**
         * Runtime: 40 ms, faster than 90.42% of C# online submissions for N-Queens II.
         * Memory Usage: 14.1 MB, less than 100.00% of C# online submissions for N-Queens II.
         * 
         * Runtime: 36 ms, faster than 98.75% of C# online submissions for N-Queens II.
         * Memory Usage: 14 MB, less than 100.00% of C# online submissions for N-Queens II.
         *
         * ok ~
         * 
         */
        public int Solution(int n)
        {
            res = 0;

            // 用于检查位置可用性
            bool[][] exists = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                exists[i] = new bool[n];
            }

            ClearHelper(n, exists, n);

            return res;
        }

        // 与Helper相似
        private void ClearHelper(int n, bool[][] exists, int num)
        {
            if (num == 0) // 所有位置都被占用时 ==> 成功放置
            {
                res++;
                return;
            }

            for (int j = 0; j < n; j++)
            {
                // 与1不同的是 1保存所有被占的位置(包含被影响到的占位)
                // b采取的是保存所有被占位置不记录影响占位
                // 然后遍历时查看 此位置的上方相关位置是否存在已被占 已被占则跳过选择.
                // 后续 optimize => 缓存查看结果 加快筛选~  
                bool flag = true;
                for (int i = 0; i < n - num; i++)
                {
                    if (exists[i][j])
                    {
                        flag = false;
                        break;
                    }

                    // \ 左下占用
                    var empty = j + i - (n - num);
                    if (empty >= 0 && empty < n && (exists[i][empty]))
                    {
                        flag = false;
                        break;
                    }

                    // / 右下占用
                    empty = j - i + (n - num);
                    if (empty >= 0 && empty < n && (exists[i][empty]))
                    {
                        flag = false;
                        break;
                    }
                }

                if (!flag) continue;

                exists[n - num][j] = true;
                ClearHelper(n, exists, num - 1);
                exists[n - num][j] = false;
            }
        }

        #endregion
    }
}