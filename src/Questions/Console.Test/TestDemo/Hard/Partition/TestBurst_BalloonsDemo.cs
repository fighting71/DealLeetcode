using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/13/2020 4:00:38 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestBurst_BalloonsDemo : BaseDemo, IWork
    {

        public void Run()
        {
            Burst_Balloons instance = new Burst_Balloons();
            { // simple

                var caseArr = new[]
                {
                    new[] { 3}, // 1849648  bug.
                    //new[] { 35,16,83,87,84,59,48,41,20,54}, // 1849648  bug.
                    //new[] { 3, 1, 5, 8 }, // 167
                    //new[] { 3, 1, 5, 8, 1, 5 },// 350
                    //new[] { 3, 1, 8, 5, 1, 5 }, // 389
                    //new[] { 3, 1, 2, 5, 8 },
                    //new[] { 3, 2, 1, 5, 8 },
                    };

                foreach (var item in caseArr)
                {
                    if (!runSimple) break;
                    ShowTools.Show(instance.OtherSolution(item));
                }
            }

            for (int i = 0; i < 100; i++)
            { // speed&real
                if (runSimple) break;

                var list = new List<int>();

                for (int j = 0; j < 100; j++)
                    list.Add(random.Next(101));

                var arr = list.ToArray();

                int res = 0, real = res;

                Console.WriteLine($@"
({arr.Length})
{JsonConvert.SerializeObject(arr)}
");

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                    {
                        res = new Burst_Balloons().Try2(arr);
                    });

                Console.WriteLine(codeTimerResult);

                //real = new Burst_Balloons().Simple(arr);

                //if (res != real) throw bugEx;

                ShowTools.ShowHr();

            }

        }


    }
}
