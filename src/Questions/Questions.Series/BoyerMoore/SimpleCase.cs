using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Series.BoyerMoore
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/10/2020 4:47:03 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class SimpleCase
    {

        /// <summary>
        /// 获取出现频率超过1/2的数
        ///     若不存在则返回-1(假定arr中不存在-1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int GetNum(int[] arr)
        {
            // base check
            if (arr == null) return -1;

            int candidate = 0, count = 0;

            foreach (var item in arr)
            {
                if (item == candidate) count++;
                else if (count == 0)
                {
                    candidate = item;
                    count = 1;
                }
                else count--;
            }
            return arr.Where(u => u == candidate).Count() > arr.Length / 2 ? candidate : -1;
        }

    }
}
