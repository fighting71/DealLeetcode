using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/5/2020 4:13:00 PM
    /// @source : https://leetcode.com/problems/n-queens/
    /// @des : 
    /// 从<see cref="TotalNQueens"/>直接搬运过来....
    /// </summary>
    public class SolveNQueens
    {

        IList<IList<string>> res;
        StringBuilder builder = new StringBuilder();

        /**
         * Runtime: 244 ms, faster than 79.35% of C# online submissions for N-Queens.
         * Memory Usage: 33 MB, less than 100.00% of C# online submissions for N-Queens.
         * 
         * emm....
         * 
         */
        public IList<IList<string>> Solution(int n)
        {
            res = new List<IList<string>>();

            bool[][] exists = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                exists[i] = new bool[n];
            }

            ClearHelper(n, exists, n);

            return res;
        }

        private void ClearHelper(int n, bool[][] exists, int num)
        {
            if (num == 0)
            {
                IList<string> list = new List<string>();

                #region diff

                for (int i = 0; i < exists.Length; i++)
                {
                    builder.Clear();
                    for (int j = 0; j < exists.Length; j++)
                    {
                        builder.Append(exists[i][j] ? 'Q' : '.');
                    }
                    list.Add(builder.ToString());
                }

                res.Add(list);
                #endregion

                return;
            }

            for (int j = 0; j < n; j++)
            {
                bool flag = true;
                for (int i = 0; i < n - num; i++)
                {
                    if (exists[i][j])
                    {
                        flag = false;
                        break;
                    }

                    var empty = j + i - (n - num);
                    if (empty >= 0 && empty < n && (exists[i][empty]))
                    {
                        flag = false;
                        break;
                    }

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

        #region fast

        public IList<IList<string>> Fast(int n)
        {
            res = new List<IList<string>>();

            char[][] exists = new char[n][];
            for (int i = 0; i < n; i++)
            {
                exists[i] = new char[n];
                Array.Fill(exists[i], '.');
            }

            ClearHelper(n, exists, n);

            return res;
        }

        private void ClearHelper(int n, char[][] exists, int num)
        {
            if (num == 0)
            {
                IList<string> list = new List<string>();

                #region diff

                for (int i = 0; i < exists.Length; i++)
                {
                    builder.Clear();
                    for (int j = 0; j < exists.Length; j++)
                    {
                        builder.Append(exists[i][j]);
                    }
                    list.Add(builder.ToString());
                }

                res.Add(list);
                #endregion

                return;
            }

            for (int j = 0; j < n; j++)
            {
                bool flag = true;
                for (int i = 0; i < n - num; i++)
                {
                    if (exists[i][j] == 'Q')
                    {
                        flag = false;
                        break;
                    }

                    var empty = j + i - (n - num);
                    if (empty >= 0 && empty < n && (exists[i][empty] == 'Q'))
                    {
                        flag = false;
                        break;
                    }

                    empty = j - i + (n - num);
                    if (empty >= 0 && empty < n && (exists[i][empty] == 'Q'))
                    {
                        flag = false;
                        break;
                    }
                }

                if (!flag) continue;

                exists[n - num][j] = 'Q';
                ClearHelper(n, exists, num - 1);
                exists[n - num][j] = '.';
            }
        }


        #endregion

    }
}
