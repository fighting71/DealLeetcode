using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 7/2/2021 4:56:44 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestShortest_Path_to_Get_All_KeysDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Shortest_Path_to_Get_All_Keys instance = new Shortest_Path_to_Get_All_Keys();

            BaseLibrary.CommonTest(new[] {
                   new []{"..............................","......#.......#.........#.....",".#............................","..#..............#............","#........##..........c........",".#......#...........##........","..#..#...##.C....#............","..............................",".#.....#........#............#","...............#..............","#.............................",".#........#...#.......a.......",".#..#.........................",".....#......#.............b#..","............#........#........","......#...#..d................","......#.##..#..............@..",".............................#","...#..........A#........#.....",".....#.#...........#..#.....#.",".....#..#.....................",".....#...........#.......#....","..........#..........#....#...","...#..........................","........##....................","......................#......#",".#.......##.....#.....D....#..","............................#.","...#...#.................#....","#B..........#.#...........#..."}, //37
                    new []{"@.a.#","###.#","b.A.B"}, // 8
                    new []{"@..aA","..B#.","....b"}, // 6
                }
            , instance.Try
            , () =>
            {
                int keyCount = random.Next(5) + 2;
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < keyCount; i++)
                {
                    stack.Push((char)('a' + i));
                }

                for (int i = 0; i < keyCount; i++)
                {
                    stack.Push((char)('A' + i));
                }

                var codes = new[] { '.', '#' };

                int rowCount = 30, celCount = 30;
                char[][] vs = CollectionHelper.GetEnumerable(rowCount, () => CollectionHelper.GetEnumerable(celCount, () => codes[random.Next(12) / 11]).ToArray()).ToArray();

                int y = random.Next(rowCount), x = random.Next(celCount);

                vs[y][x] = '@';
                ISet<(int y, int x)> visited = new HashSet<(int y, int x)>() { (y, x) };

                while (stack.Count > 0)
                {
                    y = random.Next(rowCount);
                    x = random.Next(celCount);
                    if (visited.Add((y, x)))
                    {
                        vs[y][x] = stack.Pop();
                    }
                }
                return vs.Select(u => new string(u)).ToArray();
            }
            , checkFunc: instance.Try
            , showArg: false
            );

        }
    }
}
