using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Helper
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/9/12 10:42:42
    /// @source : 
    /// @des : 
    /// </summary>
    public class CollectionHelper
    {

        public static int GetMaxSortLen<T>(T[] arr, Func<T, T, bool> comparable)
        {
            var max = 0;
            int[] dp = new int[arr.Length];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] + 1 > dp[i] && comparable(arr[i], arr[j]))
                    {
                        dp[i] = dp[j] + 1;
                    }
                }

                if (dp[i] > max) max = dp[i];
            }

            return max;

        }

    }
}
