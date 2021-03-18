using Newtonsoft.Json;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/18/2021 6:29:49 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCut_Off_Trees_for_Golf_EventDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Cut_Off_Trees_for_Golf_Event instance = new Cut_Off_Trees_for_Golf_Event();

            //Console.WriteLine(instance.CutOffTree(JsonConvert.DeserializeObject<List<IList<int>>>("[[1,2,3],[0,0,4],[7,6,5]]")));

            BaseLibrary.CommonTest(
                new IList<IList<int>>[]
                {
                        JsonConvert.DeserializeObject<List<IList<int>>>("[[1,2,3],[0,0,4],[7,6,5]]"),//6
                        JsonConvert.DeserializeObject<List<IList<int>>>("[[1,2,3],[0,0,0],[7,6,5]]"),//-1
                        JsonConvert.DeserializeObject<List<IList<int>>>(" [[2,3,4],[0,0,5],[8,7,6]]"),//6
                },
                instance.Try
                , generateArg: () =>
                {
                        // m == forest.length
                        // n == forest[i].length
                        //1 <= m, n <= 50
                        //0 <= forest[i][j] <= 10^9

                        int m = 50, n = 50;

                    ISet<int> set = new HashSet<int>();

                    int[][] res = new int[m][];

                    for (int i = 0; i < m; i++)
                    {
                        res[i] = new int[n];
                        for (int j = 0; j < n; j++)
                        {
                            int rand;
                            do
                            {
                                rand = random.Next(1000_000_000);
                            } while (rand > 1 && set.Contains(rand));
                            res[i][j] = rand;
                        }
                    }

                    return res.Select(u => u.ToList() as IList<int>).ToList();
                }
            );

        }

    }
}
