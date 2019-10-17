using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/17 16:08:43
    /// @source : https://leetcode.com/problems/letter-tile-possibilities/
    /// @des : 
    /// </summary>
    public class NumTilePossibilities
    {
        ISet<string> _set = new HashSet<string>();

        public void SimpleTest(string tiles)
        {
            _set.Clear();

            Helper(tiles, string.Empty, new bool[tiles.Length]);

            Console.WriteLine($@"test reuslt:
tiles:{tiles}
result:{_set.Count}
combination:{JsonConvert.SerializeObject(_set.OrderBy(u => u.Length * 100 + u))}
lenArr:{
                    JsonConvert.SerializeObject(_set.GroupBy(u => u.Length).Select((grouping =>
                        new {grouping.Key, count = grouping.Count((s => s.Length == grouping.Key))})))
                }
");
        }

        public int Solution(string tiles)
        {

            // 排列数量》 len = 1 = 不同字符数 
            // 排列数量》len = max = 多重集合的排列数   参考： https://blog.csdn.net/kennyrose/article/details/7469528
            // 排列数量》len = max - 1 = (len = max)

            var res = 0;

            return res;
        }

        /*
         Runtime: 184 ms, faster than 19.91% of C# online submissions for Letter Tile Possibilities.
Memory Usage: 30.7 MB, less than 100.00% of C# online submissions for Letter Tile Possibilities.

            ....
             */
        public void Helper(string str, string item, bool[] visited)
        {
            //Runtime: 124 ms, faster than 41.20% of C# online submissions for Letter Tile Possibilities.
            //Memory Usage: 29.7 MB, less than 100.00 % of C# online submissions for Letter Tile Possibilities.
            if (_set.Contains(item)) return;

            if (item != string.Empty)
                _set.Add(item);

            for (int i = 0; i < str.Length; i++)
            {
                if (visited[i]) continue;

                visited[i] = true;
                Helper(str, item + str[i], visited);
                visited[i] = false;
            }
        }
    }
}