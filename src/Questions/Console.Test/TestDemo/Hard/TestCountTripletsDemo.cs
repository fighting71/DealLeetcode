using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal;
using System.Collections.Generic;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 5:53:03 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCountTripletsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            CountTriplets instance = new CountTriplets();
            if (runSimple)
            { // simple

                var argArr = new[] {
                        //JsonConvert.DeserializeObject<int[]>("[31,47,88,70,2,98,53,70,27,50,0]"),// 583
                        //JsonConvert.DeserializeObject<int[]>("[31,47,88,70,2,98,53,70,27,50]"),// 252
                        //JsonConvert.DeserializeObject<int[]>("[1,4,8,16]"),// 252
                        JsonConvert.DeserializeObject<int[]>("[1,2,4]"),// 252
                        JsonConvert.DeserializeObject<int[]>("[88,2,87]"),// 252
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Solution(item));
                    ShowTools.Show(instance.Optimize3(item));

                    ShowTools.ShowHr();

                }

            }

            for (int j = 0; j < 1000; j++)
            { // speed&real
                break;
                var len = 100;
                var arr = new int[len];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(100);
                }

                int real = 0, res = 0;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { real = instance.Solution(arr); });
                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () => { res = instance.Optimize3(arr); });

                ShowTools.ShowMulti(new Dictionary<string, object>
                    {
                        {nameof(real),real },
                        {nameof(res),res },
                        //{nameof(codeTimerResult),codeTimerResult },
                        {nameof(codeTimerResult2),codeTimerResult2 },
                    });

                if (real != res)
                {
                    ShowTools.Show(arr);
                }

            }
        }

    }
}
