using Command.Tools;
using Questions.Middle.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/27/2020 5:16:24 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class MiddleTest
    {

        private static void TestContainsNearbyAlmostDuplicate()
        {
            bool res = false;
            ContainsNearbyAlmostDuplicate instance = new ContainsNearbyAlmostDuplicate();

            //res =instance.Try2(new[] {1, 2, 3, 1}, 3, 0);

            //Console.WriteLine(res);

            //var data =  File.ReadAllText(@"G:\dick\git\DealLeetcode\data\txt\testArr.txt");

            //var arr = JsonConvert.DeserializeObject<int[]>(data);

            //res = instance.Try2(arr, 10000, 0);

            //Console.WriteLine(res);

            res = instance.Solution(new[] { -1, 2147483647 }, 1, 2147483647);

            Console.WriteLine(res);
        }

        private static void TestNumTilePossibilities(Random random)
        {
            NumTilePossibilities instance = new NumTilePossibilities();

            for (int i = 0; i < 1000; i++)
            {
                var len = random.Next(15) + 1;

                StringBuilder builder = new StringBuilder();

                for (int j = 0; j < len; j++)
                {
                    builder.Append((char)(random.Next(26) + 'A'));
                }

                var realRes = instance.SimpleTest(builder.ToString());

                var res = instance.Solution(builder.ToString());

                Console.WriteLine($" solution res : {res}");

                if (realRes != res) throw new Exception("find bug...");
            }

            //            var testArr = new []
            //            {
            //                "a","ab","aab","aaab","aabb","aabbb",
            //                "abc","aabc","aabbc","aabbcc"
            //                //"a",
            //                //"aa","ab",
            //                //"aaa","aab","abc",
            //                //"aaaa","aaab","aabb","aabc","abcd",
            //                //"aaaaa","aaaab","aaabb","aaabc","aabbc","aabcd","abcde",
            //                //"ab","aab","aabb","aaabb","aaabbb","aaaabbb",
            //                //"abcdefg"
            //            };
            //
            //            foreach (var item in testArr)
            //            {
            //                instance.SimpleTest(item);
            //                instance.Solution(item);
            //            }
        }

        private static void TestCoinChange(Random random)
        {
            CoinChange instance = new CoinChange();

            Console.WriteLine(instance.Solution(new[] { 186, 416, 83, 408 }, 6249)); //20
            Console.WriteLine(instance.Solution(new[] { 1, 2, 5 }, 11)); //3
            Console.WriteLine(instance.Solution(new[] { 2 }, 3)); //-1

            Console.ReadKey(true);

            for (int i = 0; i < 1000; i++)
            {
                var randNum = random.Next(20) + 10;

                var arr = new int[random.Next(5) + 1];

                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = random.Next(randNum) + 1;
                }

                var res = instance.Solution(arr, randNum);

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    {nameof(randNum), randNum},
                    {nameof(arr), arr},
                    {nameof(res), res}
                });
            }
        }

    }
}
