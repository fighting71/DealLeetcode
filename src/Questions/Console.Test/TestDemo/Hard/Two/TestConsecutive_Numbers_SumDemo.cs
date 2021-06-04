using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/4/2021 4:22:48 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestConsecutive_Numbers_SumDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Consecutive_Numbers_Sum instance = new Consecutive_Numbers_Sum();


            //for (int i = 1; i < 100; i++)
            //{
            //    int res = instance.Simple(i);

            //    Console.WriteLine($"{i}:{res}\n");
            //}
            //Console.WriteLine(instance.Simple(1000_000_000 - 1));
            //Console.WriteLine(instance.Simple(1000_000_000));

            BaseLibrary.CommonTest(new[] {
                    4,
                    15
                }, instance.Try
            , () => random.Next(1000_000_000) + 1
            , checkFunc: instance.Simple
            );

        }
    }
}
