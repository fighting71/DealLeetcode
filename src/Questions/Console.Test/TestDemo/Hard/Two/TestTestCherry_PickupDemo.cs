using Command.Helper;
using Newtonsoft.Json;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2021 11:45:02 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestTestCherry_PickupDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Cherry_Pickup instance = new Cherry_Pickup();

            BaseLibrary.CommonTest(new[] {
                    JsonConvert.DeserializeObject<int[][]>("[[1,1,1,1,0,0,0],[0,0,0,1,0,0,0],[0,0,0,1,0,0,1],[1,0,0,1,0,0,0],[0,0,0,1,0,0,0],[0,0,0,1,0,0,0],[0,0,0,1,1,1,1]]"), // 15
                    JsonConvert.DeserializeObject<int[][]>("[[1,1],[0,0]]"), // 0
                    JsonConvert.DeserializeObject<int[][]>("[[0,1,-1],[1,0,-1],[1,1,1]]"), // 5
                    JsonConvert.DeserializeObject<int[][]>("[[1,1,-1],[1,-1,1],[-1,1,1]]"), // 0
                }
            , instance.OtherSolution
            //, instance.Try5
            , () =>
            {
                const int len = 50;
                var arg = CollectionHelper.GetEnumerable(len, () => CollectionHelper.GetEnumerable(len, () =>
                {
                    var rand = random.Next(10);
                    if (rand < 3) return -1;
                    if (rand < 8) return 0;
                    return 1;
                }).ToArray()).ToArray();
                arg[0][0] = random.Next(2);
                arg[len - 1][len - 1] = random.Next(2);
                return arg;
            }
            //, checkFunc: instance.Simple
            );

            int GetRoads(int[][] grid)
            {
                // 2702049 ...
                int n = grid.Length;
                int?[][] dp = new int?[n + 1][];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = new int?[n + 1];
                }

                dp[n - 1][n - 1] = grid[n - 1][n - 1];

                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        if (i == n - 1 && j == n - 1) continue;
                        var curr = grid[i][j];
                        if (curr == -1) continue;
                        int? down = dp[i + 1][j], right = dp[i][j + 1];
                        if (down == null && right == null) continue;

                        if (curr == 0)
                        {
                            if (down == null) dp[i][j] = right;
                            else if (right == null) dp[i][j] = down;
                            else dp[i][j] = right + down;
                        }
                        else if (curr == 1)
                        {
                            int res = 1;
                            if (down != null) res += down.Value;
                            else if (right == null) res += right.Value;
                            dp[i][j] = res;
                        }
                    }
                }

                return dp[0][0] ?? 0;
            }

        }
    }
}
