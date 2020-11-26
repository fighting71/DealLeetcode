using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Dp
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/24/2020 9:50:00 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class StoneGame
    {

        // 状态:
        //  a.先选 or 后选
        //  b.能选择的区域 [i,j]
        public int Solution(int[] stones)
        {
            int len = stones.Length;

            int[][] firstDp = new int[len][];
            int[][] sencondDp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                firstDp[i] = new int[len];
                sencondDp[i] = new int[len];
                // base case : 当区域只剩下一个堆，先到先得
                firstDp[i][i] = stones[i];
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = 0; i <= len - l; i++)
                {
                    int j = l + i - 1;

                    // 状态转移:
                    //  a.选择最左边的一堆
                    //      选完后变化为后手，且拥有区域 [i+1,j]
                    //  b.选择最右边的一堆
                    //      选完后变化为后手，且拥有区域 [i,j-1]
                    var left = stones[i] + sencondDp[i + 1][j];
                    var right = stones[j] + sencondDp[i][j - 1];
                    if(left > right)
                    {
                        firstDp[i][j] = left;
                        // 同理，等待上一个选择完后则变为先手.
                        sencondDp[i][j] = firstDp[i + 1][j];
                    }
                    else
                    {
                        firstDp[i][j] = right;
                        sencondDp[i][j] = firstDp[i][j - 1];
                    }

                }
            }

            return default;

        }

    }
}
