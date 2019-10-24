using System;
using System.Collections.Generic;
using System.Linq;
using Command.Attr;
using Newtonsoft.Json;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/10/17 16:08:43
    /// @source : https://leetcode.com/problems/letter-tile-possibilities/
    /// @des : 多重排列相关
    /// </summary>
    [Level(Command.Menu.LevelTypes.Hard)]
    public class NumTilePossibilities
    {
        #region 优化解答

        /*
         * Runtime: 68 ms, faster than 100.00% of C# online submissions for Letter Tile Possibilities.
         * Memory Usage: 21.2 MB, less than 100.00% of C# online submissions for Letter Tile Possibilities.
         * 
         * 思路参考《组合数学》 也可短暂的参考博文： https://blog.csdn.net/kennyrose/article/details/7469528
         * 
         */
        public int Solution(string tiles)
        {
            // 通过简单解答发现的规律
            // 排列数量》 len = 1 = 不同字符数 
            // 排列数量》len = max = 多重集合的排列数 = n!/(n1!n2!...nk!)
            // 排列数量》len = max - 1 = (len = max)

            if (1 == tiles.Length) return 1; // 字符为1时直接返回

            // 记录字符数
            int[] arr = new int[26];
            // 记录字符种类(方便计算) 和字符长度
            int kind = 0, len = tiles.Length;

            foreach (var c in tiles)
            {
                if (arr[c - 'A'] == 0) kind++;
                arr[c - 'A']++;
            }

            // 种类为1直接返回
            if (kind == 1) return len;

            // 定义求和 count(1) = kind
            int sum = kind;

            // 求最后一个的数量 根据定义 : count(n) = n!/(n1!n2!...nk!)
            int member = TakeTheOrder(len);

            foreach (var item in arr)
                for (int i = 2; i <= item; i++)
                    member /= i;

            if (len > 2) sum += 2 * member; // len>2 则添加最后一个和倒数第二个的数量 ps: count(最后一个) = count(倒数第二个)
            else return sum + member;

            int[] build = new int[26];

            member = 1;

            // 求中间部分的排列数 由于没有固定的公式(可能有但我并不知情...) 所以参考思路: 获取所有i可能的组合数 求所有组合的排列数之和
            for (int i = 2; i < len - 1; i++)
            {
                member *= i;
                sum += Helper(0, i, arr, build, 0, member);
            }

            // 拆分计算此数量的值
            // 参考: 3a2b4c 的8排列 = 2a2b4c+3a1b4c+3a2b3c

            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">已拥有的元素数-方便判断</param>
        /// <param name="targetNum">最大元素数</param>
        /// <param name="info">元素集合S</param>
        /// <param name="arr">构建的元素集合</param>
        /// <param name="i">开始下标 避免往后重复计算.</param>
        /// <param name="member">targetNum! 因为可能存在多次使用此值 为减少重复计算 直接由外部传入</param>
        /// <returns></returns>
        private int Helper(int num, int targetNum, int[] info, int[] arr, int i, int member)
        {
            // 若成员已满(表示已形成一个数量为targetNum的组合)则直接求和
            if (num == targetNum)
            {
                // count(n) = n!/(n1!n2!...nk!)
                foreach (var item in arr)
                    for (int j = 2; j <= item; j++)
                        member /= j;

                return member;
            }

            int sum = 0;

            for (; i < 26; i++)
            {
                // 种类数量不足直接跳过
                if (info[i] <= arr[i]) continue;

                // 方便回退
                // 解决 aabbc 
                var oldNum = num;
                
                // 举例: aab  targetNum = 2 初始 num = 0
                // 第一次    添加一个a targetNum = 2 num = 1 arr = {a}
                //     递归 添加一个b targetNum = 2 num = 2 arr = {a,b}
                // 第二次 再添加一个 a targetNum = 2 num = 2 arr = {a,a}
                // sum = count({a,b}) + count({a,a})
                for (int j = 0; j < targetNum && j < info[i] && num < targetNum; j++)
                {
                    arr[i]++;
                    // 由于 abc 等价于 acb 故只需一直往前扫描
                    sum += Helper(++num, targetNum, info, arr, i + 1, member);
                }

                // 回退值
                num = oldNum;
                arr[i] = 0;
            }

            // 返回总和
            return sum;
        }

        /// <summary>
        /// 计算乘阶
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int TakeTheOrder(int num)
        {
            int sum = num;
            for (int i = 2; i < num; i++)
            {
                sum *= i;
            }

            return sum;
        }

        #endregion

        #region 直接解答

        ISet<string> _set = new HashSet<string>();

        /// <summary>
        /// 直接遍历str 将所有可能的组合添加到set中 利用hashSet去重的特性 set的count即为可能的排列数
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int SimpleTest(string tiles)
        {
            _set.Clear();

            Helper(tiles, string.Empty, new bool[tiles.Length]);

            // 测试输出
            //combination: { JsonConvert.SerializeObject(_set.OrderBy(u => u.Length * 100 + u))}
            Console.WriteLine($@"test reuslt:
tiles:{tiles}
result:{_set.Count}
lenArr:{
                    JsonConvert.SerializeObject(_set.GroupBy(u => u.Length).Select((grouping =>
                        new {grouping.Key, count = grouping.Count((s => s.Length == grouping.Key))})))
                }
");

            return _set.Count;
        }


        /*
         * Runtime: 184 ms, faster than 19.91% of C# online submissions for Letter Tile Possibilities.
         * Memory Usage: 30.7 MB, less than 100.00% of C# online submissions for Letter Tile Possibilities.
             */
        private void Helper(string str, string item, bool[] visited)
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

        #endregion
    }
}