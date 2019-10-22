using System;
using System.Text;
using Command.Tools;
using Questions.Middle.Deal;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            TotalNQueens instance = new TotalNQueens();

            for (int i = 4; i < 11; i++)
            {
                var realRes = instance.SimpleSolution(i);
                var res = instance.Solution(i);
                if (res != realRes) throw new Exception("bug");
            }

            Console.WriteLine("test over~");

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
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
                    builder.Append((char) (random.Next(26) + 'A'));
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
    }
}