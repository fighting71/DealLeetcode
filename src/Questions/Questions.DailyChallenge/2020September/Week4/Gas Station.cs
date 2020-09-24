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

        // 与1差不多。
        public int Optimize2(int[] gas, int[] cost)
        {

            int len = gas.Length;
            int[] need = new int[len], diff = new int[len];

            int num = diff[0] = gas[0] - cost[0];

            need[0] = Math.Min(num, 0);

            for (int i = 1; i < len; i++)
                need[i] = Math.Min(Math.Min(num += diff[i] = gas[i] - cost[i], 0), need[i - 1]);

            int minNeed = num = 0;

            for (int i = len - 1; i > 0; i--)
            {

                num += diff[i];
                if (diff[i] >= 0)
                {
                    if (diff[i] >= -minNeed && num >= -need[i - 1])
                        return i;
                    minNeed = Math.Min(minNeed + diff[i], 0);
                }
                else
                    minNeed += diff[i];

            }

            if (diff[0] >= 0 && diff[0] + num >= -need[0])
                return 0;


            return -1;
        }

        //Runtime: 96 ms
        //Memory Usage: 24.6 MB
        // 快蛮多了。
        public int Optimize(int[] gas, int[] cost)
        {

            int len = gas.Length;
            int[] need = new int[len];

            int num = gas[0] - cost[0];

            need[0] = Math.Min(num, 0);

            for (int i = 1; i < len; i++)
            {
                need[i] = Math.Min(Math.Min(num += gas[i] - cost[i], 0), need[i - 1]);
            }

            int minNeed = num = 0,diff;

            for (int i = len - 1; i > 0; i--)
            {

                diff = gas[i] - cost[i];
                num += diff;
                if(diff >= 0)
                {
                    if(diff >= -minNeed)
                        if (num >= -need[i - 1])
                        {
                            return i;
                        }
                    minNeed = Math.Min(minNeed + diff, 0);
                }
                else
                    minNeed += diff;

            }

            diff = gas[0] - cost[0];
            if (diff>=0 && diff + num >= -need[0])
            {
                return 0;
            }

            //ShowTools.ShowLine(need);

            return -1;
        }

        //Runtime: 248 ms
        //Memory Usage: 24.6 MB
        public int Solution(int[] gas, int[] cost)
        {
            int len = gas.Length;
            int[] need = new int[len];
            int[] tank = new int[len];

            int num = 0;

            for (int i = 0; i < len; i++)
            {
                int diff = gas[i] - cost[i];

                num += diff;

                if (tank[0] >= 0)
                    tank[0] += diff;

                need[i] = Math.Min(num, 0);
                if(i>0)
                    need[i] = Math.Min(need[i], need[i - 1]);

                for (int j = 0; j < i; j++)
                {
                    if (tank[j + 1] >= 0)
                        tank[j + 1] += diff;
                }
            }

            //ShowTools.ShowLine(need);
            //ShowTools.ShowLine(tank);

            for (int i = len - 1; i >0; i--)
            {
                if (tank[i] >= -need[i - 1])
                {
                    return i;
                }
            }

            if (tank[0] >= 0) return 0;

            //for (int i = 1; i < len; i++)
            //{
            //    if (tank[i] >= -need[i - 1])
            //    {
            //        return i;
            //    }
            //}

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
