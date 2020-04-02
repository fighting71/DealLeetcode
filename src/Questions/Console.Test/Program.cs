using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal;
using System;

namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {

            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            WordSearchII instance = new WordSearchII();

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['a','b'],['a','a']]")
                , new[] { "aba", "baa", "bab", "aaab", "aaa", "aaaa", "aaba" }));

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['b','b','a','a','b','a'],['b','b','a','b','a','a'],['b','b','b','b','b','b'],['a','a','a','b','a','a'],['a','b','a','a','b','b']]")
                , new[] { "abbbababaa" }));

            Console.WriteLine("success");

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
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