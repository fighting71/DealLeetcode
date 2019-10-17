using System;
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

            NumTilePossibilities instance = new NumTilePossibilities();

            var testArr = new []
            {
                "aa","aab","aabb","aaabb","aabbc","aaabbb"
                //"a",
                //"aa","ab",
                //"aaa","aab","abc",
                //"aaaa","aaab","aabb","aabc","abcd",
                //"aaaaa","aaaab","aaabb","aaabc","aabbc","aabcd","abcde",
                //"ab","aab","aabb","aaabb","aaabbb","aaaabbb",
                //"abcdefg"
            };

            foreach (var item in testArr)
            {
                instance.SimpleTest(item);
            }
            
            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
        }
    }
}