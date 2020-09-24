using Command.CommonStruct;
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

            CodeTimerResult codeTimerResult;

            Exception bugEx = new Exception("bug");

            {
                {
                    MaxPointsOnALine instance = new MaxPointsOnALine();

                    {



                        //            Console.WriteLine(instance.Simple(new[]{
                        //    new []{1, 1},
                        //    new []{2, 2},
                        //    new []{3, 3}
                        //}));


                        Console.WriteLine(instance.Try(JsonConvert.DeserializeObject<int[][]>("[[29,89],[57,57],[96,66],[92,76],[26,5],[76,55],[51,52],[52,93],[16,51],[6,40],[60,64],[38,19],[32,28],[8,26],[27,29],[31,5],[5,46],[92,71],[94,96],[38,63],[85,4],[99,29],[92,14],[35,68],[70,23],[56,47],[21,64],[67,65],[50,38],[24,68],[58,65],[49,96],[73,70],[50,5],[59,80],[99,20],[12,43],[55,55],[65,8],[26,18],[92,40],[56,3],[73,84],[84,40],[79,27],[21,56],[71,70],[5,19],[55,2],[56,21],[64,30],[8,90],[24,35],[34,77],[9,11],[99,41],[11,6],[75,17],[9,45],[23,88],[86,9],[25,32],[59,42],[49,42],[37,35],[99,63],[52,4],[53,62],[31,66],[79,38],[49,6],[31,68],[27,79],[44,64],[95,87],[10,10],[79,67],[35,54],[5,76],[31,81],[85,92],[40,73],[11,36],[89,6],[53,12],[86,42],[65,85],[38,79],[78,57],[4,79],[97,85],[47,49],[25,89],[83,84],[69,99],[56,54],[35,98],[52,57],[66,57],[56,91],[90,38],[10,82],[1,67],[44,94],[28,56],[75,47],[72,51],[83,0],[45,90],[47,22],[52,4],[37,54],[56,32],[7,67],[33,81],[12,21],[1,12],[89,59],[74,64],[48,57],[44,89],[55,12],[23,9],[81,83],[15,51],[12,76],[9,33],[38,85],[1,56],[26,68],[60,77],[60,47],[43,54],[46,60],[62,23],[26,80],[41,90],[77,62],[48,24],[30,47],[51,23],[51,81],[68,36],[11,67],[73,3],[58,17],[38,79],[97,67],[28,8],[68,68],[62,21],[21,91],[25,32],[34,19],[55,75],[36,76],[26,79],[17,36],[25,79],[78,7],[42,79],[86,58],[65,8],[41,61],[92,10],[34,40],[55,61],[84,29],[2,60],[55,35],[1,92],[11,97],[67,81],[91,59],[62,60],[41,49],[29,61],[25,83],[34,62],[25,16],[91,72],[26,45],[41,96],[20,64],[94,87],[34,65],[23,43],[5,50],[67,88],[91,83],[17,81],[99,31],[69,84],[10,94],[35,1],[95,39],[34,38],[44,29],[65,66],[56,71],[61,26],[65,74],[25,75],[25,86],[55,75],[15,46],[71,41],[99,9],[72,95],[75,57],[85,26],[28,92],[92,95],[31,84],[98,75],[85,0],[32,20],[22,90],[16,25],[6,94],[59,24]]")));
                        //            Console.WriteLine(instance.Simple(JsonConvert.DeserializeObject<int[][]>("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]")));

                        //            Console.WriteLine(instance.Simple(JsonConvert.DeserializeObject<int[][]>("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]")));

                    }

                    for (int i = 0; i < 1; i++)
                    {
                        break;
                        var len =500;

                        var arr = new int[len][];

                        for (int j = 0; j < len; j++)
                        {
                            arr[j] = new[] { random.Next(100), random.Next(100) };
                        }

                        var res = instance.Try(arr);

                        ShowTools.ShowMulti(new Dictionary<string, object>() {
                    {nameof(res),res },
                    {nameof(arr),arr }
                });

                        //if(res != instance.Simple(arr))
                        //{
                        //    throw bugEx;
                        //}

                    }
                }

            }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

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