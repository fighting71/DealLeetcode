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

        public static IEnumerable<T> GetEnumerable<T>(int len, Func<T> getItemFunc)
        {
            for (int i = 0; i < len; i++)
            {
                yield return getItemFunc();
            }
            yield break;
        }
        public static IEnumerable<T> GetEnumerable<T>(int len, Func<int, T> getItemFunc)
        {
            for (int i = 0; i < len; i++)
            {
                yield return getItemFunc(i);
            }
            yield break;
        }

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

        public static string GetString(int len,Func<char> getItemFunc)
        {
            StringBuilder builder = new StringBuilder();
            for (int j = 0; j < len; j++)
            {
                builder.Append(getItemFunc());
            }
            return builder.ToString();
        }

        public static string GetString(Func<int> getLenFunc, Func<char> getItemFunc)
        {
            return GetString(getLenFunc(), getItemFunc);
        }
    }
}
