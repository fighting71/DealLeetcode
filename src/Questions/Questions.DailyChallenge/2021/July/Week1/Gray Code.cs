using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.July.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 7/1/2021 3:46:10 PM
    /// @source : https://leetcode.com/explore/featured/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3799/
    /// @des : 构建格雷码
    /// </summary>
    [Serie(FlagConst.GrayCode, FlagConst.Special)]
    public class Gray_Code
    {
        // 1 <= n <= 16

        // Your runtime beats 47.37 % of csharp submissions
        // article : https://baike.baidu.com/item/%E6%A0%BC%E9%9B%B7%E7%A0%81/6510858?fromtitle=Gray%20code&fromid=11296193&fr=aladdin#5_1
        // 参考自 转换方法-递归生成码表
        // 告辞
        /** 
         * 递归生成码表
         * 这种方法基于格雷码是反射码的事实，利用递归的如下规则来构造：
         * 1. 1位格雷码有两个码字
         * 2. (n+1)位格雷码中的前2n个码字等于n位格雷码的码字，按顺序书写，加前缀0
         * 3. (n+1)位格雷码中的后2n个码字等于n位格雷码的码字，按逆序书写，加前缀1 [4] 
         * 4. n+1位格雷码的集合 = n位格雷码集合(顺序)加前缀0 + n位格雷码集合(逆序)加前缀1
         * 
         * 示例：
         *  0   00  000
         *  1   01  001
         *      11  011
         *      10  010
         *          110
         *          111
         *          101
         *          100
         */
        public IList<int> Try(int n)
        {

            int[] res = new int[1 << n];

            for (int i = 1; i <= n; i++)
            {
                int count = 1 << i;
                var half = count / 2;

                for (int j = half; j < count; j++)
                {
                    res[j] = half + res[count - j - 1]; // 逆序书写且加前缀1
                }
            }

            return res;
        }

        // bug
        public IList<int> Simple(int n)
        {

            int[] move = new int[n];

            int max = 0;
            for (int i = 0; i < n; i++)
            {
                move[i] = 1 << i;
                max = max * 2 + 1;
            }

            bool[] used = new bool[max + 1];
            LinkedList<int> build = new LinkedList<int>();

            Help(0, 1 << n);

            return build.ToArray();

            bool Help(int curr, int remind)
            {
                remind--;

                if (remind == 0)
                {
                    int diff = Math.Abs(curr - build.First.Value);
                    if (move.Contains(diff))
                    {
                        build.AddLast(curr);
                        return true;
                    }

                    return false;
                }

                build.AddLast(curr);
                used[curr] = true;
                foreach (var item in move)
                {

                    bool v = (curr % item) / item == 1;
                    if (v)
                    {
                        var next = curr - item;

                        if (next >= 0 && !used[next])
                        {
                            if (Help(next, remind))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        var next = curr + item;

                        if (next <= max && !used[next])
                        {
                            if (Help(next, remind))
                            {
                                return true;
                            }
                        }
                    }


                }
                used[curr] = false;
                build.RemoveLast();
                return false;
            }

        }

    }
}
