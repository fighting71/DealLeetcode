using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/31/2021 5:06:07 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3691/
    /// @des : 
    ///     给定一个target,和stamp
    ///     能否通过stamp生成target?
    ///     生成方式=>
    ///         有一个和target一样长的build
    ///         每次你可以在位置x写下stamp [x>=0]
    ///         若与上一次生成有重叠部分则会进行覆盖
    ///     示例：
    ///         "abc", target = "ababc"
    ///         build:  "     "
    ///                 "abc  "(在位置0使用)
    ///                 "ababc"(在位置2使用)
    ///                 
    ///     target: 
    ///         返回每次使用的位置(按顺序返回)
    ///         若无法生成则返回空数组
    /// </summary>
    [Obsolete("复杂.")]
    public class Stamping_The_Sequence
    {

        // 1 <= stamp.length <= target.length <= 1000
        // stamp and target only contain lowercase letters.


        public int[] Try2(string stamp, string target)
        {

            int len = target.Length;

            List<int>[] dic = new List<int>[26];

            for (int i = 0; i < dic.Length; i++)
            {
                dic[i] = new List<int>();
            }

            for (int i = 0; i < stamp.Length; i++)
            {
                var c = stamp[i];
                dic[c - 'a'].Add(i);
            }

            int[] res = null;
            if (Help(0, 0, new List<int>()))
            {
                return res;
            }
            return Array.Empty<int>();

            bool Help(int i, int j, List<int> list, int? prev = null)
            {
                if (j == len)
                {
                    res = list.ToArray();
                    return true;
                }
                while (j < len)
                {
                    if (stamp[i] == target[j])
                    {
                        if (i == 0)
                        {
                            list.Add(j);
                            prev = j;
                        }
                        i++;
                        j++;
                        i %= stamp.Length;
                    }
                    else
                    {
                        if (!prev.HasValue) return false;
                        foreach (var item in dic[target[j] - 'a'])
                        {
                            if (item > j) continue;

                            // case 1 : 顺序覆盖
                            bool case1 = true;
                            for (int x = item - 1; x >= 0; x--)
                            {
                                if (stamp[x] != target[j + x - item])
                                {
                                    case1 = false;
                                    break;
                                }
                            }

                            if (case1)
                            {
                                var clone = new List<int>(list);

                                clone.Add(j - item);

                                if (Help((item + 1) % stamp.Length, j + 1, clone, j - item)) return true;

                                continue;
                            }

                            // case 2 : 反转替换
                            if (i == 0)
                            {
                                var clone = new List<int>(list);

                                clone.Insert(0, j - item);

                                if (Help((item + 1) % stamp.Length, j + 1, clone, j - item)) return true;
                            }

                        }
                        return false;
                    }
                }
                res = list.ToArray();
                return true;

            }

        }

        // bug
        public int[] Try(string stamp, string target)
        {

            int len = target.Length;

            List<int>[] dic = new List<int>[26];

            for (int i = 0; i < dic.Length; i++)
            {
                dic[i] = new List<int>();
            }

            for (int i = 0; i < stamp.Length; i++)
            {
                var c = stamp[i];
                dic[c - 'a'].Add(i);
            }

            int[] res = null;
            if (Help(0, 0, new List<int>()))
            {
                return res;
            }
            return Array.Empty<int>();

            bool Help(int i, int j, List<int> list)
            {
                if (j == len)
                {
                    res = list.ToArray();
                    return true;
                }
                while (j < len)
                {
                    if (stamp[i] == target[j])
                    {
                        if (i == 0)
                        {
                            list.Add(j);
                        }
                        i++;
                        j++;
                        i %= stamp.Length;
                    }
                    else
                    {
                        if (list.Count == 0) return false;
                        foreach (var item in dic[target[j] - 'a'])
                        {
                            if (item > j) continue;

                            var prev = list[list.Count - 1];

                            // case 1 : 顺序覆盖
                            bool case1 = true;
                            for (int x = item - 1; x > 0; x--)
                            {
                                if (stamp[x] != target[j + x - item])
                                {
                                    case1 = false;
                                    break;
                                }
                            }

                            if (case1)
                            {
                                var clone = new List<int>(list);

                                clone.Add(j - item);

                                if (Help(item + 1 % stamp.Length, j + 1, clone)) return true;

                                continue;
                            }

                            // case 2 : 反转替换
                            if (i != 0) continue;
                            bool case2 = true;
                            for (int x = 1; x < item; x++)
                            {
                                if (stamp[stamp.Length - x] != target[j - x])
                                {
                                    case2 = false;
                                    break;
                                }
                            }

                            if (case2)
                            {
                                var clone = new List<int>(list);

                                clone.Insert(0, j - item);

                                if (Help(item + 1 % stamp.Length, j + 1, clone)) return true;
                            }

                        }
                        return false;
                    }
                }
                res = list.ToArray();
                return true;

            }

        }

    }
}
