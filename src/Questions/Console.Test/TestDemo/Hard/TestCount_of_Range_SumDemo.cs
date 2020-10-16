using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/14/2020 3:39:07 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCount_of_Range_SumDemo : BaseDemo
    {

        public void Run()
        {
            if (runSimple)
            { // simple
                int res = new Count_of_Range_Sum().Optimize(new[] { 0, 0, 5, 5, 5, 6, 0, 8, 0, 1 }, 4, 12);
                Console.WriteLine(res);
            }
            else
            { // speed&real
                CodeTimerResult codeTimerResult;

                List<int> list = new List<int>();

                for (int i = 0; i < 10; i++)
                {
                    list.Add(random.Next(10));
                }
                var arr = list.ToArray();
                for (int i = 0; i < 100; i++)
                {
                    var min = random.Next(10);
                    var max = min + random.Next(10);
                    int res = 0, real = 0;
                    codeTimerResult = codeTimer.Time(1, () => {
                        real = new Count_of_Range_Sum().Simple(arr, min, max);
                    });

                    Console.WriteLine(codeTimerResult);

                    codeTimerResult = codeTimer.Time(1, () => {
                        res = new Count_of_Range_Sum().Optimize(arr, min, max);
                    });

                    Console.WriteLine("Optimize:" + codeTimerResult);

                    ShowTools.ShowMulti(new Dictionary<string, object> {
                            {nameof(arr),arr },
                            {nameof(min),min },
                            {nameof(max),max },
                            {nameof(res),res },
                            {nameof(real),real },
                        });

                    if (res != real) throw bugEx;

                    ShowTools.ShowHr();

                }

            }
        }

    }
}
