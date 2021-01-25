using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.January.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/24/2021 2:23:27 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSort_the_Matrix_DiagonallyDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Sort_the_Matrix_Diagonally instance = new Sort_the_Matrix_Diagonally();

            int[][] res = instance.Simple(JsonConvert.DeserializeObject<int[][]>("[[3,3,1,1],[2,2,1,2],[1,1,1,2]]"));

            ShowTools.Show(res);

            BaseLibrary.CommonTest(new int[0][][], instance.Simple, () =>
            {
                int m = random.Next(100) + 1, n = random.Next(100) + 1;
                int[][] arr = new int[m][];
                for (int i = 0; i < m; i++)
                {
                    arr[i] = new int[n];

                    for (int j = 0; j < n; j++)
                    {
                        arr[i][j] = random.Next(100) + 1;
                    }
                }

                ShowTools.Show(arr);

                return arr;
            }, showArg: false);

        }
    }
}
