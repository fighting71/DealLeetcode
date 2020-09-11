using Newtonsoft.Json;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/11/2020 2:39:26 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class UnresolveTest
    {
        public static void TestSolveSudoku()
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

            var boards = JsonConvert.DeserializeObject<char[][]>(@"
[['.','.','9','7','4','8','.','.','.'],
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


    }
}
