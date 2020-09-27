using Command.CommonStruct;
using Command.CusStruct;
using Command.Tools;
using ConsoleTest.LargeData;
using ConsoleTest.TestDemo;
using ConsoleTest.TestDemo.Hard;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020September.Week4;
using Questions.Easy.Algorithms;
using Questions.Hard.Deal;
using Questions.Middle.Deal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            Exception bugEx = new Exception("bug");

            bool runSimple = true;
            //runSimple = false;
            {

                {


                    IList<IList<string>>[] equationsArr = new[] {
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"b\"],[\"e\",\"f\"],[\"b\",\"e\"]]"), // [0.29412,10.94800,1.00000,1.00000,-1.00000,-1.00000,0.71429]
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"b\"],[\"b\",\"c\"],[\"bc\",\"cd\"]]"),
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"b\"],[\"b\",\"c\"]]"),
                    };

                    double[][] valuesArr = new[]
                    {
                        new[] { 3.4,1.4,2.3 },
                        new[] { 1.5, 2.5, 5.0 },
                        new[] { 2.0, 3.0 },
                    };

                    IList<IList<string>>[] queriesArr = new[] {
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"b\",\"a\"],[\"a\",\"f\"],[\"f\",\"f\"],[\"e\",\"e\"],[\"c\",\"c\"],[\"a\",\"c\"],[\"f\",\"e\"]]"),
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"c\"],[\"c\",\"b\"],[\"bc\",\"cd\"],[\"cd\",\"bc\"]]"),
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"c\"],[\"b\",\"a\"],[\"a\",\"e\"],[\"a\",\"a\"],[\"x\",\"x\"]]"),
                    };

                    for (int i = 0; i < equationsArr.Length; i++)
                    {
                        if (!runSimple) break;
                        var res = new Evaluate_Division().Try(equationsArr[i], valuesArr[i], queriesArr[i]);
                        ShowTools.ShowLine(res);

                    }

                }

                {
                    CodeTimerResult codeTimerResult;

                }

            }

            {

                { // simple

                }

                { // speed&real
                    CodeTimerResult codeTimerResult;

                }

            }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        private static void TestLargestNumber(CodeTimer codeTimer)
        {
            CodeTimerResult codeTimerResult;

            {
                string res;
                {
                    res = new Largest_Number().LargestNumber(new[] { 3, 30, 34, 5, 9 });

                    ShowTools.Show(res);

                }
                {

                    for (int i = 0; i < 2; i++)
                    {
                        codeTimerResult = codeTimer.Time(1, () =>
                        {
                            res = new Largest_Number().LargestNumber(LargeArray.Arr);
                        });

                        ShowTools.Show(res);

                        ShowTools.Show(codeTimerResult);
                    }


                }
            }

        }

        private static void TestBurst_Balloons()
        {
            Burst_Balloons instance = new Burst_Balloons();

            //[3,1,5,8,1,5] 350

            //Console.WriteLine(instance.Try(new[] { 3, 1, 5, 8 }));// 167 
            Console.WriteLine(instance.Try(new[] { 3, 1, 5, 8, 1, 5 }));// out 315 expected 350 
            Console.WriteLine(instance.Try(new[] { 3, 1, 8, 5, 1, 5 }));// out 315 expected 350 
        }

        private static void TestRemove_Invalid_Parentheses()
        {
            Remove_Invalid_Parentheses instnace = new Remove_Invalid_Parentheses();

            ShowTools.Show(instnace.Optimize("(r(()()("));// ["r()()","r(())","(r)()","(r())"]
            ShowTools.Show(instnace.Optimize("()((k()(("));// ["()k()","()(k)"]
            //ShowTools.Show(instnace.Optimize("a()())()()())())())()()())()"));
            ShowTools.Show(instnace.Optimize("()())()"));// ["()()()", "(())()"]
            ShowTools.Show(instnace.Optimize("(a)())()"));// ["(a)()()", "(a())()"]
            ShowTools.Show(instnace.Optimize(")("));// [""]
        }

        private static void TestFind_Median_from_Data_Stream()
        {
            //[[],[6],[],[10],[],[2],[],[6],[],[5],[],[0],[],[6],[],[3],[],[1],[],[0],[],[0],[]]
            Find_Median_from_Data_Stream instance = new Find_Median_from_Data_Stream();

            instance.AddNum(12);
            instance.AddNum(10);
            instance.AddNum(13);
            instance.AddNum(11);
            instance.AddNum(5);
            instance.AddNum(15);
            instance.AddNum(1);
            instance.AddNum(11);
            instance.AddNum(6);
            instance.AddNum(17);
            instance.AddNum(14);
            instance.AddNum(8);
            instance.AddNum(17);
            instance.AddNum(6);
            instance.AddNum(4);
            instance.AddNum(16);
            instance.AddNum(8);
            instance.AddNum(10);
            instance.AddNum(2);
            instance.AddNum(12);
            //instance.AddNum(0);
            Console.WriteLine(instance.FindMedian());
        }

        private static void TestExpression_Add_Operators()
        {
            Expression_Add_Operators instance = new Expression_Add_Operators();

            ShowTools.Show(instance.Simple("232", 8));
        }

        private static void TestSliding_Window_Maximum()
        {
            Sliding_Window_Maximum instance = new Sliding_Window_Maximum();

            ShowTools.Show(instance.Simple(new[] { 1 }, 1));
            ShowTools.Show(instance.Simple(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3));
        }

        private static void TestBasic_Calculator()
        {
            Basic_Calculator instance = new Basic_Calculator();

            //Console.WriteLine(instance.Solution("1 + 1")); // 2
            //Console.WriteLine(instance.Solution(" 2-1 + 2 "));// 3
            //Console.WriteLine(instance.Solution("(1+(4+5+2)-3)+(6+8)"));// 23
            //Console.WriteLine(instance.Solution("1 - (2 + 3 + (1 + 2))"));// -7
        }

        private static void TestShortestPalindrome(Random random)
        {
            ShortestPalindrome instance = new ShortestPalindrome();

            //instance.IsDebug = true;

            ShowTools.ShowIndex("bbacabbacabbabbcacabcabcccccaaaabccba");

            Console.WriteLine(instance.Simple("bbacabbacabbabbcacabcabcccccaaaabccba"));
            Console.WriteLine(instance.Solution("bbacabbacabbabbcacabcabcccccaaaabccba"));

            Console.WriteLine(instance.Simple("cabcbacbacaccaaaacacaabcba"));
            Console.WriteLine(instance.Solution("cabcbacbacaccaaaacacaabcba"));

            Console.WriteLine(instance.Simple("cacbcccbcbcacaacbccabcbaacabbbcbbaccbbc"));
            Console.WriteLine(instance.Solution("cacbcccbcbcacaacbccabcbaacabbbcbbaccbbc"));

            Console.WriteLine(instance.Simple("bcbbbcccaabbbcaaaba"));
            Console.WriteLine(instance.Solution("bcbbbcccaabbbcaaaba"));

            Console.WriteLine(instance.Simple("aaaacdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            Console.WriteLine(instance.Solution("aaaacdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));

            Console.WriteLine(instance.Simple("aabba"));
            Console.WriteLine(instance.Solution("aabba"));

            Console.WriteLine(instance.Simple("aacecaaa"));
            Console.WriteLine(instance.Solution("aacecaaa"));

            Console.WriteLine(instance.Simple("abcd"));
            Console.WriteLine(instance.Solution("abcd"));
            Console.ReadKey(true);
            for (int i = 0; i < 100000; i++)
            {
                StringBuilder builder = new StringBuilder();

                var len = random.Next(40000);

                for (int j = 0; j < len; j++)
                {
                    builder.Append((char)('a' + random.Next(3)));
                }

                var real = instance.Simple(builder.ToString());
                var res = instance.Solution(builder.ToString());

                ShowTools.ShowMulti(new System.Collections.Generic.Dictionary<string, object>() {
                    {nameof(builder),builder },
                    {nameof(real),real },
                    {nameof(res),res },
                });

                if (real != res) throw new Exception();

            }
        }

        private static void TestWordSearchII()
        {
            WordSearchII instance = new WordSearchII();

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['a','b'],['a','a']]")
                , new[] { "aba", "baa", "bab", "aaab", "aaa", "aaaa", "aaba" }));

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['b','b','a','a','b','a'],['b','b','a','b','a','a'],['b','b','b','b','b','b'],['a','a','a','b','a','a'],['a','b','a','a','b','b']]")
                , new[] { "abbbababaa" }));

            Console.WriteLine("success");
        }

        private static void TestDungeon_Game(Random random)
        {
            Dungeon_Game instance = new Dungeon_Game();

            instance.IsDebug = true;

            //Console.WriteLine(instance.Solution(JsonConvert.DeserializeObject<int[][]>("[[2,-7,-8,-16,-19,-19,-12,-19,-20,-27,-21,-16,-8,-12],[-3,-9,0,-9,-1,-6,-3,-13,-23,-16,-22,-14,-20,-20],[-5,-3,-10,-12,-6,-10,-6,-15,-14,-5,3,0,-7,-16],[1,-1,4,-3,4,7,16,6,8,-2,-7,-9,-4,-3],[-8,0,11,9,5,4,21,28,21,20,19,20,28,21],[-5,8,3,9,0,5,15,30,22,13,9,20,28,25],[-15,17,9,3,6,12,5,39,31,30,20,26,24,34],[-20,12,15,10,15,20,17,42,49,53,43,35,32,33]]")));// 7

            //Console.WriteLine(instance.Solution(JsonConvert.DeserializeObject<int[][]>("[[3,5,5,11,19,19,23,16,9,-1,1],[-6,5,2,8,17,23,15,24,26,35,38],[-4,0,5,3,12,15,14,25,35,40,45],[-4,7,13,7,10,7,16,26,39,45,53],[4,7,16,3,19,24,15,33,42,53,48],[13,16,11,3,21,19,20,36,43,44,55],[8,6,11,9,25,21,30,32,33,38,62],[11,2,4,11,33,26,34,34,25,30,69],[5,9,12,10,28,28,30,43,33,26,76],[-4,3,15,21,28,18,34,51,47,54,67],[-12,-2,23,32,37,33,32,60,51,44,72],[-14,3,25,31,32,23,31,69,59,52,75]]")));// 1

            //Console.WriteLine(instance.Solution(new[] {
            //    new []{ -2, -3, 3 },
            //     new []{ -5,-10,1 },
            //      new []{ 10,30,-5 },
            //}));// 7

            Console.WriteLine(instance.DpSolution3(JsonConvert.DeserializeObject<int[][]>("[[-2,-3,3],[-5,-10,1],[10,30,-5]]")));// 3

            Console.ReadKey(true);

            for (int i = 0; i < 10; i++)
            {
                int m = random.Next(200) + 2, n = random.Next(200) + 4;

                int[][] dungeon = new int[m][];
                for (int j = 0; j < m; j++)
                {
                    dungeon[j] = new int[n];
                    for (int k = 0; k < n; k++)
                    {
                        dungeon[j][k] = random.Next(-20, 5);
                    }
                }

                ShowTools.Show(dungeon);

                var res = instance.Solution((int[][])dungeon.Clone());

                ShowTools.ShowMulti(new System.Collections.Generic.Dictionary<string, object>() {
                    {nameof(res),res }
                });

            }
        }
    }
}