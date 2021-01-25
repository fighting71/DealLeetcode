using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/24/2021 12:02:36 PM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3614/
    /// @des : 
    /// </summary>
    public class Sort_the_Matrix_Diagonally
    {

        // m == mat.length
        // n == mat[i].length
        //1 <= m, n <= 100
        //1 <= mat[i][j] <= 100

        // Your runtime beats 86.36 % 
        public int[][] Simple(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            List<int> list = new List<int>(Math.Max(n, m));

            for (int i = m - 2; i >= 0; i--)
            {
                list.Clear();
                for (int j = 0, cloneI = i; j < n - i && cloneI < m; j++, cloneI++)
                {
                    list.Add(mat[cloneI][j]);
                }
                list.Sort();
                for (int j = 0, cloneI = i; j < n - i && cloneI < m; j++, cloneI++)
                {
                    mat[cloneI][j] = list[j];
                }
            }

            for (int j = 1; j < n - 1; j++)
            {
                list.Clear();
                for (int i = 0, cloneJ = j; i < m && cloneJ < n; i++, cloneJ++)
                {
                    list.Add(mat[i][cloneJ]);
                }
                list.Sort();
                for (int i = 0, cloneJ = j; i < m && cloneJ < n; i++, cloneJ++)
                {
                    mat[i][cloneJ] = list[i];
                }
            }

            return mat;
        }

        // 遍历每一行
        public int[][] Case(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;

            List<List<int>> list = new List<List<int>>();

            for (int i = m - 2; i >= 0; i--)
            {
                List<int> item = new List<int>();
                for (int j = 0, cloneI = i; j < m - i && cloneI < m; j++, cloneI++)
                {
                    item.Add(mat[cloneI][j]);
                }
                list.Add(item);
            }

            for (int j = 1; j < n - 1; j++)
            {
                List<int> item = new List<int>();
                for (int i = 0, cloneJ = j; i < m && cloneJ < n; i++, cloneJ++)
                {
                    item.Add(mat[i][cloneJ]);
                }
                list.Add(item);
            }

            ShowTools.Show(list);

            return mat;
        }
    }
}
