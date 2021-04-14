using Command.Extension;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/12/2021 12:00:cellNum1 PM
    /// @source : https://leetcode.com/problems/sliding-puzzle/
    /// @des : 
    /// </summary>
    public class Sliding_Puzzle
    {

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

            int Help(int y, int x, int prevY, int prevX, int match,int step,int direction)
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
