using Command.CommonStruct;
using Command.Tools;
using Newtonsoft.Json;
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

            Console.WriteLine("success");

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
        }

        private static void TestFindMinimumInRotatedSortedArrayII(CodeTimer codeTimer, Random random)
        {
            FindMinimumInRotatedSortedArrayII instance = new FindMinimumInRotatedSortedArrayII();

            for (int i = 0; i < 1024; i++)
            {
                var len = random.Next(10000) + 10;
                //var arr = Enumerable.Range(0, len).ToArray();

                var rotatedArr = new int[len];

                var rotated = random.Next(len);

                rotatedArr[rotated] = random.Next(10) + rotated;

                for (int j = rotated + 1; j < len; j++)
                {
                    rotatedArr[j] = rotatedArr[j - 1] + random.Next(3);
                }

                rotatedArr[0] = rotatedArr[len - 1] + random.Next(3);

                for (int j = 1; j < rotated; j++)
                {
                    rotatedArr[j] = rotatedArr[j - 1] + random.Next(3);
                }

                //Array.Copy(arr, rotated, rotatedArr, 0, len - rotated);
                //Array.Copy(arr, 0, rotatedArr, len - rotated, rotated);

                CodeTimerResult timerResult, timerResult2;
                int real = 0, res = 0;

                timerResult = codeTimer.Time(1, () => { real = instance.Simple(rotatedArr); });
                timerResult2 = codeTimer.Time(1, () => { res = instance.Solution(rotatedArr); });

                ShowTools.ShowMulti(new Dictionary<string, object>() {

                    {nameof(rotatedArr),rotatedArr },
                    {nameof(real),real },
                    {nameof(timerResult),timerResult },
                    {nameof(res),res },
                    {nameof(timerResult2),timerResult2 }
                });

                if (res != real) throw new Exception();

            }
        }

        private static void TestMaxPointsOnALine(Random random)
        {
            MaxPointsOnALine instance = new MaxPointsOnALine();

            Console.WriteLine(instance.Simple(new[]{
                new []{1, 1},
                new []{2, 2},
                new []{3, 3}
            }));


            Console.WriteLine(instance.Simple(JsonConvert.DeserializeObject<int[][]>("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]")));

            Console.WriteLine(instance.Simple(JsonConvert.DeserializeObject<int[][]>("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]")));

            for (int i = 0; i < 10; i++)
            {

                var len = random.Next(1000);

                var arr = new int[len][];

                for (int j = 0; j < len; j++)
                {
                    arr[j] = new[] { random.Next(100), random.Next(100) };
                }

                var res = instance.Simple(arr);

                ShowTools.ShowMulti(new Dictionary<string, object>() {
                    {nameof(res),res },
                    {nameof(arr),arr }
                });

            }
        }

        private static void TestWordBreakII()
        {
            WordBreakII instance = new WordBreakII();

            ShowTools.ShowLine(instance.OtherSolution("catsanddog", new List<string>()
            {
                "cat", "cats", "and", "sand", "dog"
            }));

            ShowTools.ShowLine(instance.Simple("pineapplepenapple", new List<string>()
            {
                "apple", "pen", "applepen", "pine", "pineapple"
            }));

            ShowTools.ShowLine(instance.Simple("catsandog", new List<string>()
            {
                "cats", "dog", "sand", "and", "cat"
            }));
        }

        private static void TestCandy(CodeTimer codeTimer, Random random)
        {
            Candy instance = new Candy();

            Console.WriteLine(instance.Solution(new[] { 3, 4, 3, 4, 4, 2, 3, 2, 4, 0, 1, 2, 4, 3, 1, 0, 4, 0, 3, 1, 1, 1, 4, 0, 0, 2, 3, 2, 3, 3, 0, 3, 4, 2, 2, 0, 0, 2, 2, 0, 0, 3, 4, 1, 0, 3, 2, 1, 4, 1, 3, 0, 3, 0, 2, 2, 4, 2, 3, 1, 3, 1, 3, 1, 0, 3, 2, 2, 0, 1, 4, 1, 2 }));// 124
            Console.WriteLine(instance.Fast(new[] { 3, 4, 3, 4, 4, 2, 3, 2, 4, 0, 1, 2, 4, 3, 1, 0, 4, 0, 3, 1, 1, 1, 4, 0, 0, 2, 3, 2, 3, 3, 0, 3, 4, 2, 2, 0, 0, 2, 2, 0, 0, 3, 4, 1, 0, 3, 2, 1, 4, 1, 3, 0, 3, 0, 2, 2, 4, 2, 3, 1, 3, 1, 3, 1, 0, 3, 2, 2, 0, 1, 4, 1, 2 }));// 124

            Console.WriteLine(instance.Solution(new[] { 1, 2, 3 }));// 6
            Console.WriteLine(instance.Fast(new[] { 1, 2, 3 }));// 6

            Console.WriteLine(instance.Solution(new[] { 1, 6, 10, 8, 7, 3, 2 }));// 18
            Console.WriteLine(instance.Fast(new[] { 1, 6, 10, 8, 7, 3, 2 }));// 18

            Console.WriteLine(instance.Solution(new[] { 0, 3, 2, 4, 4, 4, 4, 2, 1, 2, 1, 1, 4, 0 }));// 21
            Console.WriteLine(instance.Fast(new[] { 0, 3, 2, 4, 4, 4, 4, 2, 1, 2, 1, 1, 4, 0 }));// 21

            Console.WriteLine(instance.Fast(new[] { 1, 0, 2 }));// 5
            Console.WriteLine(instance.Fast(new[] { 1, 2, 2 }));// 4
            Console.ReadKey();

            for (int i = 0; i < 1000; i++)
            {
                var len = random.Next(60) + 20;
                var arr = new int[len];
                for (int j = 0; j < len; j++)
                {
                    arr[j] = random.Next(5);
                }
                int real = 0, res = 0;
                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { real = instance.Simple(arr); });
                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () => { res = instance.Fast(arr); });

                Console.WriteLine($@"res:{res}
arr:[{string.Join(',', arr)}]
codeTimerResult:{codeTimerResult}
codeTimerResult2:{codeTimerResult2}
");

                if (res != real) throw new Exception();

            }
        }

        private static void TestBestTimeToBuyAndSellStockIII(CodeTimer codeTimer, Random random)
        {
            BestTimeToBuyAndSellStockIII instance = new BestTimeToBuyAndSellStockIII();

            Console.WriteLine(instance.Simple(new[] { 2, 1, 4 }));// 3
            Console.WriteLine(instance.Simple(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }));// 6
            Console.WriteLine(instance.Simple(new[] { 1, 2, 3, 4, 5 }));// 4


            Console.WriteLine(instance.Solution(new[] { 2, 1, 4 }));// 3
            Console.WriteLine(instance.Solution(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }));// 6
            Console.WriteLine(instance.Solution(new[] { 1, 2, 3, 4, 5 }));// 4

            for (int i = 0; i < 10000; i++)
            {
                var len = random.Next(10) + 2;
                var arr = new int[len];

                for (int j = 0; j < len; j++)
                {
                    arr[j] = random.Next(10);
                }

                int real = 0, res = 0;

                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { real = instance.Simple(arr); });

                CodeTimerResult codeTimerResult2 = codeTimer.Time(1, () => { res = instance.Solution(arr); });

                ShowTools.ShowMulti(new Dictionary<string, object>() {
                    { nameof(res),res},
                    { nameof(arr),arr},
                    { nameof(codeTimerResult),codeTimerResult},
                    { nameof(codeTimerResult2),codeTimerResult2}
                });

                if (real != res)
                    throw new Exception("test error");

            }
        }

        private static void TestDistinctSubsequences(Random random)
        {
            DistinctSubsequences instance = new DistinctSubsequences();

            Console.WriteLine(instance.DPSolution("aabb", "abb"));// 2
            Console.WriteLine(instance.DPSolution3("aabb", "abb"));// 2
            Console.WriteLine(instance.RecursionSolution("aabb", "abb"));// 2

            Console.WriteLine(instance.DPSolution("babgbag", "bag"));// 5
            Console.WriteLine(instance.DPSolution3("babgbag", "bag"));// 5
            Console.WriteLine(instance.RecursionSolution("babgbag", "bag"));// 5

            Console.WriteLine(instance.DPSolution("rabbbit", "rabbit"));// 3
            Console.WriteLine(instance.DPSolution3("rabbbit", "rabbit"));// 3
            Console.WriteLine(instance.RecursionSolution("rabbbit", "rabbit"));// 3

            Console.ReadKey();

            for (int i = 0; i < 10000; i++)
            {
                int len = random.Next(4) + 2, len2 = random.Next(len) + 12;

                StringBuilder builder = new StringBuilder(), builder2 = new StringBuilder();

                for (int j = 0; j < len2; j++)
                {
                    builder.Append((char)('a' + random.Next(3)));
                    if (j < len) builder2.Append((char)('a' + random.Next(3)));
                }

                string s = builder.ToString(), s2 = builder2.ToString();

                int dp = instance.DPSolution2(s, s2), real = instance.RecursionSolution(s, s2);

                if (real != dp) throw new Exception($"\"{s2}\"，\"{s}\"");
                if (real > 0)
                {
                    Console.WriteLine($"s:{s2},t:{s},res:{real}");
                }

            }
        }

        private static void TestRecoverBinarySearchTree()
        {
            RecoverBinarySearchTree instance = new RecoverBinarySearchTree();

            TreeNode root;

            root = new int?[] { 1, 2, null, 4, 3 };

            instance.Solution(root);

            Console.WriteLine(root); // [4,2,null,1,3]

            root = new int?[] { 146, 71, -13, 55, null, 231, 399, 321, null, null, null, null, null, -33 };

            instance.Solution(root);

            Console.WriteLine(root); // [146,71,321,55,null,231,399,-13,null,null,null,null,null,-33]

            root = new TreeNode(3, null, new TreeNode(2, null, 1));

            instance.Solution(root);

            Console.WriteLine(root);// [1,null,2,null,3]

            root = new TreeNode(2, 3, 1);

            instance.Solution(root);

            Console.WriteLine(root);// [2,1,3]

            root = new TreeNode(1, new TreeNode(3, null, 2), null);

            instance.Solution(root);

            Console.WriteLine(root);// [3,1,null,null,2]

            root = new TreeNode(3, 1, new TreeNode(4, 2, null));

            instance.Solution(root);

            Console.WriteLine(root);// [2,1,4,null,null,3]
        }

        private static void TestInterleavingString(Random random)
        {
            InterleavingString instance = new InterleavingString();

            //Console.WriteLine(instance.Simple("aabcc", "dbbca", "aadbbcbcac"));
            //Console.WriteLine(instance.Simple("aabcc",  "dbbca", "aadbbbaccc"));

            Console.WriteLine(instance.DpSolution("aabcc", "dbbca", "aadbbcbcac"));
            Console.WriteLine(instance.DpSolution("aabcc", "dbbca", "aadbbbaccc"));

            for (int i = 0; i < 1000; i++)
            {
                int len = random.Next(5) + 2, len2 = random.Next(len - 1) + 1, len3 = len - len2;

                StringBuilder builder = new StringBuilder(), builder2 = new StringBuilder(), builder3 = new StringBuilder();

                for (int j = 0; j < len; j++)
                {
                    builder.Append((char)('a' + random.Next(5)));
                    if (j < len2) builder2.Append((char)('a' + random.Next(4)));
                    if (j < len3) builder3.Append((char)('a' + random.Next(4)));
                }

                string s = builder.ToString(), s2 = builder2.ToString(), s3 = builder3.ToString();

                var real = instance.Simple(s2, s3, s);
                var dp = instance.DpSolution(s2, s3, s);

                if (real != dp) throw new Exception($"\"{s2}\"，\"{s3}\"，\"{s}\"");

                if (real)
                    Console.WriteLine(real);

            }
        }

        private static void TestMaximalRectangle()
        {
            MaximalRectangle instance = new MaximalRectangle();

            Console.WriteLine(instance.Solution(new[] {
              new []{'1','0','1','0','0'},
              new []{'1','0','1','1','1'},
              new []{'1','1','1','1','1'},
              new []{'1','0','0','1','0'}
            }));
        }

        private static void TestEditDistance()
        {
            EditDistance instance = new EditDistance();

            Console.WriteLine(instance.Recursion("horse", "ros"));// 3
            Console.WriteLine(instance.Recursion("intention", "execution"));// 5

            Console.WriteLine(instance.DpSolution("horse", "ros"));// 3
            Console.WriteLine(instance.DpSolution("intention", "execution"));// 5

            Console.WriteLine(instance.DpSolution("dinitrophenylhydrazine", "acetylphenylhydrazine"));// 6
        }

        private static void TestInsertInterval()
        {
            InsertInterval instance = new InsertInterval();

            var res = instance.Solution(new[]
            {
                new []{ 1, 3 },
                new []{ 6,9 },
            },
            new[] { 2, 5 });

            ShowTools.ShowMatrix(res);

            ShowTools.ShowMatrix(instance.Solution(new[]
            {
                new []{1,2},
                new []{3,5},
                new []{6,7},
                new []{8,10},
                new []{12,16}
            },
            new[] { 4, 8 }));

            ShowTools.ShowMatrix(instance.Solution(new int[0][],
            new[] { 5, 7 }));
        }

        private static void TestSolveNQueens()
        {
            SolveNQueens instance = new SolveNQueens();
            TotalNQueens instance2 = new TotalNQueens();

            for (int i = 4; i < 11; i++)
            {
                var realRes = instance2.Solution(i);
                var res = instance.Solution(i);
                if (res.Count != realRes) throw new Exception("bug");
            }
        }

        private static void TestWildcardMatching(CodeTimer codeTimer, Random random)
        {
            WildcardMatching instance = new WildcardMatching();

            // bug test
            //Console.WriteLine(instance.Solution("juemcmbvexuetrgut", "**d***i*?") == false);

            //Console.ReadKey(true);

            for (int i = 0; i < 1000; i++)
            {
                int strLen = random.Next(200), modeLen = random.Next(200);

                StringBuilder builder = new StringBuilder(), modeBuilder = new StringBuilder();

                for (int j = 0; j < strLen; j++)
                {
                    builder.Append((char)('a' + random.Next(26)));
                }

                for (int j = 0; j < modeLen; j++)
                {
                    switch (random.Next(3))
                    {
                        case 0:
                            modeBuilder.Append((char)('a' + random.Next(26)));
                            break;
                        case 1:
                            modeBuilder.Append('?');
                            break;
                        case 2:
                            modeBuilder.Append('*');
                            break;
                    }
                }

                bool real = false, res = false;

                Console.WriteLine($"{nameof(strLen)}:{strLen},{nameof(modeLen)}:{modeLen}");

                var codeTimerResult = codeTimer.Time(1,
                    (() => { real = Regex.IsMatch(builder.ToString(), $"^{modeBuilder.ToString().Replace("*", ".*").Replace("?", "[a-z]")}$"); }));
                var codeTimerResult2 = codeTimer.Time(1,
                    (() => { res = instance.Solution(builder.ToString(), modeBuilder.ToString()); }));

                if (real != res)
                    throw new Exception($" bug:  \"{builder.ToString()}\" , \"{modeBuilder.ToString()}\" ");

                Console.WriteLine($@" time-speed>>>>>>>> 
match:{codeTimerResult.ToString()}
owner:{codeTimerResult2.ToString()}
");
            }
        }

        private static void TestSolveSudoku()
        {
            SolveSudoku instance = new SolveSudoku();

            //var boards = new[]
            //{
            //    new []{'5','3','.','.','7','.','.','.','.'},
            //    new []{'6','.','.','1','9','5','.','.','.'},
            //    new []{'.','9','8','.','.','.','.','6','.'},
            //    new []{'8','.','.','.','6','.','.','.','3'},
            //    new []{'4','.','.','8','.','3','.','.','1'},
            //    new []{'7','.','.','.','2','.','.','.','6'},
            //    new []{'.','6','.','.','.','.','2','8','.'},
            //    new []{'.','.','.','4','1','9','.','.','5'},
            //    new []{'.','.','.','.','8','.','.','7','9'}
            //};

            //instance.Try2(boards);

            // TODO: fix bug

            var boards = JsonConvert.DeserializeObject<char[][]>(@"[['.','.','9','7','4','8','.','.','.'],
['7', '.', '.', '.', '.', '.', '.', '.', '.'],
['.', '2', '.', '1', '.', '9', '.', '.', '.'],
['.', '.', '7', '.', '.', '.', '2', '4', '.'],
['.', '6', '4', '.', '1', '.', '5', '9', '.'],
['.', '9', '8', '.', '.', '.', '3', '.', '.'],
['.', '.', '.', '8', '.', '3', '.', '2', '.'],
['.', '.', '.', '.', '.', '.', '.', '.', '6'],
['.', '.', '.', '2', '7', '5', '9', '.', '.']]");

            instance.Solution(boards);

            //instance.Clear(boards);
        }

        private static void TestFindSubstring()
        {
            FindSubstring instance = new FindSubstring();

            //Console.WriteLine(JsonConvert.SerializeObject(instance.Simple("barfoothefoobarman", new[] { "foo", "bar" })));
            Console.WriteLine(JsonConvert.SerializeObject(instance.Simple2("barfoothefoobarman", new[] { "foo", "bar" })));
        }

        private static void TestReverseKGroup()
        {
            ReverseKGroup instance = new ReverseKGroup();

            Console.WriteLine(instance.Clear(new[] { 1, 2, 3, 4, 5 }, 2));
        }

        private static void TestMergeKLists(CodeTimer codeTimer, Random random)
        {
            MergeKLists instance = new MergeKLists();

            //instance.Simple(new ListNode[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } });
            //instance.Try3(new ListNode[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } });
            instance.Solution(new ListNode[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } });

            for (int i = 0; i < 10; i++)
            {

                var arr = new ListNode[random.Next(5) + 1000];

                for (int j = 0; j < arr.Length; j++)
                {
                    List<int> list = new List<int>();
                    for (int k = 0; k < random.Next(5); k++)
                    {
                        list.Add(random.Next(10));
                    }
                    arr[j] = list.OrderBy(u => u).ToArray();
                }

                ListNode res = null, res2 = null;

                CodeTimerResult codeTimerResult
                    = codeTimer.Time(1, () => { res = instance.Solution(arr); });


                CodeTimerResult codeTimerResult2
                    = codeTimer.Time(1, () => { res2 = instance.Try4(arr); });

                if (res == null && res2 != null) throw new Exception("result inconformity !");
                if (!res.ToString().Equals(res2.ToString())) throw new Exception("result inconformity !");

                ShowTools.ShowMulti(new Dictionary<string, object>() {
                    //{nameof(res),res },
                    {nameof(codeTimerResult),codeTimerResult },
                    { string.Empty,"vs>>>>>"},
                    //{nameof(res2),res2 },
                    {nameof(codeTimerResult2),codeTimerResult2 },
                });


            }
        }

        private static void TestMinTaps(CodeTimer codeTimer, Random random)
        {
            MinTaps minTaps = new MinTaps();

            Console.WriteLine(minTaps.OtherSolution(5, new[] { 3, 4, 1, 1, 0, 0 }) == 1);
            Console.WriteLine(minTaps.Try(3, new[] { 0, 0, 0, 0 }) == -1);
            Console.WriteLine(minTaps.Try(7, new[] { 1, 2, 1, 0, 2, 1, 0, 1 }) == 3);
            Console.WriteLine(minTaps.Try(8, new[] { 4, 0, 0, 0, 0, 0, 0, 0, 4 }) == 2);
            Console.WriteLine(minTaps.Try(8, new[] { 4, 0, 0, 0, 4, 0, 0, 0, 4 }) == 1);

            for (int i = 0; i < 10; i++)
            {
                var len = random.Next(8) + 9993;

                var arr = new int[len + 1];

                for (int j = 0; j < len; j++)
                {
                    arr[j] = random.Next(10);
                }

                int res = 0;
                CodeTimerResult timerResult;

                timerResult = codeTimer.Time(1, () => { res = minTaps.Clear(len, arr); });
                //timerResult2 = codeTimer.Time(1, () => { res2 = minTaps.Try2(len, arr); });

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    {"res",res },
                    {nameof(timerResult),timerResult },
                    {"len",len }
                });


            }
        }

        private static void TestCoinChange(Random random)
        {
            CoinChange instance = new CoinChange();

            Console.WriteLine(instance.Solution(new[] {186, 416, 83, 408}, 6249)); //20
            Console.WriteLine(instance.Solution(new[] {1, 2, 5}, 11)); //3
            Console.WriteLine(instance.Solution(new[] {2}, 3)); //-1

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

        private static void TestMaxPathSum()
        {
            MaxPathSum instance = new MaxPathSum();

            Console.WriteLine(
                instance.Solution(new TreeNode(-10, 9, new TreeNode(20, 15, 7)))); //42

            Console.WriteLine(instance.Solution(
                new TreeNode(5,
                    new TreeNode(4,
                        new TreeNode(11, 7, 2), null),
                    new TreeNode(8, 13,
                        new TreeNode(4, null, 1)
                    )
                )
            )); //48
        }

        private static void TestFindMedianSortedArrays(CodeTimer codeTimer, Random random)
        {
            FindMedianSortedArrays instance = new FindMedianSortedArrays();

            //Console.WriteLine(instance.Solution(new[] { 1, 3 }, new[] { 2 }));
            //Console.WriteLine(instance.Solution(new[] {1, 2}, new[] {3, 4}));
            Console.WriteLine(instance.Solution(new[] {0, 4, 8, 10, 13, 17}, new[] {5, 8, 11, 12}));
            Console.WriteLine(
                instance.Solution(new[] {6, 7, 10, 12, 12, 13, 15, 18, 22, 25, 29}, new[] {0, 0, 2, 5, 5}));
            Console.WriteLine(instance.Solution(new[] {2, 4, 5, 5}, new[] {5, 6, 10, 14, 16, 16, 20, 20, 21, 25, 26}));

            Console.ReadKey(true);

            for (int i = 0; i < 1000; i++)
            {
                var len = random.Next(20) + 2;
                var len2 = random.Next(20) + 2;

                var list1 = new List<int>() {random.Next(10)};
                var list2 = new List<int>() {random.Next(10)};

                for (int j = 0; j < len; j++)
                {
                    list1.Add(list1[list1.Count - 1] + random.Next(5));
                }

                for (int j = 0; j < len2; j++)
                {
                    list2.Add(list2[list2.Count - 1] + random.Next(5));
                }

                double real = 0, res = 0;

                real = instance.Check(list1.ToArray(), list2.ToArray());

                var codeTimerResult = codeTimer.Time(1,
                    (() => { res = instance.Solution(list1.ToArray(), list2.ToArray()); }));

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    {nameof(list1), list1},
                    {nameof(list2), list2},
                    {nameof(res), res},
                    {nameof(real), real},
                    {nameof(codeTimerResult), codeTimerResult}
                });

                if (real != res)
                    throw new Exception("bug");
            }
        }

        #region test method

        private static void TestLongestValidParentheses(CodeTimer codeTimer, Random random)
        {
            LongestValidParentheses instance = new LongestValidParentheses();

            #region first test

            //Console.WriteLine(instance.Solution(")()())")); //4
            //Console.WriteLine(instance.Solution("(()")); //2
            //Console.WriteLine(instance.Solution("(())")); //4
            //Console.WriteLine(instance.Solution("())(()")); //2
            Console.WriteLine(instance.Solution2("()(())")); //6
            //Console.WriteLine(instance.Solution(")()())()()(")); //4
            //Console.WriteLine(instance.Solution(")(((((()())()()))()(()))(")); //22

            #endregion

            Console.ReadKey(true);

            for (int i = 0; i < 100; i++)
            {
                var len = random.Next(10) + 3;
                StringBuilder builder = new StringBuilder();

                for (int j = 0; j < len; j++)
                {
                    builder.Append(random.Next(2) == 0 ? '(' : ')');
                }

                var res = 0;

                var codeTimerResult = codeTimer.Time(1, (() => { res = instance.Solution(builder.ToString()); }));

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    {nameof(builder), builder.ToString()},
                    {nameof(res), res},
                    {nameof(codeTimerResult), codeTimerResult}
                });
            }
        }

        private static void TestIsMatch(Random random, CodeTimer codeTimer)
        {
            IsMatch instance = new IsMatch();

            #region firstTest

            Console.WriteLine(instance.OtherSolution2("a", "aa")); // false
            Console.WriteLine(instance.OtherSolution2("a", "a*")); // true
            Console.WriteLine(instance.Solution("aab", "c*a*b")); // true
            Console.WriteLine(instance.Solution("mississippi", "mis*is*p*.")); // false
            Console.WriteLine(instance.Solution("gvuju", ".p*.*")); // true
            Console.WriteLine(instance.Solution("a", "q*.f*")); //true
            Console.WriteLine(instance.Solution("tucc", "..*.")); // true
            Console.WriteLine(instance.Solution("sm", "..e.")); // false
            Console.WriteLine(instance.Solution("aaa", "a.a")); // true
            Console.WriteLine(instance.Solution("fugg", ".*m*..")); // true
            Console.WriteLine(instance.Solution("swmvdaxkzaphiqdzwxfd", "ss.*.p*")); // false
            Console.WriteLine(instance.Solution("hybaah", "...a*..")); // true

            //Console.WriteLine(instance.Solution("ignnlmzyprxx", "..*..m..p*...*.."));// true

            #endregion

            Console.ReadKey(true);

            for (int i = 0; i < 40000; i++)
            {
                int strLen = random.Next(20) + 1, modeLen = random.Next(20) + 1;

                StringBuilder builder = new StringBuilder(), modeBuilder = new StringBuilder();

                for (int j = 0; j < strLen; j++)
                {
                    builder.Append((char) ('a' + random.Next(26)));
                }

                for (int j = 0; j < modeLen; j++)
                {
                    var randNum = 0;

                    if (modeBuilder.Length == 0 || modeBuilder[modeBuilder.Length - 1] == '*')
                    {
                        randNum = random.Next(2);
                    }
                    else randNum = random.Next(3);


                    switch (randNum)
                    {
                        case 0:
                            modeBuilder.Append((char) ('a' + random.Next(26)));
                            break;
                        case 1:
                            modeBuilder.Append('.');
                            break;
                        case 2:
                            modeBuilder.Append('*');
                            break;
                    }
                }

                bool real = false, res = false;

                var codeTimerResult = codeTimer.Time(1,
                    (() => { real = Regex.IsMatch(builder.ToString(), $"^{modeBuilder.ToString()}$"); }));
                var codeTimerResult2 = codeTimer.Time(1,
                    (() => { res = instance.Solution(builder.ToString(), modeBuilder.ToString()); }));

                if (real != res)
                    throw new Exception($" bug:  \"{builder.ToString()}\" , \"{modeBuilder.ToString()}\" ");

                Console.WriteLine($@" time-speed>>>>>>>> 
match:{codeTimerResult.ToString()}
owner:{codeTimerResult2.ToString()}
");
            }
        }

        //private static void TestNthUglyNumber()
        //{
        //    NthUglyNumber instance = new NthUglyNumber();

        //    Console.WriteLine(instance.SimpleSolution(3, 2, 3, 5)); // 4
        //    Console.WriteLine(instance.SimpleSolution(4, 2, 3, 4)); // 6
        //    Console.WriteLine(instance.SimpleSolution(1000000000, 2, 217983653, 336916467)); // time limit
        //}

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

            res = instance.Solution(new[] {-1, 2147483647}, 1, 2147483647);

            Console.WriteLine(res);
        }

        private static void TestTotalNQueens()
        {
            TotalNQueens instance = new TotalNQueens();

            for (int i = 4; i < 11; i++)
            {
                var realRes = instance.SimpleSolution(i);
                var res = instance.Solution(i);
                if (res != realRes) throw new Exception("bug");
            }

            Console.WriteLine("test over~");
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


        [Obsolete]
        private static void TestMinDeletionSize(Random rand, CodeTimer codeTimer)
        {
            MinDeletionSize instance = new MinDeletionSize();

            Console.WriteLine(instance.Solution(new[]
            {
                "bbazb", "dabca"
            })); // 3

            Console.WriteLine(instance.Solution(new[]
            {
                "dabca", "bbazb"
            })); // 3

            Console.WriteLine(instance.Solution(new[]
            {
                "edcba"
            })); // 4

            Console.WriteLine(instance.Solution(new[]
            {
                "ghi", "def", "abc"
            })); // 0

            Console.WriteLine(instance.Solution(new[]
            {
                "aaaabaa"
            })); // 1

            Console.WriteLine(instance.Solution(new[]
            {
                "abcacba", "cbbcacb", "acabcbb", "aabaabc"
            })); // 4

            Console.ReadKey();

            int testCount = 100, strLen = 100, lowLen = 1, arrLen = 100, lowArrLen = 1;

            for (int i = 0; i < testCount; i++)
            {
                var len = rand.Next(strLen) + lowLen;

                var arr = new string[rand.Next(arrLen) + lowArrLen];

                for (int j = 0; j < arr.Length; j++)
                {
                    StringBuilder builder = new StringBuilder();

                    for (int k = 0; k < len; k++)
                    {
                        builder.Append((char) (rand.Next(26) + 'a'));
                    }

                    arr[j] = builder.ToString();
                }

                int res = len;

                var codeTimerResult = codeTimer.Time(1, (() => { res = instance.Solution(arr); }));

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    {nameof(res), res},
                    {nameof(codeTimerResult), codeTimerResult},
                    {nameof(arr), arr}
                });
            }
        }

        private static void TestSmallestRange(CodeTimer codeTimer)
        {
            var instance = new SmallestRange();

            var list = new List<IList<int>>()
            {
                new List<int>() {1, 2, 3, 4},
                new List<int>() {1, 2, 3},
                new List<int>() {4, 5, 6}
            };

            instance.HelperShow(list, new StringBuilder(), 0);

            ShowTools.Show(instance.Simple(list));

            ShowTools.Show(instance.Simple(new List<IList<int>>()
            {
                new List<int>() {4, 10, 15, 24, 26},
                new List<int>() {0, 9, 12, 20},
                new List<int>() {5, 18, 22, 30}
            }));

            var data = JsonConvert.DeserializeObject<IList<IList<int>>>(
                "[[11,38,83,84,84,85,88,89,89,92],[28,61,89],[52,77,79,80,81],[21,25,26,26,26,27],[9,83,85,90],[84,85,87],[26,68,70,71],[36,40,41,42,45],[-34,21],[-28,-28,-23,1,13,21,28,37,37,38],[-74,1,2,22,33,35,43,45],[54,96,98,98,99],[43,54,60,65,71,75],[43,46],[50,50,58,67,69],[7,14,15],[78,80,89,89,90],[35,47,63,69,77,92,94]]");

            int[] res = null;

            var codeTimerResult = codeTimer.Time(1, (() => { res = instance.Simple(data); }));

            ShowTools.ShowMulti(new Dictionary<string, object>()
            {
                {nameof(codeTimerResult), codeTimerResult},
                {nameof(res), res}
            });

            codeTimerResult = codeTimer.Time(1, (() => { res = instance.Simple(data); }));

            ShowTools.ShowMulti(new Dictionary<string, object>()
            {
                {nameof(codeTimerResult), codeTimerResult},
                {nameof(res), res}
            });

            codeTimerResult = codeTimer.Time(1, (() => { res = instance.Solution(data); }));

            ShowTools.ShowMulti(new Dictionary<string, object>()
            {
                {nameof(codeTimerResult), codeTimerResult},
                {nameof(res), res}
            });

            codeTimerResult = codeTimer.Time(1, (() => { res = instance.Solution(data); }));

            ShowTools.ShowMulti(new Dictionary<string, object>()
            {
                {nameof(codeTimerResult), codeTimerResult},
                {nameof(res), res}
            });
        }

        private static void TestSwimInWater(CodeTimer codeTimer, Random rand)
        {
            SwimInWater instance = new SwimInWater();

            instance.Solution2(
                JsonConvert.DeserializeObject<int[][]>(
                    "[[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]"),
                true); //16

            instance.Solution2(
                JsonConvert.DeserializeObject<int[][]>(
                    "[[7,34,16,12,15,0],[10,26,4,30,1,20],[28,27,33,35,3,8],[29,9,13,14,11,32],[31,21,23,24,19,18],[22,6,17,5,2,25]]"),
                true); //26

            instance.Solution2(JsonConvert.DeserializeObject<int[][]>(
                "[[52,19,24,3,45,21,56,27,5],[48,35,53,12,11,75,65,61,59],[58,9,76,28,4,80,72,34,78],[63,79,33,16,64,51,13,67,23],[31,57,54,60,74,8,6,38,44],[7,77,36,37,10,2,42,68,46],[32,25,17,26,15,14,29,70,39],[50,40,49,71,0,22,55,41,73],[69,66,1,47,20,43,30,62,18]]"));

            Console.ReadKey(true);

            int testCount = 10, martixLen = 20;

            codeTimer.Time(1, () => { instance.Solution2(null); });
            for (int i = 0; i < testCount; i++)
            {
                var len = rand.Next(martixLen) + 2;

                var arr = new int[len][];

                var source = Enumerable.Range(0, len * len).ToList();

                for (int j = 0; j < len; j++)
                {
                    arr[j] = new int[len];
                    for (int k = 0; k < len; k++)
                    {
                        var randIndex = rand.Next(source.Count);
                        arr[j][k] = source[randIndex];
                        source.RemoveAt(randIndex);
                    }
                }

                int res = 0;

                var codeTimerResult = codeTimer.Time(1, () => { res = instance.Solution2(arr); });

                ShowTools.ShowMulti(new Dictionary<string, object>()
                {
                    //{nameof(arr),ShowList.GetStr(arr)},
                    {nameof(arr), arr},
                    {nameof(res), res},
                    {nameof(codeTimerResult), codeTimerResult}
                });
            }
        }

        private static void TestBraceExpansionII()
        {
            BraceExpansionII instance = new BraceExpansionII();

            IList<string> res;

            res = instance.Solution("n{{c,g},{h,j},l}a{{a,{x,ia,o},w},er,a{x,ia,o}w}n");

            //["ncaaiawn","ncaan","ncaaown","ncaaxwn","ncaern","ncaian","ncaon","ncawn","ncaxn","ngaaiawn","ngaan","ngaaown","ngaaxwn","ngaern","ngaian","ngaon","ngawn","ngaxn","nhaaiawn","nhaan","nhaaown","nhaaxwn","nhaern","nhaian","nhaon","nhawn","nhaxn","njaaiawn","njaan","njaaown","njaaxwn","njaern","njaian","njaon","njawn","njaxn","nlaaiawn","nlaan","nlaaown","nlaaxwn","nlaern","nlaian","nlaon","nlawn","nlaxn"]
            ShowTools.Show(res);

            res = instance.Solution("a,n{{c,g},{h,j},l}a{{a,{x,ia,o},w},er,a{x,ia,o}w}n");

            //["a,ncaaiawn","a,ncaan","a,ncaaown","a,ncaaxwn","a,ncaern","a,ncaian","a,ncaon","a,ncawn","a,ncaxn","a,ngaaiawn","a,ngaan","a,ngaaown","a,ngaaxwn","a,ngaern","a,ngaian","a,ngaon","a,ngawn","a,ngaxn","a,nhaaiawn","a,nhaan","a,nhaaown","a,nhaaxwn","a,nhaern","a,nhaian","a,nhaon","a,nhawn","a,nhaxn","a,njaaiawn","a,njaan","a,njaaown","a,njaaxwn","a,njaern","a,njaian","a,njaon","a,njawn","a,njaxn","a,nlaaiawn","a,nlaan","a,nlaaown","a,nlaaxwn","a,nlaern","a,nlaian","a,nlaon","a,nlawn","a,nlaxn"]
            ShowTools.Show(res);

            res = instance.Solution("{{a,{x,ia,o},w},er,a{x,ia,o}w}");

            ShowTools.Show(res); //["a","aiaw","aow","axw","er","ia","o","w","x"]

            // next
            res = instance.Solution("{a,{a,{x,ia,o},w}er{n,{g,{u,o}},{a,{x,ia,o},w}},er}");

            //["a","aera","aerg","aeria","aern","aero","aeru","aerw","aerx","er","iaera","iaerg","iaeria","iaern","iaero","iaeru","iaerw","iaerx","oera","oerg","oeria","oern","oero","oeru","oerw","oerx","wera","werg","weria","wern","wero","weru","werw","werx","xera","xerg","xeria","xern","xero","xeru","xerw","xerx"]
            ShowTools.Show(res);

            res = instance.Solution("{a{x,ia,o}w,{n,{g,{u,o}},{a,{x,ia,o},w}},er}");

            ShowTools.Show(res); //["a","aiaw","aow","axw","er","g","ia","n","o","u","w","x"]

            res = instance.Solution("{a,b}c{d,e}f");

            ShowTools.Show(res); //["acdf","acef","bcdf","bcef"]

            res = instance.Solution("{a,b}{c,{d,e}}");

            ShowTools.Show(res); //["ac","ad","ae","bc","bd","be"]

            res = instance.Solution("{{a,z},a{b,c},{ab,z}}");

            ShowTools.Show(res); //["a","ab","ac","z"]
        }

        private static void TestLongestDecomposition()
        {
            LongestDecomposition instance = new LongestDecomposition();

            instance.Test(instance.Solution);

            instance.TestCase(100, 10, instance.Solution);
        }

        private static void TestParseBoolExpr()
        {
            ParseBoolExpr instance = new ParseBoolExpr();

            Console.WriteLine(instance.Solution("|(f,&(t,t))") == true);

            instance.Test(instance.Solution);

            Console.WriteLine(instance.Solution("!(&(&(!(&(f)),&(t),|(f,f,t)),&(t),&(t,t,f)))"));

            Console.WriteLine(instance.Solution(
                                  "&(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))),&(!(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t))),!(&(&(&(t,t,f),|(f,f,t),|(f)),!(&(t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))))),!(&(f))))") ==
                              false);
        }

        private static void TestMyCalendarThree()
        {
            List<int> list = new List<int>() {1, 2, 3};
            list.Insert(0, 4);

            MyCalendarThree instance = new MyCalendarThree();

            instance.Test();

            var arr = new[]
            {
                new[] {24, 40},
                new[] {43, 50},
                new[] {27, 43},
                new[] {5, 21},
                new[] {30, 40},
                new[] {14, 29},
                new[] {3, 19},
                new[] {3, 14},
                new[] {25, 39},
                new[] {6, 19}
            };

            //[null,1,1,2,2,3,3,3,3,4,4]

            foreach (var item in arr)
            {
                instance.Book(item[0], item[1]);
            }
        }

        #endregion
    }
}