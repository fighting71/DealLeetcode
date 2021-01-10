using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.January.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/10/2021 11:51:30 AM
    /// @source : https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3598/
    /// @des : 
    ///     hard question.
    ///     与 Word_Ladder_II 相差不大.
    ///     给定两个单词beginWord和endWord，以及一个字典单词列表，返回从beginWord到endWord的最短转换序列的长度，这样:
    ///     一次只能改变一个字母。
    ///     每个转换后的单词必须存在于单词列表中。
    ///     如果没有这样的转换序列，则返回0。
    /// </summary>
    public class Word_Ladder
    {

        // 1 <= beginWord.length <= 100
        // endWord.length == beginWord.length
        //1 <= wordList.length <= 5000
        //wordList[i].length == beginWord.length
        //beginWord, endWord, and wordList[i] consist of lowercase English letters.
        //beginWord != endWord

        // Your runtime beats 32.63 %
        // 可简化 Build 替换为坐标，且将 dic 替换为 bool[],简化canJumpDic的获取
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            ISet<string> set = new HashSet<string>();

            foreach (var item in wordList)
            {
                set.Add(item);
            }

            if (!set.Contains(endWord)) return 0;

            set.Add(beginWord);

            Dictionary<string, ISet<string>> canJumpDic = new Dictionary<string, ISet<string>>();

            foreach (var item in set)
            {
                canJumpDic[item] = GetNeighbors(item, set);
            }

            Queue<WorkItem> pending = new Queue<WorkItem>();
            pending.Enqueue(new WorkItem(new HashSet<string>(), beginWord));
            ISet<string> dic = new HashSet<string>();
            while (pending.Count > 0)
            {
                var workItem = pending.Dequeue();

                if (!canJumpDic.ContainsKey(workItem.Word)) continue;
                if (canJumpDic[workItem.Word].Contains(endWord))
                {
                    return workItem.Build.Count + 2;
                }

                foreach (var currWord in canJumpDic[workItem.Word])
                {
                    if (workItem.Build.Contains(currWord)) continue;
                    if (dic.Contains(currWord))
                    {
                        continue;
                    }
                    dic.Add(currWord);
                    var newBuild = new HashSet<string>(workItem.Build)
                    {
                        currWord
                    };

                    pending.Enqueue(new WorkItem(newBuild, currWord));
                }
            }

            return 0;
        }

        private struct WorkItem
        {
            public ISet<string> Build { get; set; }
            public string Word { get; set; }

            public WorkItem(ISet<string> build, string word) : this()
            {
                this.Build = build;
                this.Word = word;
            }
        }

        private ISet<string> GetNeighbors(string node, ISet<string> dict)
        {
            ISet<string> res = new HashSet<string>();
            char[] chs = node.ToCharArray();

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                for (int i = 0; i < chs.Length; i++)
                {
                    if (chs[i] == ch) continue;
                    char old_ch = chs[i];
                    chs[i] = ch;
                    var str = new string(chs);
                    if (dict.Contains(str))
                    {
                        res.Add(str);
                    }
                    chs[i] = old_ch;
                }

            }
            return res;
        }
    }
}
