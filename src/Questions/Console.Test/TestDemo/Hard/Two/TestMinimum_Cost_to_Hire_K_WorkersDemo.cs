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
    /// @since : 6/29/2021 9:54:00 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinimum_Cost_to_Hire_K_WorkersDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Minimum_Cost_to_Hire_K_Workers instance = new Minimum_Cost_to_Hire_K_Workers();

            BaseLibrary.CommonTest(new[] {
                    (new []{ 10,20,5 },new []{ 70,50,30 },2), // 105
                    (new []{ 3,1,10,10,1 },new []{ 4,8,2,2,7 },3), // 30.66667
                }
            , arg => instance.Try4(arg.Item1, arg.Item2, arg.Item3)
            //, arg => instance.Try3(arg.Item1, arg.Item2, arg.Item3)
            //, arg => instance.Try(arg.Item1, arg.Item2, arg.Item3)
            , () =>
            {
                int n = 10000;
                    //int n = 10;
                    int k = random.Next(n) + 1;

                int maxV = 10000;

                int[] quality = CollectionHelper.GetEnumerable(n, () => random.Next(maxV) + 1).ToArray(),
                wage = CollectionHelper.GetEnumerable(n, () => random.Next(maxV) + 1).ToArray();

                return (quality, wage, k);

            }
            //, checkFunc: arg => instance.Try2(arg.Item1, arg.Item2, arg.Item3)
            //, checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3)
            //, arg => instance.MincostToHireWorkers(arg.Item1, arg.Item2, arg.Item3)
            , equalsFunc: (res, res2) => (int)res == (int)res2
            //, showArg: false
            //, codeTimeCount: 20
            , formatArg: arg => $"{JsonConvert.SerializeObject(arg.Item1)}\n{JsonConvert.SerializeObject(arg.Item2)}\n{arg.Item3}"
            );

        }
    }
}
