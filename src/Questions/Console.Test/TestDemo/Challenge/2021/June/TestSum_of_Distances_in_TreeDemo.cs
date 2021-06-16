using Newtonsoft.Json;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.June
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/16/2021 11:33:59 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSum_of_Distances_in_TreeDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Sum_of_Distances_in_Tree instance = new Sum_of_Distances_in_Tree();

            BaseLibrary.CommonTest(new[] {
                    (6, JsonConvert.DeserializeObject<int[][]>("[[0,1],[0,2],[2,3],[2,4],[2,5]]")), //  [8,12,6,10,10,10]
                    //(6, JsonConvert.DeserializeObject<int[][]>("[[0,1],[0,2],[2,3],[2,4],[2,5],[1,2]]")), //  [8,12,6,10,10,10]
                }
            , arg => instance.Try2(arg.Item1, arg.Item2)
            //, arg => instance.Try(arg.Item1, arg.Item2)
            //, arg => instance.Bfs(arg.Item1, arg.Item2)
            //, arg => instance.Dfs(arg.Item1, arg.Item2)
            , generateArg: () =>
            {
                int n = 1000;

                List<int> remind = Enumerable.Range(2, n - 2).ToList();
                List<int> exists = new List<int>() { 0, 1 };

                List<int[]> edges = new List<int[]>(n);

                edges.Add(new[] { 1, 2 });

                while (remind.Count > 0)
                {
                    var get = random.Next(remind.Count);

                    var num = remind[get];
                    remind.RemoveAt(get);

                    edges.Add(new[] { num, exists[random.Next(exists.Count)] });

                    exists.Add(num);

                }

                return (
                    n,
                    edges.ToArray()
                );
            }
            , formatArg: arg => $"{arg.Item1}\n{JsonConvert.SerializeObject(arg.Item2)}"
            );

        }
    }
}
