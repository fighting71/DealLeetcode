using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/6/2021 3:23:14 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRussian_Doll_EnvelopesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Russian_Doll_Envelopes instance = new Russian_Doll_Envelopes();

            if (runSimple)
            {
                Console.WriteLine(instance.Try(JsonConvert.DeserializeObject<int[][]>(" [[5,4],[6,4],[6,7],[2,3]]")));
                Console.WriteLine(instance.Try(JsonConvert.DeserializeObject<int[][]>(" [[5,4],[5,4],[6,7],[2,7]]")));
            }
            //else
            for (int k = 0; k < 10; k++)
            {

                int len = 10000;

                int[][] arr = new int[len][];

                for (int i = 0; i < len; i++)
                {
                    arr[i] = new[] { random.Next(100) + 1, random.Next(100) + 1 };
                }

                int res = 0, real = 0;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { real = instance.Try(arr); });
                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () => { res = instance.Optimize(arr); });

                ShowTools.ShowMulti(new (string, object)[] {
                        (nameof(res),res),
                        (nameof(real),real),
                        (nameof(codeTimerResult),codeTimerResult),
                        (nameof(codeTimerResult2),codeTimerResult2),
                    });

                if (real != res) throw bugEx;

            }
        }
    }
}
