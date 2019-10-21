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

            var len = tiles.Length;

            if (len == 1) return 1;

            var res = 0;

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var c in tiles)
            {
                if (dictionary.ContainsKey(c)) dictionary[c]++;
                else dictionary.Add(c, 1);
            }

            // 一位数量
            int sum = dictionary.Keys.Count;

            // 求最后一个的数量
            int member = 1;
            for (int i = 2; i <= len; i++)
            {
                member *= i;
            }

            foreach (var item in dictionary)
            {
                for (int i = 2; i <= item.Value; i++)
                {
                    member /= i;
                }
            }

            if (len > 2) sum += 2 * member;// len>2 则添加最后一个和倒数第二个的数量 ps: count(最后一个) = count(倒数第二个)
            else return sum + member;

            for (int i = 2; i < len - 1; i++)
            {
                // 拆分计算此数量的值
                // 参考: 3a2b4c 的8排列 = 2a2b4c+3a1b4c+3a2b3c
            }

            return sum;
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