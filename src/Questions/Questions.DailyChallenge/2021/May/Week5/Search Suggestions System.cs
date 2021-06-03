using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/1/2021 10:40:59 AM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/602/week-5-may-29th-may-31st/3762/
    /// @des : 
    ///     给定一堆字符串products，和一个搜索字符串searchWord，返回匹配的字符串列表,若匹配的字符串超过3个则按字典序返回最小的三个
    ///     
    ///     示例：
    ///         products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = mouse
    ///         
    ///         res[0] = products中以"m"为前缀的字符串： ["mobile","moneypot","monitor"]
    ///         res[1] = products中以"mo"为前缀的字符串： ["mobile","moneypot","monitor"]
    ///         res[2] = products中以"mou"为前缀的字符串： ["mouse","mousepad"]
    ///         res[3] = products中以"mous"为前缀的字符串： ["mouse","mousepad"]
    ///         res[4] = products中以"mouse"为前缀的字符串： ["mouse","mousepad"]
    ///         
    /// 
    /// </summary>
    public class Search_Suggestions_System
    {

        // Constraints:

        //1 <= products.length <= 1000
        //There are no repeated elements in products.
        //1 <= Σ products[i].length <= 2 * 10^4
        //All characters of products[i] are lower-case English letters.
        //1 <= searchWord.length <= 1000
        //All characters of searchWord are lower-case English letters.

        // Your runtime beats 56.07 %
        // synn
        // optimize =>
        //      1. 数组合并，减少索引搜索
        //      2. 当全部不符合时，直接返回，减少循环
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {

            int len = products.Length;

            // 先按字典序进行排序，保证添加的一定是按字典序排序的
            Array.Sort(products);

            // skip[i] = 第i个字符串是否应该跳过
            bool[] skip = new bool[len];

            // startArr[i] = 第i个字符串比较到了第几位
            int[] startArr = new int[len];

            IList<IList<string>> res = new List<IList<string>>();

            for (int i = 0; i < searchWord.Length; i++)
            {
                List<string> curr = new List<string>();
                for (int j = 0; j < len; j++)
                {
                    if (skip[j]) continue;

                    ref var start = ref startArr[j];
                    var product = products[j];
                    if(product.Length <= i) // 检测长度是否够比较
                    {
                        skip[j] = true;
                        continue;
                    }
                    bool match = true;
                    for (; start <= i; start++)
                    {
                        if(searchWord[start] != product[start])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match) // 匹配
                    {
                        // 直接添加并检查是否足够了
                        curr.Add(product);
                        startArr[j] = i + 1;
                        if (curr.Count == 3) break;
                    }
                    else
                    {
                        skip[j] = true;
                    }
                }
                res.Add(curr);

            }

            return res;

        }

    }
}
