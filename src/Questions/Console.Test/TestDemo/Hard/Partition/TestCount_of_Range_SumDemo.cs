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

        int[] GetArr(int len)
        {
            var arr = new int[len];

            for (int i = 0; i < len; i++)
            {
                arr[i] = random.Next(int.MinValue, int.MaxValue);
            }
            return arr;
        }

        public void Run()
        {
            //for (int i = 0; i < 3; i++)
            {
                //var arr = GetArr(random.Next(10_000));
                var arr = GetArr(10_000);
                var instance = new Count_of_Range_Sum();
                int min = random.Next(int.MinValue, int.MaxValue);
                int max = random.Next(int.MinValue, int.MaxValue);
                int res = 0, real = 0;
                CodeTimerResult codeTimerResult1 = codeTimer.Time(1, () =>
                {
                    real = instance.Simple(arr, min, max);
                });

                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () =>
                {
                    res = instance.Solution(arr, min, max);
                });

                ShowTools.ShowMulti(new Dictionary<string, object>
                {
                    {nameof(codeTimerResult1),codeTimerResult1 },
                    {nameof(codeTimerResult2),codeTimerResult2 },
                    {nameof(real),real },
                });

            }
            return;
            if (runSimple)
            { // simple
                //int res = new Count_of_Range_Sum().Optimize(new[] { 0, 0, 5, 5, 5, 6, 0, 8, 0, 1 }, 4, 12);
                //Console.WriteLine(res);
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
