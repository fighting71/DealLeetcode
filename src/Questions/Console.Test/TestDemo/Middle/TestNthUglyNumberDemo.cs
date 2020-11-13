using Command.Tools;
using Questions.Middle.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Middle
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/12/2020 5:46:50 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestNthUglyNumberDemo : BaseDemo, IWork
    {
        public void Run()
        {
            NthUglyNumber instance = new NthUglyNumber();
            { // simple

                //var argArr = new[]
                //{
                //    (1000000000 + 1, 2, 430081563, 604870735),// 1999999992
                //    (1000000000, 2, 430081563, 604870735),// 1999999992
                //    (1000000000 - 1, 2, 430081563, 604870735),// 1999999992
                //    (1000000000, 2, 217983653, 336916467),// 1999999984
                //    (3, 2, 3, 5), //4
                //    (4, 2, 3, 4),// 6
                //};

                //foreach (var item in argArr)
                //{
                //    ShowTools.Show(instance.Try(item.Item1, item.Item2, item.Item3, item.Item4));
                //}

                ShowTools.Show(instance.Try(907306106, 2, 430081563, 604870735));
                ShowTools.Show(instance.Try(907306105, 2, 430081563, 604870735));
                int prev = int.MaxValue - 1;
                for (int i = 907306105; i <= 1000_000_000; i++)
                {
                    int res = instance.Try(i, 2, 430081563, 604870735);
                    //Console.WriteLine($"{i}-{res}");
                    for (int j = prev + 1; j < res; j++)
                    {
                        if (j % 2 == 0 || j % 430081563 == 0 || j % 604870735 == 0)
                        {
                            Console.WriteLine($"bug:{i}-{res}");
                            Console.ReadKey(true);
                        }
                    }
                    prev = res;
                }

                /**
                 * bug点：
                 * 907306106
1814612205
1814612206
                 */

                //ShowTools.Show(instance.Try(19, 2, 3, 5));

                //for (int i = 1; i < 100; i++)
                //{
                //    var res = instance.Try(i, 2, 3, 5);
                //    var simple = instance.Simple(i, 2, 3, 5);

                //    Console.WriteLine($"{i}-{res}-{simple}");

                //    if (res != simple)
                //    {
                //        throw bugEx;
                //    }

                //}

            }
            { // speed&real
            }
        }

    }
}
