using Command.Tools;
using Newtonsoft.Json;
using Questions.Easy.Algorithms;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2020 4:51:59 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class EasyTest
    {


        private static void TestBestTimeToBuyAndSellStockII(Random random)
        {
            BestTimeToBuyAndSellStockII instance = new BestTimeToBuyAndSellStockII();

            Console.WriteLine(instance.Solution(new[] { 3, 2, 6, 5, 0, 3 }));

            for (int i = 0; i < 1000; i++)
            {
                var len = random.Next(100) + 10;
                var arr = new int[len];

                for (int j = 0; j < len; j++)
                {
                    arr[j] = random.Next(10);
                }

                var real = instance.Solution(arr);
                var res = instance.Solution2(arr);

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    {nameof(res),res },
                    {nameof(arr),arr }
                });

                if (real != res)
                    throw new Exception("bug");

            }
        }

        private static void TestPascal_sTriangleII()
        {
            Pascal_sTriangleII instance = new Pascal_sTriangleII();

            Console.WriteLine(instance.Solution(3));
        }

        private static void TestBalancedBinaryTree()
        {
            BalancedBinaryTree instance = new BalancedBinaryTree();

            var res = instance.Solution(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 });
            Console.WriteLine(res);
        }

        private static void Test4Sum(Random random)
        {
            _4Sum instance = new _4Sum();

            IList<IList<int>> test;

            //test = instance.Solution(new[] { 1, 0, -1, 0, -2, 2 }, 0);

            //Console.WriteLine(JsonConvert.SerializeObject(test));

            //test = instance.Solution(new[] { 1,-2,-5,-4,-3,3,3,5 }, -11);

            //Console.WriteLine(JsonConvert.SerializeObject(test));

            test = instance.Solution3(new[] { -5, -4, -3, -2, -1, 0, 0, 1, 2, 3, 4, 5 }, 0);

            Console.WriteLine(JsonConvert.SerializeObject(test));

            //test = instance.Solution3(new[] { -15, -14, -14, -13, -12, -11, -11, -9, -7, -6, -5, -5, -4, -3, -2, -1, -1, -1, -1, -1, 0, 2, 2, 2, 2, 2, 2, 4, 5, 5, 5, 5, 6, 7, 8, 8, 8, 10, 10, 10, 11, 12, 12, 13, 13, 14, 14, 15, 15, 15 }, 0);

            //Console.WriteLine(JsonConvert.SerializeObject(test));

            Console.ReadKey(true);

            for (int i = 0; i < 1; i++)
            {
                var len = 1000;
                var arr = new int[len];

                for (int j = 0; j < len; j++)
                {
                    arr[j] = random.Next(-15, 16);
                }

                IList<IList<int>> res = instance.Solution(arr, 0);

                ShowTools.ShowMulti(new Dictionary<string, object>() {

                    //{nameof(res),res },
                    {nameof(arr),arr }
                });

            }
        }

        private static void TestClimbingStairs()
        {
            ClimbingStairs instance = new ClimbingStairs();

            List<int> list = new List<int>();

            for (int i = 1; ; i++)
            {
                var res = instance.DpSolution(i);
                if (res < 0) break;
                list.Add(res);
            }

            Console.WriteLine(JsonConvert.SerializeObject(list));
        }

        private static void TestMaximumSubarray(Random random)
        {
            MaximumSubarray instance = new MaximumSubarray();

            List<int> list = new List<int>(new int[] { 1, 2, 3 });

            Console.WriteLine(instance.Simple(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 })); // 6
            Console.WriteLine(instance.Solution(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));// 6
            Console.WriteLine(instance.Simple(new[] { int.MinValue, -1, 1 })); // 1
            Console.WriteLine(instance.Solution(new[] { int.MinValue, -1, 1 }));// 1

            for (int i = 0; i < 1; i++)
            {
                int len = random.Next(100) + 100;
                int[] arr = new int[len];
                for (int j = 0; j < len; j++)
                {
                    arr[j] = random.Next(int.MinValue / len, int.MaxValue / len);
                }
                var res = instance.Solution(arr);

                ShowTools.ShowMulti(new Dictionary<string, object>() {

                    {nameof(res),res },
                    {nameof(arr),arr }
                });

            }
        }

        private static void TestSearchInsertPosition()
        {
            SearchInsertPosition instance = new SearchInsertPosition();

            Console.WriteLine(instance.Solution2(new[] { 1, 3, 5, 6 }, 2));
        }

        private static void TestMergeTwoSortedLists()
        {
            MergeTwoSortedLists instance = new MergeTwoSortedLists();

            Console.WriteLine(instance.Solution(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }));
        }

    }
}
