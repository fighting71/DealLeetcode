using Command.Attr;
using Command.Const;
using Command.Extension;
using Command.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/12/2021 12:00:cellNum1 PM
    /// @source : https://leetcode.com/problems/sliding-puzzle/
    /// @des : 
    /// 
    ///     在一个2x3的棋盘上，有5个瓷砖用整数1到5表示，一个空的正方形用0表示。
    ///     一个移动包括选择0和一个4方向相邻的数字并交换它。
    ///     当且仅当单板为[[1,2,3]，[4,5,0]]时，单板状态解。
    ///     给定一个谜题棋盘，返回所需的最少步数，以便解决棋盘的状态。如果不可能解决板的状态，则返回-1。
    /// 
    /// </summary>
    //[Obsolete("pass.")]
    [Favorite(FlagConst.BFS)]
    public class Sliding_Puzzle
    {

        public int Clear(int[][] board)
        {

            const string target = "123450";

            string v = string.Concat(board.SelectMany(u => u));

            if (v == target) return 0;

            Stack<(int zeroIndex, string build)> curr = new Stack<(int, string)>(), next = new Stack<(int zeroIndex, string build)>();

            ISet<string> visited = new HashSet<string>
            {
                v
            };

            curr.Push((v.IndexOf('0'), v));

            int res = 1;
            var success = BfsHelper.Bfs(curr, next, () => { res++; }, (next, currV) =>
            {
                int i = currV.zeroIndex;
                var chars = currV.build.ToCharArray();
                if (i >= 3) // change top
                    Help(next, chars, i, i - 3);
                else // change bottom
                    Help(next, chars, i, i + 3);
                if (i % 3 != 0) // change left
                    Help(next, chars, i, i - 1);
                if (i % 3 != 2) // change right
                    Help(next, chars, i, i + 1);
                return false;
            });

            return success ? res : -1;

            bool Help(Stack<(int zeroIndex, string build)> next, char[] arr, int sourceIndex, int targetIndex)
            {
                char[] newChars = (char[])arr.Clone();
                var c = newChars[sourceIndex];
                newChars[sourceIndex] = newChars[targetIndex];
                newChars[targetIndex] = c;

                var str = new string(newChars);

                if (str == target)
                    return true;

                if (visited.Add(str)) next.Push((targetIndex, str));

                return false;
            }
        }

        // Runtime: 100 ms, faster than 73.02% of C# online submissions for Sliding Puzzle.
        // Memory Usage: 26.7 MB, less than 74.60% of C# online submissions for Sliding Puzzle.
        // bfs yyds!
        public int Try3(int[][] board)
        {

            string target = "123450";

            StringBuilder currV = new StringBuilder();

            foreach (var item in board)
            {
                foreach (var c in item)
                {
                    currV.Append(c);
                }
            }

            Stack<(int zeroIndex, string build)> curr = new Stack<(int, string)>(), next = new Stack<(int, string)>();

            string v = currV.ToString();

            if (v == target) return 0;

            curr.Push((v.IndexOf('0'), v));

            int res = 1;
            ISet<string> visited = new HashSet<string>();
            int i; string build;
            char[] chars;
            while (curr.Count > 0)
            {
                while (curr.Count > 0)
                {

                    (i, build) = curr.Pop();

                    chars = build.ToCharArray();

                    // 向上交换
                    if (i >= 3)
                    {
                        char[] newChars = (char[])chars.Clone();
                        var c = newChars[i];
                        newChars[i] = newChars[i - 3];
                        newChars[i - 3] = c;
                        if (HelpAdd(newChars, i - 3))
                        {
                            return res;
                        }
                    }
                    // 向下交换
                    else
                    {
                        char[] newChars = (char[])chars.Clone();
                        var c = newChars[i];
                        newChars[i] = newChars[i + 3];
                        newChars[i + 3] = c;
                        if (HelpAdd(newChars, i + 3))
                        {
                            return res;
                        }
                    }
                    // 向左交换
                    if (i % 3 != 0)
                    {
                        char[] newChars = (char[])chars.Clone();
                        var c = newChars[i];
                        newChars[i] = newChars[i - 1];
                        newChars[i - 1] = c;
                        if (HelpAdd(newChars, i - 1))
                        {
                            return res;
                        }
                    }
                    // 向右交换
                    if (i % 3 != 2)
                    {
                        char[] newChars = (char[])chars.Clone();
                        var c = newChars[i];
                        newChars[i] = newChars[i + 1];
                        newChars[i + 1] = c;
                        if (HelpAdd(newChars, i + 1))
                        {
                            return res;
                        }
                    }

                }
                res++;
                var empty = curr;
                curr = next;
                next = empty;

            }

            return -1;

            bool HelpAdd(char[] arr, int index)
            {
                var str = new string(arr);

                if (str == target)
                    return true;

                if (visited.Add(str)) next.Push((index, str));

                return false;
            }

        }

        /**
         * 每一步都可以进行交换，求最小步数=> bfs老案例好吧
         * 
         *  hard : 如何查重
         *      
         *      plan A: 字符串
         *      
         *          [[1,2,3]，[4,5,0]] =>  123450
         *          
         *          移动交换：
         *              向上，向左  
         *           【为什么没有向下、向右？】
         *             上一个向下  等价于 下一个向上（故为避免重复计算）
         */

        // bug ... 忘了只能移动0
        public int Try2(int[][] board)
        {

            string target = "123450";

            StringBuilder currV = new StringBuilder();

            foreach (var item in board)
            {
                foreach (var c in item)
                {
                    currV.Append(c);
                }
            }

            Stack<string> curr = new Stack<string>(), next = new Stack<string>();

            string v = currV.ToString();

            if (v == target) return 0;

            curr.Push(v);

            int res = 1;
            ISet<string> visited = new HashSet<string>();
            char[] chars;
            while (curr.Count > 0)
            {
                while (curr.Count > 0)
                {
                    chars = curr.Pop().ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        // 向上交换
                        if (i >= 3)
                        {
                            char[] newChars = (char[])chars.Clone();
                            var c = newChars[i];
                            newChars[i] = newChars[i - 3];
                            newChars[i - 3] = c;
                            if (HelpAdd(newChars))
                            {
                                return res;
                            }
                        }
                        // 向左交换
                        if (i % 3 != 0)
                        {
                            char[] newChars = (char[])chars.Clone();
                            var c = newChars[i];
                            newChars[i] = newChars[i - 1];
                            newChars[i - 1] = c;
                            if (HelpAdd(newChars))
                            {
                                return res;
                            }
                        }
                    }

                }
                res++;
                var empty = curr;
                curr = next;
                next = empty;

            }

            return -1;

            bool HelpAdd(char[] arr)
            {
                var str = new string(arr);

                if (visited.Add(str))
                {
                    next.Push(str);
                }

                Console.WriteLine($@"
old: {chars[0]}{chars[1]}{chars[2]} {chars[3]}{chars[4]}{chars[5]}

new: {arr[0]}{arr[1]}{arr[2]} {arr[3]}{arr[4]}{arr[5]}
");
                if (str == target)
                {
                    return true;
                }

                return false;
            }

        }

        // board will be a 2 x cellNum array as described above.
        // board[i][j] will be a permutation of[0, 1, 2, cellNum, 4, targetMatch].

        const int rowNum = 2, cellNum = 3;

        /*
         * 
         * 1 2 3
         * 4 5 0
         * 
         * 
         * 1 5 2
         * 4 3 0
         * 
         * 4 1 5
         * 3 2 0
         */

        // todo: debug
        public int Try(int[][] board)
        {

            int[][] build = new[]
            {
                new []{1,2,3 },
                new []{4,5,6 },
            };

            ISet<string> visited = new HashSet<string>();
            int match = 0;
            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < cellNum; j++)
                {
                    if (board[i][j] == i * cellNum + j + 1) match++;
                }
            }

            int targetMatch = rowNum * cellNum - 1;

            if (match == targetMatch) return 0;

            int y = rowNum - 1, x = cellNum - 1, step = 0;
            int res = Math.Min(Help(y - 1, x, y, x, match, step + 1, 1), Help(y, x - 1, y, x, match, step + 1, 3));

            return res == int.MaxValue ? -1 : res;

            int Help(int y, int x, int prevY, int prevX, int match, int step, int direction)
            {
                if (y == -1 || y == rowNum || x == -1 || x == cellNum) return int.MaxValue;
                if (build[y][x] == board[y][x]) return int.MaxValue;
                var key = $"{y},{x},{direction},{build.SerieJson()}";
                if (visited.Contains(key)) return int.MaxValue;
                int curr = build[y][x];
                if (curr == board[prevY][prevX])
                {
                    match++;
                    if (match == targetMatch) return step;
                }

                build[y][x] = build[prevY][prevX];
                build[prevY][prevX] = curr;
                visited.Add(key);

                int res = 0;
                res = Math.Min(res, Help(y + 1, x, y, x, match, step + 1, 0));
                res = Math.Min(res, Help(y - 1, x, y, x, match, step + 1, 1));
                res = Math.Min(res, Help(y, x + 1, y, x, match, step + 1, 2));
                res = Math.Min(res, Help(y, x - 1, y, x, match, step + 1, 3));

                build[prevY][prevX] = build[y][x];
                build[y][x] = curr;
                return res;
            }

        }
        public int Simple(int[][] board)
        {

            int match = 0;

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < cellNum; j++)
                {
                    if (board[i][j] == i * cellNum + j + 1) match++;
                }
            }

            int targetMatch = rowNum * cellNum - 1;

            if (match == targetMatch) return 0;

            int[][] build = new[]
            {
                new []{1,2,3 },
                new []{4,5,6 },
            };

            int res = Math.Min(HelpUp(rowNum - 1, cellNum - 1, 1, match), HelpLeft(rowNum - 1, cellNum - 1, 1, match));

            return res == int.MaxValue ? -1 : res;

            int HelpUp(int y, int x, int step, int match)
            {
                y--;
                if (y == -1) return int.MaxValue;

                int r = build[y][x];

                if (r == board[y][x]) return int.MaxValue;
                if (r == board[y + 1][x]) match++;
                if (match == targetMatch) return step;

                build[y][x] = build[y + 1][x];
                build[y + 1][x] = r;
                int res = Math.Min(HelpLeft(y, x, step + 1, match), HelpRight(y, x, step + 1, match));

                build[y + 1][x] = build[y][x];
                build[y][x] = r;
                return res;

            }
            int HelpDown(int y, int x, int step, int match)
            {
                y++;
                if (y == rowNum) return int.MaxValue;

                int r = build[y][x];

                if (r == board[y][x]) return int.MaxValue;
                if (r == board[y - 1][x]) match++;
                if (match == targetMatch) return step;

                build[y][x] = build[y - 1][x];
                build[y - 1][x] = r;
                int res = Math.Min(HelpLeft(y, x, step + 1, match), HelpRight(y, x, step + 1, match));

                build[y - 1][x] = build[y][x];
                build[y][x] = r;
                return res;

            }
            int HelpLeft(int y, int x, int step, int match)
            {
                x--;
                if (x == -1) return int.MaxValue;

                int r = build[y][x];

                if (r == board[y][x]) return int.MaxValue;
                if (r == board[y][x + 1]) match++;
                if (match == targetMatch) return step;

                build[y][x] = build[y][x + 1];
                build[y][x + 1] = r;
                int res = Math.Min(HelpLeft(y, x, step + 1, match), HelpUp(y, x, step + 1, match));
                res = Math.Min(res, HelpDown(y, x, step + 1, match));

                build[y][x + 1] = build[y][x];
                build[y][x] = r;
                return res;
            }
            int HelpRight(int y, int x, int step, int match)
            {
                x++;
                if (x == cellNum) return int.MaxValue;

                int r = build[y][x];

                if (r == board[y][x]) return int.MaxValue;
                if (r == board[y][x - 1]) match++;
                if (match == targetMatch) return step;

                build[y][x] = build[y][x - 1];
                build[y][x - 1] = r;

                int res = Math.Min(HelpRight(y, x, step + 1, match), HelpUp(y, x, step + 1, match));
                res = Math.Min(res, HelpDown(y, x, step + 1, match));

                build[y][x - 1] = build[y][x];
                build[y][x] = r;
                return res;
            }

        }

    }
}
