using Command.Tools;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/16/2020 5:21:23 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPatching_ArrayDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Patching_Array.Solution instance = new Patching_Array.Try3();
            if (runSimple)
            { // simple

                //var argArr = new[]
                //{
                //    ("[1,5,10]", 20),// 2
                //    ("[1,3]", 6), // 1
                //    ("[1,2,2]", 5),// 0
                //    ("[1]", 5),// 2
                //};

                //foreach (var item in argArr)
                //{
                //    ShowTools.Show(instance.Run(JsonConvert.DeserializeObject<int[]>(item.Item1), item.Item2));
                //}

                {

                    var try2 = new Patching_Array.Try();

                    //Console.WriteLine($"\n\n>>>>");
                    //try2.Run(new[] { 3 }, 5);
                    //Console.WriteLine($"\n\n>>>>");
                    //try2.Run(new[] { 4 }, 5);
                    //Console.WriteLine($"\n\n>>>>");
                    //try2.Run(new[] { 3, 4 }, 5);
                    //Console.WriteLine($"\n\n>>>>");
                    //try2.Run(new[] { 3, 3 }, 15);
                    //Console.WriteLine($"\n\n>>>>");
                    //try2.Run(new[] { 3, 3 }, 25);
                    //Console.WriteLine($"\n\n>>>>");
                    //try2.Run(new[] { 3, 3 }, 35);
                    //Console.WriteLine($"\n\n>>>>");

                    for (int i = 1; i < 100; i++)
                    {
                        Console.WriteLine($"\n\n>>>>i:{i}");
                        try2.Run(new int[0], i);
                    }

                }

            }
            else
            { // speed&real

                int res = 0;
                CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = instance.Run(new[] { 1 }, 10000);
                });

                ShowTools.ShowMulti(new Dictionary<string, object>()
                    {
                        { nameof(res),res },
                        { nameof(codeTimerResult),codeTimerResult },
                    });


            }
        }

    }
}
