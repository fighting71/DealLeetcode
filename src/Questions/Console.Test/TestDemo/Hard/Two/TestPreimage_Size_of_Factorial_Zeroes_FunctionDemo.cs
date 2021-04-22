using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/21/2021 4:40:40 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPreimage_Size_of_Factorial_Zeroes_FunctionDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Preimage_Size_of_Factorial_Zeroes_Function instance = new Preimage_Size_of_Factorial_Zeroes_Function();

            //{ // util test
            //    var num = 25;

            //    int twoCount = 0;

            //    for (int i = 0; i < 1000; i++)
            //    {
            //        int count = GetNum(num);
            //        if (count == 2)
            //        {
            //            twoCount++;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"twoCount:{twoCount},{i + 1}:{count}");
            //            twoCount = 0;
            //        }
            //        //Console.WriteLine($"{i + 1}:{count}");
            //        num += 25;
            //    }

            //    int GetNum(int num)
            //    {
            //        int res = 0;
            //        while (num % 10 == 0)
            //        {
            //            res++;
            //            num /= 10;
            //        }

            //        while (num % 5 == 0)
            //        {
            //            res++;
            //            num /= 5;
            //        }
            //        return res;
            //    }
            //}

            { // base case
              //Console.WriteLine(instance.Try2(1000_000_000));
              //var rand = random.Next(1000_000_000);
              //Console.WriteLine(rand + ":" + instance.Try2(random.Next(rand)));

                //for (int i = 0; i < 200; i++)
                //{
                //    int res = instance.Try4(i);
                //    if(res == 0)
                //        Console.WriteLine($"{i}:{res}");
                //}

                //for (int i = 0; i < 31; i++)
                //{
                //    Console.WriteLine($"{i}:{GetMul(i)}");
                //}

                //long GetMul(int num)
                //{
                //    long res = 1;
                //    for (int i = 2; i <= num; i++)
                //    {
                //        res *= i;
                //    }
                //    return res;
                //}

                //Dictionary<int, int> dic = new Dictionary<int, int>();
                //List<int> list = new List<int>();

                //// 1111211112
                //while (true)
                //{
                //    list.Add(2);
                //}

            }
            var arg = Enumerable.Range(0, 1000_0).ToArray();
            var i = 0;
            BaseLibrary.CommonTest(new[] {
                    6, // 5
                    155, // 0
                    25,
                    2345, // 5
                    //903532525 5
                }, instance.Solution
            , () => random.Next(1000_000_000)
            //, () => { return arg[i++]; }
            //, () => random.Next(1000_0)
            //, checkFunc: instance.Try5
            , codeTimeCount: 100
            );

        }

    }
}
