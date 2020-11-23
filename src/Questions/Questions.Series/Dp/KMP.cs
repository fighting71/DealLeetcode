using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 4:59:56 PM
    /// @source : 
    /// @des : KMP算法.
    /// </summary>
    public class KMP
    {
        private readonly string _pat;
        private int[][] _dp;

        public KMP(string pat)
        {
            this._pat = pat;
            this.Init();
        }

        private void Init()
        {
            var len = _pat.Length;
            _dp = new int[len][];
            for (int i = 0; i < len; i++)
            {
                _dp[i] = new int[256];// asci len = 256
            }
            ISet<int> set = new HashSet<int>();
            foreach (var c in _pat)
            {
                set.Add(c);
            }

            _dp[0][_pat[0]] = 1;
            int x = 0;// 影子坐标 *** 
            for (int i = 1; i < len; i++)
            {
                foreach (var c in set)
                {
                    _dp[i][c] = _dp[x][c];
                }
                _dp[i][_pat[i]] = i + 1;
                x = _dp[x][_pat[i]];
            }

        }

        private int Search(string str)
        {
            int m = _pat.Length;
            int n = str.Length;
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                j = _dp[j][str[i]];
                if (j == m) return i - m + 1;
            }
            return -1;
        }

    }
}
