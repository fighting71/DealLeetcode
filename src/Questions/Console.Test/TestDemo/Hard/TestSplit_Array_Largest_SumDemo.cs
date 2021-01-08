using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 2:32:05 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSplit_Array_Largest_SumDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Split_Array_Largest_Sum instance = new Split_Array_Largest_Sum();
            if (runSimple)
            {
                var argArr = new[]
                {

                        ("[1,16,54,4,38,95,102,74,77,100]",3), // 3284
                        ("[98,38,43,25,79,66,1,100,87,26,1,16,54,4,38,95,102,74,77,100]",6), // 213
                        (" [7,2,5,10,8]",2), // 18
                        ("[1,2,3,4,5]",2),// 9
                        ("[1,4,4]",3) // 4
                    };

                foreach (var arg in argArr)
                {
                    var arr = JsonConvert.DeserializeObject<int[]>(arg.Item1);

                    ShowTools.Show(instance.Optimize(arr, arg.Item2));
                }

            }
            //else
            for (int k = 0; k < 10; k++)
            {
                if (runSimple) break;
                int len = 1000;
                //len = 20;

                var arr = new int[len];

                for (int i = 0; i < len; i++)
                {
                    arr[i] = random.Next(106);
                }

                int m = random.Next(50) + 1, res = 0;

                //m = 6;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => {
                    res = instance.Try(arr, m);
                });

                ShowTools.ShowMulti(new Dictionary<string, object> {
                        {nameof(m),m },
                        {nameof(res),res },
                        {nameof(codeTimerResult),codeTimerResult },
                        {nameof(arr),arr },

                    });

            }
        }
    }
}
