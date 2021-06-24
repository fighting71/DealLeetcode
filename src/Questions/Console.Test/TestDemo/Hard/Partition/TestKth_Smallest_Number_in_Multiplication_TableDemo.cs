using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2021 5:26:12 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestKth_Smallest_Number_in_Multiplication_TableDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Kth_Smallest_Number_in_Multiplication_Table instance = new Kth_Smallest_Number_in_Multiplication_Table();

            {
                //for (int i = 3; i < 100; i++)
                //{
                //    Console.WriteLine($"{i}:{instance.Try(10, 10, i + 1)}");
                //}

                int[][] table = instance.GetTable(10, 10);

                for (int i = 0; i < table.Length; i++)
                {
                    for (int j = 0; j < table[i].Length; j++)
                    {
                        Console.Write($"{table[i][j]}\t");
                    }
                    Console.WriteLine();
                }

                //int[] orderArr = table.SelectMany(u => u).OrderBy(u => u).ToArray();

                //for (int i = 0; i < orderArr.Length; i++)
                //{
                //    Console.WriteLine($"{i}:{orderArr[i]}");
                //}

                //Console.WriteLine(instance.Simple(10, 10, 45));

                //Console.WriteLine(instance.Simple(1195, 817, 675756));
            }

            //Console.WriteLine(instance.findKthNumber(1046, 1121, 1102508));

            BaseLibrary.CommonTest(new[] {
                    (3,3,5),
                    //(1046,1121,1102508)
                }, arg => instance.findKthNumber(arg.Item1, arg.Item2, arg.Item3)
            //, checkFunc: arg => instance.Try(arg.Item1, arg.Item2, arg.Item3)
            //, checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3)
            , generateArg: () =>
            {
                    //var maxLen = 30000;
                    //int range = 30000, min = 1;
                    int range = 10000, min = 20000;
                int m = random.Next(range) + min, n = random.Next(range) + min, k = random.Next(m * n) + 1;
                return (m, n, k);
            },
            codeTimeCount: 20
            );


        }
    }
}
