using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/28/2020 3:03:53 PM
    /// @source : https://leetcode.com/problems/sudoku-solver/
    /// @des : 数独
    /// </summary>
    [Obsolete(FlagConst.Complex)]
    public class SolveSudoku
    {

        #region test method

        // 测试输出
        public void ShowDic(ISet<char>[] dic)
        {
            Console.WriteLine("-------------------S-------------------");
            for (int i = 0; i < dic.Length; i++)
            {
                if (i % 9 == 0) Console.WriteLine();

                StringBuilder builder = new StringBuilder();

                builder.Append('[');

                if (dic[i] != null)
                {
                    builder.Append(string.Join(",", dic[i]));

                    for (int j = 0; j < 9 - dic[i].Count; j++)
                    {
                        builder.Append("  ");
                    }

                }
                else
                {
                    builder.Append("                 ");
                }

                builder.Append(']');

                Console.Write(builder.ToString());

            }
            Console.WriteLine();
            Console.WriteLine("-------------------E-------------------");


        }

        public void ShowBoard(char[][] board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write($"[ {(board[i][j] == '.' ? ' ' : board[i][j])} ]");
                }

                Console.WriteLine();
            }
        }
        #endregion

        public void Solution(char[][] board)
        {
            ISet<char>[] dic = new HashSet<char>[9 * 9];

            ISet<char> set;

            for (int i = 0; i < 9; i++)
            {
                set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                for (int j = 0; j < 9; j++)
                    set.Remove(board[i][j]);

                for (int j = 0; j < 9; j++)
                    if (board[i][j] == '.')
                        PushDic(dic, set, i, j);


                set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                for (int j = 0; j < 9; j++)
                    set.Remove(board[j][i]);

                for (int j = 0; j < 9; j++)
                    if (board[j][i] == '.')
                        PushDic(dic, set, j, i);


            }

            for (int i = 0; i < 3; i++)
            {
                for (int h = 0; h < 3; h++)
                {
                    set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            set.Remove(board[i * 3 + j][h * 3 + k]);

                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            if (board[i * 3 + j][h * 3 + k] == '.')
                                PushDic(dic, set, i * 3 + j, h * 3 + k);
                }
            }

            for (int i = 0; i < 9 * 9; i++)
                NewRoundRemove(dic, board, i);

            ShowDic(dic);
            ShowBoard(board);

        }

        private void NewRoundRemove(ISet<char>[] dic, char[][] board, int index)
        {

            if (dic[index] == null) return;

            char c = default;

            if(dic[index].Count == 1)
            {
                c = dic[index].First();
            }
            else
            {
                foreach (var item in dic[index])
                {
                    if (IsSingle(dic, board, index, item))
                    {
                        c = item;
                        break;
                    }
                }
            }

            if (c == default) return;

            int i = index / 9, j = index % 9;

            board[i][j] = c;
            dic[index] = null;


            for (int k = 0; k < 9; k++)
            {
                dic[(index = k * 9 + j)]?.Remove(c);
                NewRoundRemove(dic, board, index);

                dic[(index = i * 9 + k)]?.Remove(c);
                NewRoundRemove(dic, board, index);

            }

            for (int k = 0; k < 3; k++)
                for (int h = 0; h < 3; h++)
                {
                    dic[(index = (i / 3 * 3 + k) * 9 + j / 3 * 3 + h)]?.Remove(c);
                    NewRoundRemove(dic, board, index);
                }
        }

        private bool IsSingle(ISet<char>[] dic,char[][] board, int index, char c)
        {
            int i = index / 9, j = index % 9;

            bool flag = true;
            for (int k = 0; k < 9; k++)
            {
                if (k == j) continue;
                if (board[i][k] == c || (dic[i * 9 + k]?.Contains(c) ?? false))
                {
                    flag = false;
                    break;
                }
            }

            if (flag) return true;

            flag = true;
            for (int k = 0; k < 9; k++)
            {
                if (k == i) continue;
                if (board[k][j] == c || (dic[k * 9 + j]?.Contains(c) ?? false))
                {
                    flag = false;
                    break;
                }
            }

            if (flag) return true;

            flag = true;

            for (int k = 0; k < 3; k++)
            {
                for (int h = 0; h < 3; h++)
                {
                    if (board[(i / 3) * 3 + k][(j / 3) * 3 + h] == c || (dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h]?.Contains(c) ?? false))
                    {
                        flag = false;
                        break;
                    }
                }
            }

            return flag;
        }

        // todo:三链数删减法...
        private void HelpRemove()
        {
            //三链数删减法类似于矩形删减法，是矩形删减法的推广。
            //三链数删减法指的是如果某个数字在某三列中只出现在相同的三行中，则这个数字将从这三行上其他的候选数中删除；
        }

        #region try ==> clear

        public void Clear(char[][] board)
        {
            ISet<char>[] dic = new HashSet<char>[9 * 9];

            ISet<char> set;

            for (int i = 0; i < 9; i++)
            {
                set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                for (int j = 0; j < 9; j++)
                    set.Remove(board[i][j]);

                for (int j = 0; j < 9; j++)
                    if (board[i][j] == '.')
                        PushDic(dic, set, i, j);


                set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                for (int j = 0; j < 9; j++)
                    set.Remove(board[j][i]);

                for (int j = 0; j < 9; j++)
                    if (board[j][i] == '.')
                        PushDic(dic, set, j, i);


            }

            for (int i = 0; i < 3; i++)
            {
                for (int h = 0; h < 3; h++)
                {
                    set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            set.Remove(board[i * 3 + j][h * 3 + k]);

                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            if (board[i * 3 + j][h * 3 + k] == '.')
                                PushDic(dic, set, i * 3 + j, h * 3 + k);
                }
            }

            for (int i = 0; i < 9 * 9; i++)
                if (dic[i] != null && dic[i].Count == 1)
                    RoundRemove(dic, board, i);
            ShowDic(dic);
            ShowBoard(board);

        }

        public void RoundRemove(ISet<char>[] dic, char[][] board, int index)
        {

            int i = index / 9, j = index % 9;

            var c = dic[index].First();
            board[i][j] = c;
            dic[index] = null;


            for (int k = 0; k < 9; k++)
            {
                if (dic[(index = k * 9 + j)] != null)
                {
                    dic[index].Remove(c);

                    if (dic[index].Count == 1)
                        RoundRemove(dic, board, index);
                }

                if (dic[(index = i * 9 + k)] != null)
                {
                    dic[index].Remove(c);
                    if (dic[index].Count == 1)
                        RoundRemove(dic, board, index);
                }
            }

            for (int k = 0; k < 3; k++)
                for (int h = 0; h < 3; h++)
                    if (dic[(index = (i / 3 * 3 + k) * 9 + j / 3 * 3 + h)] != null)
                    {
                        dic[index].Remove(c);
                        if (dic[index].Count == 1)
                            RoundRemove(dic, board, index);
                    }

        }

        private void PushDic(ISet<char>[] dic, ISet<char> set, int i, int j)
        {
            if (dic[i * 9 + j] == null)
                dic[i * 9 + j] = new HashSet<char>(set);
            else
                foreach (var item in dic[i * 9 + j].ToArray())
                    if (!set.Contains(item)) dic[i * 9 + j].Remove(item);
        }

        #endregion

        #region try
        [Obsolete("bug")]
        public void Try2(char[][] board)
        {

            /*
             * <思路>
             * 
             * 创建一个 (i,j) => set 的 dic (i-竖坐标，j-横坐标，set可能的值)
             * 
             * 遍历棋盘(横向遍历，竖向遍历，同网格遍历) 将所有未确定的可能值存放到dic中，并在存放时取交集 即 (原有可能值)∩(新得到的可能值)
             * 
             * 遍历dic 即 遍历所有set
             *  如果set.count = 1 即有确定值
             *  step2:则将确定值赋值给board，且遍历与此set相关的set(同一行/同一列/同一网格) 去除相关set中的此确认值可能
             *      step3:相关set去除后如果出现确认值，则继续执行step2
             * 
             * 
             */

            // 创建一个dic 用于 实现 i->j->set的指向功能 
            // (i->j)->set ==> (i*9+j)->set
            // 使用set便于查看是否存在
            // set用于存储(i,j)可能存在的值
            ISet<char>[] dic = new HashSet<char>[9 * 9];

            ISet<char> set;

            for (int i = 0; i < 9; i++)
            {
                // 初始假设1-9都有可能
                set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                // 横向遍历
                for (int j = 0; j < 9; j++)
                {
                    // 移除可能项，例如已存在1那么其他便不可能为1
                    set.Remove(board[i][j]);
                }

                // 横向遍历，将可能值进行存储
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        DicHelp(dic, set, i, j);
                    }
                }

                // 竖向遍历 处理同上
                set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                for (int j = 0; j < 9; j++)
                {
                    set.Remove(board[j][i]);
                }

                for (int j = 0; j < 9; j++)
                {
                    if (board[j][i] == '.')
                    {
                        DicHelp(dic, set, j, i);
                    }
                }

            }

            // 同一方块进行遍历 处理同上
            for (int i = 0; i < 3; i++)
            {
                for (int h = 0; h < 3; h++)
                {
                    set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            set.Remove(board[i * 3 + j][h * 3 + k]);
                        }
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (board[i * 3 + j][h * 3 + k] == '.')
                            {
                                DicHelp(dic, set, i * 3 + j, h * 3 + k);
                            }
                        }
                    }
                }
            }

            ShowDic(dic);

            // 遍历所有(i,j)
            for (int i = 0; i < 9 * 9; i++)
            {
                // 如果 dic(i,j).count = 1 表示可以赋值
                if (dic[i] == null) continue;

                if (dic[i].Count == 1)
                {
                    // 递归影响其他相关值
                    WorkHelp(dic, board, i / 9, i % 9, dic[i].First());
                }

            }

            Console.WriteLine(">>>>>>>>>>>>>>>>finally<<<<<<<<<<<<<<<<");
            ShowDic(dic);
            ShowBoard(board);

            Console.WriteLine($"[{string.Join(',', board.Select(u => $"[{string.Join(',', u)}]"))}]");

        }

        public void WorkHelp(ISet<char>[] dic, char[][] board, int index,char c)
        {

            if (dic[index] == null) return;

            int i = index / 9, j = index % 9;

            // 给表格赋值
            board[i][j] = c;
            // 清空dic 避免重复验证
            dic[i * 9 + j] = null;

            for (int k = 0; k < 9; k++)
            {
                // 在同一竖
                if (dic[k * 9 + j] != null)
                {
                    dic[k * 9 + j].Remove(c);

                    // 移除后出现确定值 则继续影响相关值
                    if (dic[k * 9 + j].Count == 1)
                    {
                        WorkHelp(dic, board, k, j, dic[k * 9 + j].First());
                    }
                }

                // 在同一行 处理同上
                if (dic[i * 9 + k] != null)
                {
                    dic[i * 9 + k].Remove(c);
                    if (dic[i * 9 + k].Count == 1)
                    {
                        WorkHelp(dic, board, i, k, dic[i * 9 + k].First());
                    }
                }
            }

            // 查看同一网格 处理同上
            for (int k = 0; k < 3; k++)
            {
                for (int h = 0; h < 3; h++)
                {
                    if (dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h] != null)
                    {
                        dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h].Remove(c);
                        if (dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h].Count == 1)
                        {
                            WorkHelp(dic, board, i / 3 * 3 + k, j / 3 * 3 + h, dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h].First());
                        }
                    }
                }
            }

        }

        public void WorkHelp(ISet<char>[] dic, char[][] board, int i, int j,char c)
        {

            //Console.WriteLine($"i:{i},j:{j},c:{c}");
            //ShowBoard(board);
            //ShowDic(dic);

            //Console.ReadKey(true);

            // 给表格赋值
            board[i][j] = c;
            // 清空dic 避免重复验证
            dic[i * 9 + j] = null;

            for (int k = 0; k < 9; k++)
            {
                // 在同一竖
                if (dic[k * 9 + j] != null)
                {
                    dic[k * 9 + j].Remove(c);

                    // 移除后出现确定值 则继续影响相关值
                    if (dic[k * 9 + j].Count == 1)
                    {
                        WorkHelp(dic, board, k, j, dic[k * 9 + j].First());
                    }
                }

                // 在同一行 处理同上
                if (dic[i * 9 + k] != null)
                {
                    dic[i * 9 + k].Remove(c);
                    if (dic[i * 9 + k].Count == 1)
                    {
                        WorkHelp(dic, board, i, k, dic[i * 9 + k].First());
                    }
                }
            }

            // 查看同一网格 处理同上
            for (int k = 0; k < 3; k++)
            {
                for (int h = 0; h < 3; h++)
                {
                    if (dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h] != null)
                    {
                        dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h].Remove(c);
                        if (dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h].Count == 1)
                        {
                            WorkHelp(dic, board, i / 3 * 3 + k, j / 3 * 3 + h, dic[(i / 3 * 3 + k) * 9 + j / 3 * 3 + h].First());
                        }
                    }
                }
            }

        }

        // 存储可能值
        private void DicHelp(ISet<char>[] dic, ISet<char> set, int i, int j)
        {
            //var emp = i * 9 + j;
            //var old = dic[i * 9 + j]?.ToArray();

            if (dic[i * 9 + j] == null)// 直接不存在可能值
            {
                // 直接赋值，注：直接赋值set会导致 同一引用问题...
                dic[i * 9 + j] = new HashSet<char>(set);
            }
            else
            {
                // 遍历原有可能值
                foreach (var item in dic[i * 9 + j].ToArray())
                {
                    // 若新可能值不存在此值则移除.
                    if (!set.Contains(item)) dic[i * 9 + j].Remove(item);
                }
            }

            //if (dic[i * 9 + j].Count < 2)
            //{
            //    Console.WriteLine("-----");
            //}
        }

        // dic存储过于复杂...
        private void DicHelp(Dictionary<int, Dictionary<int, ISet<char>>> dic, ISet<char> set, int i, int j)
        {
            if (!dic.ContainsKey(i))
            {
                dic[i] = new Dictionary<int, ISet<char>>();
                dic[i][j] = set;
            }
            else
            {
                if (!dic[i].ContainsKey(j))
                {
                    dic[i][j] = set;
                }
                else
                {
                    foreach (var item in dic[i][j].ToArray())
                    {
                        if (!set.Contains(item)) dic[i][j].Remove(item);
                    }
                }
            }
        }
        #endregion

        #region simple

        [Obsolete("bug")]
        public void Simple(char[][] board)
        {

            List<int[]> list = new List<int[]>();

            // 将为.的元素加入列表中
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '.') list.Add(new[] { i, j });
                }
            }

            // 循环直到所有元素值被确认
            while (list.Count > 0)
            {
                for (int i = 0; i < list.Count;)
                {
                    // 获取当前点值
                    board[list[i][0]][list[i][1]] = Help(board, list[i][0], list[i][1]);
                    if (board[list[i][0]][list[i][1]] != '.') // 猜测成功赋值并移除
                    {
                        list.RemoveAt(i);
                    }
                    else// 猜测不出跳过
                    {
                        i++;
                    }
                }
            }

        }

        // 获取点值
        private char Help(char[][] board, int i, int j)
        {
            char res = '.';

            // 遍历1-9
            for (int k = '1'; k <= '9'; k++)
            {
                // 查看k是否存在
                if (!IsExists(board, i, j, k))
                {
                    if (res == '.') res = (char)k;
                    else return '.';
                }
            }

            return res;
        }

        // 搜索横、竖、同一网格 查看c是否存在
        private bool IsExists(char[][] board, int i, int j, int c)
        {

            for (int k = 0; k < 9; k++)
            {
                if (board[i][k] == c) return true;
                if (board[k][j] == c) return true;
            }

            for (int k = i / 3 * 3; k < 3; k++)
            {
                for (int h = j / 3 * 3; h < 3; h++)
                {
                    if (board[k][h] == c) return true;
                }
            }

            return false;

        }

        #endregion
    }
}
