using Command.Attr;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020.October.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/26/2020 3:22:22 PM
    /// @source : https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3508/
    /// @des : 
    /// </summary>
    [Optimize]
    public class Champagne_Tower
    {


        public double Optimize(int poured, int query_row, int query_glass)
        {
            if (query_glass > query_row + 1) return 0;
            if (query_row == 0) return Math.Min(poured, 1);
            ISet<(int, int)> set = new HashSet<(int, int)>();

            Help(set, query_row, query_glass);

            double[] cache = new double[] { poured };

            while (cache.Length <= query_row)
            {
                double[] newCache = new double[cache.Length + 1];

                bool skip = true;// 跳过机制.
                for (int i = 0; i < cache.Length; i++)// 一行一行扫描
                {
                    if (cache[i] > 1 && set.Contains((cache.Length - 1, i)))// 仅计算会经过的点. 和有意义的点.
                    {
                        skip = false;
                        double emp = (cache[i] - 1) / 2;
                        newCache[i] += emp;
                        newCache[i + 1] += emp;
                    }
                }
                if (skip)
                {
                    return 0;
                }
                cache = newCache;

            }
            return Math.Min(cache[query_glass], 1);
        }

        public void Think(int poured)
        {
            List<double[]> list = new List<double[]>() { new double[1] };
            Help(list, poured, 0, 0);

            ShowTools.ShowMatrix(list);

        }

        private void Help(List<double[]> list, double poured, int deep, int index)
        {
            if (poured <= 0) return;
            if (list.Count == deep)
            {
                list.Add(new double[list[list.Count - 1].Length + 1]);
            }

            var diff = 1 - list[deep][index];

            if (diff >= poured)
            {
                list[deep][index] += poured;
                return;
            }
            else
            {
                list[deep][index] = 1;
                poured -= diff;
                var mid = poured / 2;
                Help(list, mid, deep + 1, index);
                Help(list, mid, deep + 1, index + 1);
            }

        }

        // 312 / 312 test cases passed.
        // Status: Accepted
        // Runtime: 68 ms
        // Memory Usage: 24.8 MB
        // faster than 30.00% 
        // 还真就过了... 就神奇,
        public double Simple(int poured, int query_row, int query_glass)
        {
            if (query_glass > query_row + 1) return 0;
            if (query_row == 0) return Math.Min(poured, 1);
            ISet<(int, int)> set = new HashSet<(int, int)>();

            Help(set, query_row, query_glass);

            double[] cache = new double[] { poured };

            while (cache.Length <= query_row)
            {
                double[] newCache = new double[cache.Length + 1];

                bool skip = true;// 跳过机制.
                for (int i = 0; i < cache.Length; i++)// 一行一行扫描
                {
                    if (cache[i] > 1 && set.Contains((cache.Length - 1, i)))// 仅计算会经过的点. 和有意义的点.
                    {
                        skip = false;
                        double emp = (cache[i] - 1) / 2;
                        newCache[i] += emp;
                        newCache[i + 1] += emp;
                    }
                }
                if (skip)
                {
                    return 0;
                }
                cache = newCache;

            }
            return Math.Min(cache[query_glass], 1);

            //return default;

            //List<double[]> list = new List<double[]>() { new double[1] };
            //Help(set, list, poured, 0, 0);
            //return list[query_row][query_glass];
        }

        // 获取可能经过的所有节点
        private void Help(ISet<(int, int)> set, int row, int col)
        {
            var newItem = (row, col);
            if (set.Contains(newItem)) return;
            set.Add(newItem);
            if (row == 0) return;
            int left = Math.Min(col, row - 1), right = Math.Max(0, col - 1);

            Help(set, row - 1, right);
            if (left != right)
            {
                Help(set, row - 1, left);
            }

        }

        // to solw 
        // 递归次数太多.
        private void Help(ISet<(int, int)> set, List<double[]> list, double poured, int deep, int index)
        {
            if (!set.Contains((deep, index))) return;
            if (poured <= 0) return;
            if (list.Count == deep)
            {
                list.Add(new double[deep + 1]);
            }

            var diff = 1 - list[deep][index];

            if (diff >= poured)
            {
                list[deep][index] += poured;
                return;
            }
            else
            {
                list[deep][index] = 1;
                poured -= diff;
                var mid = poured / 2;
                Help(set, list, mid, deep + 1, index);
                Help(set, list, mid, deep + 1, index + 1);
            }

        }

    }
}
