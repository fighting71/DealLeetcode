using Command.Attr;
using Command.Const;
using System.Collections.Generic;
using System.Linq;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/2/2020 4:50:19 PM
    /// @source : https://leetcode.com/problems/word-search-ii/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.DFS, FlagConst.Complex)]
    public class WordSearchII
    {

        char[][] board;
        bool[][] flag;

        /// <summary>
        /// Runtime: 812 ms, faster than 22.51% of C# online submissions for Word Search II.
        /// Memory Usage: 33 MB, less than 100.00% of C# online submissions for Word Search II.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> Solution2(char[][] board, string[] words)
        {
            if (board.Length == 0) return null;

            this.board = board;

            IList<string> res = new List<string>();

            m = board.Length; n = board[0].Length;

            flag = new bool[m][];
            bool succes;

            for (int i = 0; i < m; i++)
                flag[i] = new bool[n];

            foreach (var item in words)
            {
                succes = false;
                for (int i = 0; i < m && !succes; i++)
                    for (int j = 0; j < n && !succes; j++)
                        if (Help(item, i, j, 0))
                        {
                            res.Add(item);
                            succes = true;
                        }
            }

            return res;
        }

        public IList<string> Solution(char[][] board, string[] words)
        {
            if (board.Length == 0) return null;

            this.board = board;

            IList<string> res = new List<string>();

            m = board.Length; n = board[0].Length;

            flag = new bool[m][];

            for (int i = 0; i < m; i++)
                flag[i] = new bool[n];

            foreach (var item in words)
                if (Help(item)) res.Add(item);

            return res;
        }

        private bool Help(string str)
        {
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (Help(str, i, j, 0))
                        return true;
            return false;
        }

        // todo:Optimize speed
        private bool Help(string str, int i, int j, int k)
        {
            if (i == m || i == -1 || j == n || j == -1 || flag[i][j] || str[k] != board[i][j]) return false;

            if (k == str.Length - 1) return true;

            flag[i][j] = true;

            var result = Help(str, i + 1, j, k + 1) ||
            Help(str, i, j + 1, k + 1) ||
            Help(str, i - 1, j, k + 1) ||
            Help(str, i, j - 1, k + 1);

            flag[i][j] = false;

            return result;

        }

        /// <summary>
        /// Runtime: 856 ms, faster than 22.14% of C# online submissions for Word Search II.
        /// Memory Usage: 32.8 MB, less than 100.00% of C# online submissions for Word Search II.
        /// 
        /// nice~
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> Try3(char[][] board, string[] words)
        {
            if (board.Length == 0) return null;

            IList<string> res = new List<string>();

            m = board.Length;
            n = board[0].Length;

            bool[][] flag = new bool[m][];

            for (int i = 0; i < m; i++)
            {
                flag[i] = new bool[n];
            }

            foreach (var item in words)
            {
                bool skip = false;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Help(board, flag, item, i, j, 0, res))
                        {
                            skip = true;
                            res.Add(item);
                            break;
                        }
                    }
                    if (skip) break;
                }
            }

            return res;
        }

        private bool Help(char[][] board, bool[][] flag, string str, int i, int j, int k, IList<string> res)
        {
            if (i == m || i == -1 || j == n || j == -1 || flag[i][j]) return false;

            if (str[k] != board[i][j]) return false;

            if (k == str.Length - 1) return true;

            flag[i][j] = true;

            var result = Help(board, flag, str, i + 1, j, k + 1, res) ||
            Help(board, flag, str, i, j + 1, k + 1, res) ||
            Help(board, flag, str, i - 1, j, k + 1, res) ||
            Help(board, flag, str, i, j - 1, k + 1, res);

            flag[i][j] = false;

            return result;

        }

        public IList<string> Try2(char[][] board, string[] words)
        {
            if (board.Length == 0) return null;

            ISet<string> res = new HashSet<string>(), set = new HashSet<string>(words);
            int m = board.Length, n = board[0].Length;
            ISet<string>[][] dp = new ISet<string>[m][];

            bool[][] flag = new bool[m][];

            for (int i = 0; i < m; i++)
            {
                flag[i] = new bool[n];
                dp[i] = new ISet<string>[n];
            }

            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    char c = board[i][j];
                    ISet<string> arr = new HashSet<string>();

                    foreach (var item in dp[i][j])
                    {
                        if (set.Contains(item + c))
                        {
                            res.Add(item + c);
                            arr.Add(item + c);
                        }
                        else if (set.Any(u => u.StartsWith(item + c)))
                        {
                            arr.Add(item + c);
                        }
                    }
                }
            }

            return res.ToList();
        }

        // time limit
        public IList<string> Simple(char[][] board, string[] words)
        {
            if (board.Length == 0) return null;

            res = new HashSet<string>();
            set = new HashSet<string>(words);

            m = board.Length;
            n = board[0].Length;

            bool[][] flag = new bool[m][];

            for (int i = 0; i < m; i++)
            {
                flag[i] = new bool[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Help(board, flag, i, j, string.Empty);
                }
            }

            return res.ToList();
        }

        int m, n;

        ISet<string> res, set;

        // time limit
        private void Help(char[][] board, bool[][] flag, int i, int j, string build)
        {
            if (i == m || i == -1 || j == n || j == -1 || flag[i][j]) return;

            build += board[i][j];

            if (set.Contains(build)) res.Add(build);
            else if (!set.Any(u => u.StartsWith(build))) return;

            flag[i][j] = true;

            Help(board, flag, i + 1, j, build);
            Help(board, flag, i, j + 1, build);
            Help(board, flag, i - 1, j, build);
            Help(board, flag, i, j - 1, build);

            flag[i][j] = false;

        }

        private void Help(char[][] board, bool[][] flag, int i, int j, string build, string[] words, bool[] flag2, int index)
        {
            if (i == m || i == -1 || j == n || j == -1 || flag[i][j]) return;

            flag[i][j] = true;

            for (int k = 0; k < words.Length; k++)
            {
                if (flag2[k]) continue;
            }

            build += board[i][j];

            if (set.Contains(build)) res.Add(build);

            Help(board, flag, i + 1, j, build);
            Help(board, flag, i, j + 1, build);
            Help(board, flag, i - 1, j, build);
            Help(board, flag, i, j - 1, build);

            flag[i][j] = false;

        }

    }
}
