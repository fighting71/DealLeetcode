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
    /// @since : 11/17/2020 10:56:33 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestJumpIIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            JumpII instance = new JumpII();
            { // simple

                var argArr = new[]
                {
                        JsonConvert.DeserializeObject<int[]>("[3,4,3,1,0,7,0,3,0,2,0,3]"),// 3
                        JsonConvert.DeserializeObject<int[]>("[5,9,3,2,1,0,2,3,3,1,0,0]"),// 3
                        JsonConvert.DeserializeObject<int[]>("[2, 3, 1, 1, 4]"),// 2
                        JsonConvert.DeserializeObject<int[]>("[2, 3, 0, 1, 4]"),// 2
                        JsonConvert.DeserializeObject<int[]>("[9, 4, 6, 7, 1, 4, 9, 0, 1, 9, 9, 9, 5, 0, 7, 7, 9, 2, 4, 6, 6, 7, 6, 3, 6, 1, 8, 5, 4, 3, 3, 3, 7, 1, 0, 8, 6, 1, 0, 7, 1, 1, 9, 6, 1, 6, 6, 3, 1, 2, 1, 7, 0, 8, 0, 6, 1, 9, 1, 6, 4, 5, 9, 1, 8, 0, 1, 4]"),// 11
                    };

                foreach (var item in argArr)
                {
                    ShowTools.Show(instance.Optimize2(item));
                    ShowTools.Show(instance.Optimize3(item));
                }

            }
            for (int j = 0; j < 1000; j++)
            { // speed&real
                //break;
                int[] arr = new int[3 * 10_000];

                for (int i = 0; i < arr.Length; i++)
                {
                    //arr[i] = random.Next(100_000);
                    arr[i] = random.Next(1000);
                }

                int res = 0, real = 0;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = instance.Optimize3(arr);
                });

                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () =>
                {
                    real = instance.Optimize2(arr);
                });

                ShowTools.ShowMulti(new Dictionary<string, object>() {
                        //{nameof(arr),arr },
                        {nameof(res),res },
                        {nameof(real),real },
                        {nameof(codeTimerResult),codeTimerResult },
                        {nameof(codeTimerResult2),codeTimerResult2 },
                    });

                if (res != real)
                {
                    ShowTools.Show(arr);
                    throw bugEx;
                }

            }
        }

    }
}
