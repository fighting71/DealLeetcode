using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/22/2021 6:14:59 PM
    /// @source : https://leetcode.com/problems/similar-string-groups/
    /// @des : 
    /// 
    ///     给定一个字符串列表，若列表中的两个字符串满足：
    ///         字符串完全相同 或者 字符串a可以通过交换任意2个字符来变成字符串b
    ///     则认为这两个字符串是同一组
    ///     
    ///     若a与b是同一组，b与c是同一组，则a、b、c是同一组
    ///     
    ///     target: 列表共有多少组？
    /// 
    /// </summary>
    [Serie(FlagConst.Special, FlagConst.SecondReference)]
    [Optimize]
    public class Similar_String_Groups
    {

        // Constraints:

        //1 <= strs.length <= 300
        //1 <= strs[i].length <= 300
        //strs[i] consists of lowercase letters only.
        //All words in strs have the same length and are anagrams of each other.

        // Runtime: 108 ms, faster than 65.38% of C# online submissions for Similar String Groups.
        // Memory Usage: 29.3 MB, less than 7.69% of C# online submissions for Similar String Groups.
        // 出息了...

        public int Try4(string[] strs)
        {

            /**
             * step:
             * 
             *      构建两个存储变量：
             *      
             *          reference ： reference[下标] = 标记对象
             *          dic: dic[标记对象] = 下标列表
             *      
             *     类似于多对多关系， 采用此种结构优化中间表的查询
             * 
             */

            int len = strs.Length;

            object[] reference = new object[len];

            Dictionary<object, List<int>> dic = new Dictionary<object, List<int>>();

            for (int i = 0; i < len; i++) // 遍历查找与当前项属于同一组的下标
            {
                ISet<object> same = new HashSet<object>();
                for (int j = 0; j < i; j++)
                {
                    if (IsMatch(strs[i], strs[j])) // optimize => 先查看是否已存在此组，再进行匹配
                    {
                        same.Add(reference[j]);
                    }
                }

                if (same.Count == 0) // 没找到则添加一个新的小组
                {
                    var obj = reference[i] = Guid.NewGuid().ToString("N"); // new object();
                    dic[obj] = new List<int> { i };
                }
                else // 找到了就合并所有的组 optimize => 不产生新组，直接用第一个组作为新租
                {
                    var newObj = Guid.NewGuid().ToString("N");// new object();
                    List<int> newList = new List<int>() { i };
                    foreach (var item in same)
                    {
                        dic.Remove(item, out var indexList);

                        newList.AddRange(indexList);
                        foreach (var index in indexList)
                        {
                            reference[index] = newObj;
                        }
                    }
                    dic[newObj] = newList;
                    reference[i] = newObj;
                }

            }

            return dic.Count;

        }

        class Empty
        {
            public object Obj { get; set; }
        }

        // bug
        public int Try3(string[] strs)
        {
            int len = strs.Length;

            Empty[] dp = new Empty[len];

            ISet<object> groupSet = new HashSet<object>();

            for (int i = 0; i < strs.Length; i++)
            {
                if (dp[i] != null) continue;
                ISet<Empty> same = new HashSet<Empty>();
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i == j) continue;
                    if (IsMatch(strs[i], strs[j]))
                        same.Add(dp[j]);
                }
                if (same.Count == 0)
                {
                    var obj = new object();
                    dp[i] = new Empty { Obj = obj };
                    groupSet.Add(obj);
                }
                else
                {
                    Empty first = null;
                    foreach (var item in same)
                    {
                        if (first == null)
                        {
                            first = item;
                        }
                        else
                        {
                            if (item.Obj != first.Obj)
                            {
                                groupSet.Remove(item.Obj);
                                item.Obj = first.Obj;
                            }
                        }
                    }
                    dp[i] = first;
                }
            }

            Check(strs, dp);

            return groupSet.Count;
        }

        bool IsMatch(string other, string curr)
        {
            bool match = true;

            int diffIndex = -1, diffCount = 0;
            for (int k = 0; k < other.Length; k++)
            {
                if (other[k] != curr[k])
                {
                    if (diffCount == 0)
                    {
                        match = false;
                        diffIndex = k;
                    }
                    else if (diffCount == 1)
                    {
                        if (!(other[k] == curr[diffIndex] && other[diffIndex] == curr[k]))
                        {
                            break;
                        }
                        match = true;
                    }
                    else
                    {
                        match = false;
                        break;
                    }
                    diffCount++;
                }
            }
            return match;
        }

        void Check(string[] strs, Empty[] dp)
        {
            int len = strs.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j || dp[i] == dp[j] || dp[i].Obj == dp[j].Obj) continue;

                    if (IsMatch(strs[i], strs[j]))
                    {

                    }

                }
            }
        }

        void Check(string[] strs, int[] dp, List<object> list)
        {
            int len = strs.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j || dp[i] == dp[j] || list[dp[i]] == list[dp[j]]) continue;

                    if (IsMatch(strs[i], strs[j]))
                    {

                    }

                }
            }
        }

        // bug
        public int Simple2(string[] strs)
        {
            int group = 1;
            int[] dp = new int[strs.Length];

            for (int i = 1; i < strs.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < i; j++)
                {

                    string left = strs[i], curr = strs[j];

                    int diffIndex = -1, diffCount = 0;
                    for (int k = 0; k < left.Length; k++)
                    {
                        if (left[k] != curr[k])
                        {
                            if (diffCount == 0)
                            {
                                match = false;
                                diffIndex = k;
                            }
                            else if (diffCount == 1)
                            {
                                if (!(left[k] == curr[diffIndex] && left[diffIndex] == curr[k]))
                                {
                                    break;
                                }
                                match = true;
                            }
                            else
                            {
                                match = false;
                                break;
                            }
                            diffCount++;
                        }
                    }

                    if (match)
                    {
                        dp[i] = dp[j];
                        break;
                    }
                }
                if (!match)
                {
                    dp[i] = group++;
                }
            }
            return group;
        }

        // 理解有误
        public int Simple(string[] strs)
        {
            int res = 0;
            for (int i = 1; i < strs.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {

                    string left = strs[i], curr = strs[j];

                    int diffIndex = -1, diffCount = 0;
                    bool match = false;
                    for (int k = 0; k < left.Length; k++)
                    {
                        if (left[k] != curr[k])
                        {
                            if (diffCount == 0) diffIndex = k;
                            else if (diffCount == 1)
                            {
                                if (!(left[k] == curr[diffIndex] && left[diffIndex] == curr[k]))
                                {
                                    break;
                                }
                                match = true;
                            }
                            else
                            {
                                match = false;
                                break;
                            }
                            diffCount++;
                        }
                    }

                    if (match)
                    {
                        res++;
                    }

                }
            }
            return res;
        }

    }
}
