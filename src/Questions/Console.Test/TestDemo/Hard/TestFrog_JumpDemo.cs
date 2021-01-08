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
    /// @since : 1/7/2021 4:41:09 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFrog_JumpDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Frog_Jump instance = new Frog_Jump();
            if (runSimple)
            {

                var argArr = new[]
                {
                        "[0,1,3,5,6,8,12,17]",
                        "[0,1,2,3,4,8,9,11]",
                        "[0,1,2,3,5,8,9,11]",
                    };

                foreach (var arg in argArr)
                {
                    var arr = JsonConvert.DeserializeObject<int[]>(arg);
                    Console.WriteLine(instance.CanCross(arr));
                    //Console.WriteLine(instance.Simple(arr));
                    ShowTools.ShowHr();
                }

            }
            //else

            for (int k = 0; k < 10; k++)
            {

                var len = 2000;

                var arr = new int[len];

                arr[0] = 0;
                arr[1] = 1;

                for (int i = 2; i < len; i++)
                {
                    //arr[i] = arr[i - 1] + random.Next(i / 2) + 1;
                    arr[i] = arr[i - 1] + 1;
                }

                bool res = false;
                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { res = instance.CanCross(arr); });

                ShowTools.Show(codeTimerResult);
                if (res)
                    ShowTools.Show(arr);
            }
        }
    }
}
