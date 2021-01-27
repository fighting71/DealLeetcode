using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 6:27:24 PM
    /// @source : https://leetcode.com/problems/zuma-game/
    /// @des : 
    /// </summary>
    public class Zuma_Game
    {

        // You may assume that the initial row of balls on the table won’t have any 3 or more consecutive balls with the same color.
        //1 <= board.length <= 16
        //1 <= hand.length <= 5
        //Both input strings will be non-empty and only contain characters 'R','Y','B','G','W'.

        public int FindMinStep(string board, string hand)
        {

            // 红(R)，黄(Y)，蓝(B)，绿(G)和白(W)

            Dictionary<char, List<int>> dic = new Dictionary<char, List<int>>();

            foreach (var item in board)
            {

            }

            int res = -1;

            void Helper(List<(char, int)> list, int i, Dictionary<char, int> countDic)
            {
                if (i == list.Count)
                {
                    return;
                }

                var curr = list[i];

                if (countDic.ContainsKey(curr.Item1))
                {
                    var max = countDic[curr.Item1];
                    var old = countDic[curr.Item1];
                    var oldNum = curr.Item2;
                    for (int j = Math.Min(max, 3 - curr.Item2) + curr.Item2; j > 0; j++)
                    {
                        if (j + curr.Item2 == 3)
                        { // 缩减

                            list.RemoveAt(i);

                        }
                        curr.Item2 += j;
                        countDic[curr.Item1] = old - j;
                        Helper(list, i, countDic);
                    }
                    countDic[curr.Item1] = old;
                }

                Helper(list, i + 1, countDic);

            }

            return -1;

        }

    }
}
