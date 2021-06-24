using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Helper
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/18/2021 4:21:48 PM
    /// @source : 写多了就发现大多数bfs一模一样...
    /// @des : 
    /// </summary>
    public static class BfsHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="curr"></param>
        /// <param name="moveToNext"></param>
        /// <param name="coreFunc">核心处理方法，返回true 表示成功且结束查找
        ///     ps: 由于在循环中，curr与next发生了交换，故不能直接使用原有的next
        /// </param>
        public static bool Bfs<T>(Stack<T> curr, Stack<T> next, Action moveToNext, Func<Stack<T>, T, bool> coreFunc)
        {
            while (curr.Count > 0)
            {

                while (curr.Count > 0)
                    if (coreFunc(next, curr.Pop())) return true;

                var t = curr;
                curr = next;
                next = t;
                moveToNext();
            }
            return false;
        }

    }
}
