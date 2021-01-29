using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/29/2021 2:31:21 PM
    /// @source : https://leetcode.com/problems/ipo/
    /// @des : 
    ///     给定投资次数k,当前资金w，投资项目(reward,need) reward -> 投资后可以获取的纯收益(不含本金),need -> 启动资金
    ///     获取投资后最大的最终收益
    /// </summary>
    [Optimize]
    public class IPO
    {

        // You may assume all numbers in the input are non-negative integers.
        //The length of Profits array and Capital array will not exceed 50,000.
        //The answer is guaranteed to fit in a 32-bit signed integer.

        public int Optimize(int k, int W, int[] reward, int[] need)
        {
            // how get max reward?

            return default;
        }

        // Runtime: 2832 ms, faster than 8.70% of C# online submissions for IPO.
        // Memory Usage: 34.2 MB, less than 82.61% of C# online submissions for IPO.
        // slow
        // k * len + sort
        public int Try3(int k, int W, int[] Profits, int[] Capital)
        {
            (int value, int)[] arr = Profits.Select((value, index) => (value, Capital[index])).OrderBy(u => u.value).ToArray();

            int len = Profits.Length;
            bool[] used = new bool[len];

            for (int i = len - 1; i >= 0 && k > 0; i--)
            {
                if (used[i]) continue;
                if (arr[i].Item2 <= W)
                {
                    W += arr[i].value;
                    used[i] = true;
                    i = len;
                    k--;
                }
            }

            return W;

        }

        // 差不多
        public int Try2(int k, int W, int[] Profits, int[] Capital)
        {

            int len = Profits.Length;

            (int value, int)[] arr = Profits.Select((value, index) => (value, Capital[index])).OrderBy(u => u.Item2).ToArray();
            bool[] visited = new bool[len];

            int left = 0;
            while (k-- > 0)
            {
                int index = GetIndex(W, left, len - 1);

                if (index == left - 1) return W;

                int maxIndex = 0;

                for (int i = 0; i <= index; i++)
                {
                    if (visited[i]) continue;
                    if (arr[i].value > arr[maxIndex].value) maxIndex = i;
                }

                W += arr[maxIndex].value;
                visited[maxIndex] = true;

                left = Math.Min(index + 1, len - 1);

            }
            return W;

            int GetIndex(int num, int left, int right)
            {
                while (right > left)
                {
                    var mid = (right + left) / 2;
                    if (arr[mid].Item2 > num)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                if (arr[left].Item2 <= num)
                {
                    return left;
                }

                return left - 1;

            }

        }

        public int Try(int k, int W, int[] Profits, int[] Capital)
        {

            int len = Profits.Length;

            // bug : 启动资金与收益不一定成正比...
            (int value, int)[] arr = Profits.Select((value, index) => (value, Capital[index])).OrderBy(u => u.Item2).ToArray();

            int left = 0, right = len - 1;
            while (k-- > 0)
            {
                int index = GetIndex(W, left, right);

                if (index == left - 1) return W;

                W += arr[index].value;

                left = index + 1;

            }
            return W;

            int GetIndex(int num,int left,int right)
            {
                while (right > left)
                {
                    var mid = (right + left) / 2;
                    if(arr[mid].Item2 > num)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                if(arr[left].Item2 <= num)
                {
                    return left;
                }

                return left - 1;

            }

        }

        // time limit
        public int Simple(int k, int W, int[] Profits, int[] Capital)
        {
            int len = Profits.Length;
            bool[] visited = new bool[len];
            while (k-- > 0)
            {
                var maxIndex = -1;
                for (int i = 0; i < len; i++)
                {
                    if (visited[i]) continue;
                    if (W >= Capital[i])
                        if (maxIndex == -1 || Profits[i] > Profits[maxIndex]) maxIndex = i;
                }

                if (maxIndex == -1) return W;

                W += Profits[maxIndex];
                visited[maxIndex] = true;
            }

            return W;

        }

    }
}
