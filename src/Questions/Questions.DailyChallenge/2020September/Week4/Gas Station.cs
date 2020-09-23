using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020September.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/23/2020 4:18:52 PM
    /// @source : https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3470/
    /// @des : 
    /// </summary>
    public class Gas_Station
    {

        //bug
        public int Solution(int[] gas, int[] cost)
        {
            int len = gas.Length;

            int[][] need = new int[len][]; // *** need 计算bug
            int[] tank = new int[len];
            for (int i = 0; i < len; i++)
            {
                need[i] = new int[len - i];
            }
            //tank[0] = cache[0][0] = gas[0] - cost[0];
            for (int i = 0; i < len; i++)
            {
                int diff = gas[i] - cost[i];
                need[i][0] = Math.Min(0, diff);
                if (tank[0] >= 0)
                    tank[0] += diff;
                for (int j = 0; j < i; j++)
                {
                    // bug
                    need[j][i - j] = need[j][i - 1 - j] + need[i][0];
                    if (tank[j + 1] >= 0)
                        tank[j + 1] += diff;
                }
            }

            ShowTools.ShowMatrix(need);
            ShowTools.ShowLine(tank);

            if (tank[0] >= -need[0][len - 1]) return 0;

            for (int i = 1; i < len; i++)
            {
                if (tank[i] >= -need[0][len - i]) return i;
            }

            return -1;
        }

        public int Try(int[] gas, int[] cost)
        {
            int len = gas.Length;

            int[][] cache = new int[len][];
            int[][] tank = new int[len][];
            for (int i = 0; i < len; i++)
            {
                cache[i] = new int[len - i];
                tank[i] = new int[len - i];
            }
            for (int i = 0; i < len; i++)
            {
                int diff = tank[i][0] = gas[i] - cost[i];
                cache[i][0] = Math.Min(0, diff);
                for (int j = 0; j < i; j++)
                {
                    cache[j][i - j] = cache[j][i - 1 - j] + cache[i][0];
                    if ((tank[j][i - j] = tank[j][i - 1 - j]) >= 0)
                        tank[j][i - j] += tank[i][0];
                }
            }

            //ShowTools.ShowMatrix(cache);
            //ShowTools.ShowMatrix(tank);

            if (tank[0][0] >= -cache[0][len - 1]) return 0;

            for (int i = 1; i < len; i++)
            {
                if (tank[i][len - i - 1] >= -cache[0][len - i]) return i;
            }

            return -1;
        }

        public int Simple(int[] gas, int[] cost)
        {
            int res = -1, len = gas.Length, tank;

            int[] empty = new int[len];

            for (int i = 0; i < len; i++)
            {
                empty[i] = gas[i] - cost[i];
                if (gas[i] < cost[i]) continue;
                tank = gas[i] - cost[i];
                bool success = true;
                for (int j = (i + 1) % len; j != i; j = (j + 1) % len)
                {
                    tank = tank + gas[j] - cost[j];
                    if (tank < 0)
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    res = i;
                    break;
                }

            }

            ShowTools.ShowLine(empty);

            return res;
        }
    }
}
