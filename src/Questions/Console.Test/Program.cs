using Command.CommonStruct;
using Command.Tools;
using Newtonsoft.Json;
using Questions.Easy.Algorithms;
using Questions.Hard.Deal;
using Questions.Middle.Deal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {

            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            SearchInsertPosition instance = new SearchInsertPosition();

            Console.WriteLine(instance.Solution2(new[] { 1,3,5,6},2));

            Console.WriteLine("success");

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
        }

        private static void TestMergeTwoSortedLists()
        {
            MergeTwoSortedLists instance = new MergeTwoSortedLists();

            Console.WriteLine(instance.Solution(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }));
        }
    }
}