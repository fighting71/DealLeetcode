using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/11/2020 2:43:42 PM
    /// @source : https://leetcode.com/problems/word-ladder-ii/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Complex)]
    public class Word_Ladder_II
    {
        public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
        {
            IList<IList<string>> res = new List<IList<string>>();

            if (!wordList.Contains(endWord)) return res;

            wordList.Add(beginWord);

            int len = wordList.Count, win = -1;

            bool[][] flag = new bool[len][];

            for (int i = 0; i < len; i++)
            {
                flag[i] = new bool[len];
            }

            for (int i = 0; i < wordList.Count; i++)
            {
                if (win < 0 && wordList[i] == endWord) win = i;
                for (int j = 0; j < wordList.Count; j++)
                {
                    if (i == j) continue;
                    flag[i][j] = flag[j][i] = DiffOne(wordList[i], wordList[j]);
                }
            }

            return res;

            Queue<WorkItem> pending = new Queue<WorkItem>();
            pending.Enqueue(new WorkItem(new List<int>(), len - 1));
            Dictionary<int, List<List<int>>> dic = new Dictionary<int, List<List<int>>>();
            while (pending.Count > 0)
            {
                var workItem = pending.Dequeue();

                if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;
                if (flag[workItem.Index][win])
                {
                    res.Add(workItem.Build.Select(u => wordList[u]).ToList());
                    CopyHelp(workItem.Build, dic, res, wordList);
                    continue;
                }
                if (res.Count > 0) continue;

                for (int i = 0; i < len; i++)
                {
                    if (!flag[workItem.Index][i]) continue;
                    if (workItem.Build.Contains(i)) continue;
                    if (dic.ContainsKey(i))
                    {
                        if (workItem.Build.Count == dic[i][0].Count)
                        {
                            dic[i].Add(workItem.Build);
                        }
                        continue;
                    }
                    dic.Add(i, new List<List<int>> { new List<int>(workItem.Build) });
                    var newBuild = new List<int>(workItem.Build);
                    newBuild.Add(i);

                    pending.Enqueue(new WorkItem(newBuild, i));
                }
            }

            foreach (var item in res)
            {
                item.Insert(0, beginWord);
                item.Add(endWord);
            }

            return res;
        }

        private struct WorkItem
        {

            public List<int> Build { get; set; }
            public int Index { get; set; }

            public WorkItem(List<int> build, int index) : this()
            {
                this.Build = build;
                this.Index = index;
            }
        }

        private void CopyHelp(IList<int> list, Dictionary<int, List<List<int>>> dic, IList<IList<string>> res, IList<string> wordList)
        {
            int len = res.Count;
            foreach (var index in list)
            {
                if (dic.ContainsKey(index))
                    foreach (var item in dic[index].Skip(1))
                    {
                        res.Add(item.Select(u => wordList[u]).ToList());
                        CopyHelp(item, dic, res, wordList);
                    }

                foreach (var item in res.Skip(len))
                    item.Add(wordList[index]);
            }
        }

        // unsafe
        public static unsafe bool IsMutationOne(string seq1, string seq2)
        {
            bool isfind = false;
            fixed (char* pseq1 = seq1)
            {
                fixed (char* pseq2 = seq2)
                {
                    char* p1 = pseq1;
                    char* p2 = pseq2;
                    for (int i = 0; i < seq1.Length; i++)
                    {
                        if (*p1 != *p2)
                        {
                            if (isfind)
                                return false;
                            else
                                isfind = true;
                        }
                        p1++; p2++;
                    }
                }
            }
            return isfind;
        }

        // *** key 关键耗时...
        private bool DiffOne(string str, string ta)
        {
            bool diff = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ta[i])
                {
                    if (diff) return false;
                    else diff = true;
                }
            }

            return diff;

        }

        // 更慢...
        public class Simple9
        {

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                IList<IList<string>> res = new List<IList<string>>();

                if (!wordList.Contains(endWord)) return res;

                wordList.Add(beginWord);

                int len = wordList.Count, win = -1;

                bool[][] flag = new bool[len][];

                for (int i = 0; i < len; i++)
                {
                    flag[i] = new bool[len];
                }

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (win < 0 && wordList[i] == endWord) win = i;
                    for (int j = 0; j < wordList.Count; j++)
                    {
                        if (i == j) continue;
                        flag[i][j] = flag[j][i] = DiffOne(wordList[i], wordList[j]);
                    }
                }

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<int>(), len - 1));
                Dictionary<int, List<List<int>>> dic = new Dictionary<int, List<List<int>>>();
                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;
                    if (flag[workItem.Index][win])
                    {
                        res.Add(workItem.Build.Select(u => wordList[u]).ToList());
                        CopyHelp(workItem.Build, dic, res, wordList);
                        continue;
                    }
                    if (res.Count > 0) continue;

                    for (int i = 0; i < len; i++)
                    {
                        if (!flag[workItem.Index][i]) continue;
                        if (workItem.Build.Contains(i)) continue;
                        if (dic.ContainsKey(i))
                        {
                            if (workItem.Build.Count == dic[i][0].Count)
                            {
                                dic[i].Add(workItem.Build);
                            }
                            continue;
                        }
                        dic.Add(i, new List<List<int>> { new List<int>(workItem.Build) });
                        var newBuild = new List<int>(workItem.Build);
                        newBuild.Add(i);

                        pending.Enqueue(new WorkItem(newBuild, i));
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            private struct WorkItem
            {

                public List<int> Build { get; set; }
                public int Index { get; set; }

                public WorkItem(List<int> build, int index) : this()
                {
                    this.Build = build;
                    this.Index = index;
                }
            }

            private void CopyHelp(IList<int> list, Dictionary<int, List<List<int>>> dic, IList<IList<string>> res, IList<string> wordList)
            {
                int len = res.Count;
                foreach (var index in list)
                {
                    if (dic.ContainsKey(index))
                        foreach (var item in dic[index].Skip(1))
                        {
                            res.Add(item.Select(u => wordList[u]).ToList());
                            CopyHelp(item, dic, res, wordList);
                        }

                    foreach (var item in res.Skip(len))
                        item.Add(wordList[index]);
                }
            }

            private bool DiffOne(string str, string ta)
            {
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ta[i])
                    {
                        if (diff) return false;
                        else diff = true;
                    }
                }

                return diff;

            }

        }

        public class Simple8
        {
            //Runtime: 1120 ms, faster than 40.57% of C# online submissions for Word Ladder II.
            //Memory Usage: 45.8 MB, less than 52.00% of C# online submissions for Word Ladder II.
            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                IList<IList<string>> res = new List<IList<string>>();

                if (!wordList.Contains(endWord)) return res;

                wordList.Add(beginWord);

                Dictionary<string, ISet<string>> canJumpDic = new Dictionary<string, ISet<string>>();

                for (int i = 0; i < wordList.Count; i++)
                {
                    for (int j = 0; j < wordList.Count; j++)
                    {
                        if (i == j) continue;
                        if (DiffOne(wordList[i], wordList[j]))
                        {
                            if (canJumpDic.ContainsKey(wordList[i]))
                            {
                                canJumpDic[wordList[i]].Add(wordList[j]);
                            }
                            else
                            {
                                canJumpDic[wordList[i]] = new HashSet<string>() { wordList[j] };
                            }

                            if (canJumpDic.ContainsKey(wordList[j]))
                            {
                                canJumpDic[wordList[j]].Add(wordList[i]);
                            }
                            else
                            {
                                canJumpDic[wordList[j]] = new HashSet<string>() { wordList[i] };
                            }
                        }
                    }
                }

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), beginWord));
                Dictionary<string, List<IList<string>>> dic = new Dictionary<string, List<IList<string>>>();
                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;
                    if (!canJumpDic.ContainsKey(workItem.Word)) continue;
                    if (canJumpDic[workItem.Word].Contains(endWord))
                    {
                        res.Add(workItem.Build);
                        CopyHelp(workItem.Build, dic, res);
                        continue;
                    }
                    if (res.Count > 0)
                    {
                        continue;
                    }

                    foreach (var currWord in canJumpDic[workItem.Word])
                    {
                        if (workItem.Build.Contains(currWord)) continue;
                        if (dic.ContainsKey(currWord))
                        {
                            if (workItem.Build.Count == dic[currWord][0].Count)
                            {
                                dic[currWord].Add(workItem.Build);
                            }
                            continue;
                        }
                        dic.Add(currWord, new List<IList<string>> { new List<string>(workItem.Build) });
                        var newBuild = new List<string>(workItem.Build);
                        newBuild.Add(currWord);

                        pending.Enqueue(new WorkItem(newBuild, currWord));
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            private struct WorkItem
            {

                public IList<string> Build { get; set; }
                public string Word { get; set; }

                public WorkItem(IList<string> build, string word) : this()
                {
                    this.Build = build;
                    this.Word = word;
                }
            }

            private void CopyHelp(IList<string> list, Dictionary<string, List<IList<string>>> dic, IList<IList<string>> res)
            {
                int len = res.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    var str = list[i];

                    if (dic.ContainsKey(str))
                    {
                        foreach (var item in dic[str].Skip(1))
                        {
                            res.Add(new List<string>(item));
                            CopyHelp(item, dic, res);
                        }
                    }

                    foreach (var item in res.Skip(len))
                    {
                        item.Add(str);
                    }
                }
            }

            private bool DiffOne(string str, string ta)
            {
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ta[i])
                    {
                        if (diff) return false;
                        else diff = true;
                    }
                }

                return diff;

            }

        }
        /// <summary>
        /// Runtime: 1600 ms, faster than 21.72% of C# online submissions for Word Ladder II.
        /// Memory Usage: 45.9 MB, less than 52.00% of C# online submissions for Word Ladder II.
        /// </summary>
        class Simple7
        {

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                IList<IList<string>> res = new List<IList<string>>();

                if (!wordList.Contains(endWord)) return res;

                wordList.Add(beginWord);

                Dictionary<string, ISet<string>> canJumpDic = new Dictionary<string, ISet<string>>();

                for (int i = 0; i < wordList.Count; i++)
                {
                    for (int j = 0; j < wordList.Count; j++)
                    {
                        if (i == j) continue;
                        if (DiffOne(wordList[i], wordList[j]))
                        {
                            if (canJumpDic.ContainsKey(wordList[i]))
                            {
                                canJumpDic[wordList[i]].Add(wordList[j]);
                            }
                            else
                            {
                                canJumpDic[wordList[i]] = new HashSet<string>() { wordList[j] };
                            }

                            if (canJumpDic.ContainsKey(wordList[j]))
                            {
                                canJumpDic[wordList[j]].Add(wordList[i]);
                            }
                            else
                            {
                                canJumpDic[wordList[j]] = new HashSet<string>() { wordList[i] };
                            }
                        }
                    }
                }

                //return res;

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), beginWord));
                Dictionary<string, List<IList<string>>> dic = new Dictionary<string, List<IList<string>>>();
                ISet<string> ignore = new HashSet<string>();
                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;
                    if (!canJumpDic.ContainsKey(workItem.Word)) continue;
                    foreach (var currWord in canJumpDic[workItem.Word])
                    {
                        if (workItem.Build.Contains(currWord)) continue;
                        if (dic.ContainsKey(currWord))
                        {
                            if (workItem.Build.Count == dic[currWord][0].Count && DiffOne(currWord, workItem.Word))
                            {
                                dic[currWord].Add(workItem.Build);
                            }
                            continue;
                        }

                        if (res.Count > 0)
                        {
                            if (DiffOne(endWord, workItem.Word))
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res, ignore);
                                break;
                            }
                            continue;
                        }
                        if (DiffOne(currWord, workItem.Word))
                        {
                            if (currWord == endWord)
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res, ignore);
                                break;
                            }
                            dic.Add(currWord, new List<IList<string>> { new List<string>(workItem.Build) });
                            var newBuild = new List<string>(workItem.Build);
                            newBuild.Add(currWord);

                            pending.Enqueue(new WorkItem(newBuild, currWord));
                        }
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            private struct WorkItem
            {

                public IList<string> Build { get; set; }
                public string Word { get; set; }

                public WorkItem(IList<string> build, string word) : this()
                {
                    this.Build = build;
                    this.Word = word;
                }
            }

            private void CopyHelp(IList<string> list, Dictionary<string, List<IList<string>>> dic, IList<IList<string>> res, ISet<string> ignore)
            {
                int len = res.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    var str = list[i];

                    if (ignore != null && ignore.Contains(str)) continue;

                    if (dic.ContainsKey(str))
                    {
                        //ignore.Add(str);
                        foreach (var item in dic[str].Skip(1))
                        {
                            // item 可能会被多个 str 导航，故不可直接使用.
                            res.Add(new List<string>(item));
                            //res.Add(item);
                            CopyHelp(item, dic, res, ignore);
                        }
                    }

                    foreach (var item in res.Skip(len))
                    {
                        item.Add(str);
                    }
                }
            }

            private bool DiffOne(string str, string ta)
            {
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ta[i])
                    {
                        if (diff) return false;
                        else diff = true;
                    }
                }

                return diff;

            }

        }

        // time limit
        class Simple6
        {

            private struct WorkItem
            {

                public List<string> Build { get; set; }
                public IList<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, IList<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                wordList.Remove(beginWord);
                for (int i = 0; i < wordList.Count; i++)
                {
                    if (wordList[i] == beginWord)
                    {
                        wordList.RemoveAt(i);
                        i--;
                    }
                }

                IList<IList<string>> res = new List<IList<string>>();

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));
                Dictionary<string, List<IList<string>>> dic = new Dictionary<string, List<IList<string>>>();
                string currWord;
                ISet<string> ignore = new HashSet<string>();

                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;

                    for (int j = 0; j < workItem.WordList.Count; j++)
                    {
                        currWord = workItem.WordList[j];

                        if (res.Count > 0)
                        {
                            if (DiffOne(endWord, workItem.Word))
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res, ignore);
                                break;
                            }
                            continue;
                        }
                        if (DiffOne(currWord, workItem.Word))
                        {
                            if (dic.ContainsKey(currWord))
                            {
                                if (workItem.Build.Count == dic[currWord][0].Count)
                                {
                                    //dic[currWord].Add(new List<string>(workItem.Build));
                                    dic[currWord].Add(workItem.Build);
                                }
                                continue;
                            }
                            if (currWord == endWord)
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res, ignore);
                                break;
                            }
                            //dic.Add(currWord, new List<IList<string>> { workItem.Build });
                            dic.Add(currWord, new List<IList<string>> { new List<string>(workItem.Build) });
                            // 此处应复制workItem.WordList 而非 wordList
                            var newList = new List<string>(workItem.WordList);
                            newList.RemoveAt(j);
                            var newBuild = new List<string>(workItem.Build);
                            newBuild.Add(currWord);

                            pending.Enqueue(new WorkItem(newBuild, newList, workItem.WordList[j]));
                        }
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            private void CopyHelp(IList<string> list, Dictionary<string, List<IList<string>>> dic, IList<IList<string>> res, ISet<string> ignore)
            {
                int len = res.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    var str = list[i];

                    if (ignore != null && ignore.Contains(str)) continue;

                    if (dic.ContainsKey(str))
                    {
                        ignore.Add(str);
                        foreach (var item in dic[str].Skip(1))
                        {
                            // item 可能会被多个 str 导航，故不可直接使用.
                            res.Add(new List<string>(item));
                            //res.Add(item);
                            CopyHelp(item, dic, res, ignore);
                        }
                    }

                    foreach (var item in res.Skip(len))
                    {
                        item.Add(str);
                    }
                }
            }

            private Dictionary<string, bool> _cache = new Dictionary<string, bool>();
            private bool DiffOne(string str, string ta)
            {
                var key = str + ' ' + ta;
                if (_cache.ContainsKey(key)) return _cache[key];
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ta[i]) continue;
                    if (diff)
                    {
                        _cache[key] = false;
                        _cache[ta + " " + str] = false;
                        return false;
                    }
                    diff = true;
                }

                _cache[key] = true;
                _cache[ta + " " + str] = true;

                return true;

            }

        }

        // bug
        class Simple5
        {

            private struct WorkItem
            {

                public List<string> Build { get; set; }
                public IList<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, IList<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                wordList.Remove(beginWord);
                for (int i = 0; i < wordList.Count; i++)
                {
                    if (wordList[i] == beginWord)
                    {
                        wordList.RemoveAt(i);
                        i--;
                    }
                }

                IList<IList<string>> res = new List<IList<string>>();

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));
                Dictionary<string, List<IList<string>>> dic = new Dictionary<string, List<IList<string>>>();
                string currWord;

                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;

                    for (int j = 0; j < workItem.WordList.Count; j++)
                    {
                        currWord = workItem.WordList[j];

                        if (res.Count > 0)
                        {
                            if (DiffOne(endWord, workItem.Word))
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res, workItem.Build.Count);
                                break;
                            }
                            continue;
                        }
                        if (DiffOne(currWord, workItem.Word))
                        {
                            if (dic.ContainsKey(currWord))
                            {
                                if (workItem.Build.Count == dic[currWord][0].Count)
                                {
                                    dic[currWord].Add(workItem.Build);
                                }
                                continue;
                            }
                            if (currWord == endWord)
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res, workItem.Build.Count);
                                break;
                            }
                            dic.Add(currWord, new List<IList<string>> { workItem.Build });
                            // 此处应复制workItem.WordList 而非 wordList
                            var newList = new List<string>(workItem.WordList);
                            newList.RemoveAt(j);
                            var newBuild = new List<string>(workItem.Build);
                            newBuild.Add(currWord);

                            pending.Enqueue(new WorkItem(newBuild, newList, workItem.WordList[j]));
                        }
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }
            // fix
            private void CopyHelp(IList<string> list, Dictionary<string, List<IList<string>>> dic, IList<IList<string>> res, int end, ISet<string> ignore = null)
            {
                int len = res.Count;
                for (int i = 0; i < end; i++)
                {
                    var str = list[i];
                    if (ignore != null && ignore.Contains(str)) continue;
                    if (dic.ContainsKey(str))
                    {
                        foreach (var item in dic[str].Skip(1))
                        {
                            res.Add(item);
                            ignore = ignore ?? new HashSet<string>();
                            ignore.Add(str);
                            CopyHelp(item, dic, res, i, ignore);
                        }
                    }
                    foreach (var item in res.Skip(len))
                    {
                        item.Add(str);
                    }
                }
            }

            private Dictionary<string, bool> _cache = new Dictionary<string, bool>();
            private bool DiffOne(string str, string ta)
            {
                var key = str + ' ' + ta;
                if (_cache.ContainsKey(key)) return _cache[key];
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ta[i]) continue;
                    if (diff)
                    {
                        _cache[key] = false;
                        _cache[ta + " " + str] = false;
                        return false;
                    }
                    diff = true;
                }

                _cache[key] = true;
                _cache[ta + " " + str] = true;

                return true;

            }

        }

        // bug
        class Simple4
        {

            private struct WorkItem
            {

                public List<string> Build { get; set; }
                public IList<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, IList<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                wordList.Remove(beginWord);
                for (int i = 0; i < wordList.Count; i++)
                {
                    if (wordList[i] == beginWord)
                    {// wordList 可能存在beginWord  删除为避免来回跳...
                        wordList.RemoveAt(i);
                        i--;
                    }
                }

                IList<IList<string>> res = new List<IList<string>>();

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));
                Dictionary<string, List<IList<string>>> dic = new Dictionary<string, List<IList<string>>>();
                string currWord;

                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;

                    for (int j = 0; j < workItem.WordList.Count; j++)
                    {
                        currWord = workItem.WordList[j];

                        if (res.Count > 0)
                        {
                            if (DiffOne(endWord, workItem.Word))
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res);
                                break;
                            }
                            continue;
                        }
                        if (DiffOne(currWord, workItem.Word))
                        {
                            if (dic.ContainsKey(currWord))
                            {
                                if (workItem.Build.Count == dic[currWord][0].Count)
                                {
                                    dic[currWord].Add(workItem.Build);
                                }
                                continue;
                            }
                            if (currWord == endWord)
                            {
                                res.Add(workItem.Build);
                                CopyHelp(workItem.Build, dic, res);
                                break;
                            }
                            dic.Add(currWord, new List<IList<string>> { workItem.Build });
                            // 此处应复制workItem.WordList 而非 wordList
                            var newList = new List<string>(workItem.WordList);
                            newList.RemoveAt(j);
                            var newBuild = new List<string>(workItem.Build);
                            newBuild.Add(currWord);

                            pending.Enqueue(new WorkItem(newBuild, newList, workItem.WordList[j]));
                        }
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            // bug 
            private void CopyHelp(List<string> list, Dictionary<string, List<IList<string>>> dic, IList<IList<string>> res)
            {
                int len = res.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    var str = list[i];
                    if (dic.ContainsKey(str))
                    {
                        foreach (var item in dic[str].Skip(1))
                        {
                            res.Add(item);// *** 此处新加入的item应参与CopyHelp...
                        }
                    }
                    foreach (var item in res.Skip(len))
                    {
                        item.Add(str);
                    }
                }
            }

            private Dictionary<string, bool> _cache = new Dictionary<string, bool>();
            private bool DiffOne(string str, string ta)
            {
                var key = str + ' ' + ta;
                if (_cache.ContainsKey(key)) return _cache[key];
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ta[i]) continue;
                    if (diff)
                    {
                        _cache[key] = false;
                        _cache[ta + " " + str] = false;
                        return false;
                    }
                    diff = true;
                }

                _cache[key] = true;
                _cache[ta + " " + str] = true;

                return true;

            }


        }

        // timelimit
        class Simple3
        {


            private struct WorkItem
            {

                public List<string> Build { get; set; }
                public IList<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, IList<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }
            //optmize
            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                int _targetIndex = -1, min = int.MaxValue;
                wordList.Remove(beginWord);
                for (int i = 0; i < wordList.Count; i++)
                {
                    if (wordList[i] == endWord)
                    {
                        _targetIndex = i;
                    }
                    if (wordList[i] == beginWord)
                    {// wordList 可能存在beginWord  删除为避免来回跳...
                        wordList.RemoveAt(i);
                        i--;
                    }
                }

                IList<IList<string>> res = new List<IList<string>>();

                if (_targetIndex == -1) return res;

                bool nonRes = true;

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));

                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    if (workItem.Build.Count == min + 1) break;

                    for (int j = 0; j < workItem.WordList.Count; j++)
                    {
                        if (!nonRes)
                        {
                            if (DiffOne(endWord, workItem.Word))
                            {
                                res.Add(new List<string>(workItem.Build));
                                break;
                            }
                            continue;
                        }
                        if (DiffOne(workItem.WordList[j], workItem.Word))
                        {
                            if (workItem.WordList[j] == endWord)
                            {
                                nonRes = false;
                                min = workItem.Build.Count;
                                res.Add(new List<string>(workItem.Build));
                                break;
                            }
                            // 此处应复制workItem.WordList 而非 wordList
                            var newList = new List<string>(workItem.WordList);
                            newList.RemoveAt(j);
                            var newBuild = new List<string>(workItem.Build);
                            newBuild.Add(workItem.WordList[j]);

                            pending.Enqueue(new WorkItem(newBuild, newList, workItem.WordList[j]));
                        }
                    }
                }

                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            private Dictionary<string, bool> _cache = new Dictionary<string, bool>();
            private bool DiffOne(string str, string ta)
            {
                var key = str + ' ' + ta;
                if (_cache.ContainsKey(key)) return _cache[key];
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ta[i]) continue;
                    if (diff)
                    {
                        _cache[key] = false;
                        _cache[ta + " " + str] = false;
                        return false;
                    }
                    diff = true;
                }

                _cache[key] = true;
                _cache[ta + " " + str] = true;

                return true;

            }


        }

        // time out
        class Simple2
        {

            private int _targetIndex = -1;
            private int _minLen;
            private IList<IList<string>> _res;
            private Dictionary<string, bool> _cache = new Dictionary<string, bool>();

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                _targetIndex = -1;
                for (int i = 0; i < wordList.Count; i++)
                {
                    if (wordList[i] == endWord)
                    {
                        _targetIndex = i;
                        break;
                    }
                }

                _res = new List<IList<string>>();

                if (_targetIndex == -1) return _res;

                _minLen = int.MaxValue;

                bool[] used = new bool[wordList.Count];

                List<string> build = new List<string>() { beginWord };

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (DiffOne(beginWord, wordList[i]))
                    {
                        used[i] = true;
                        Help(i, used, wordList, build);
                        used[i] = false;
                    }
                }

                foreach (var item in _res)
                {
                    item.Add(endWord);
                }

                return _res;
            }

            private void Help(int index, bool[] used, IList<string> wordList, List<string> build)
            {
                if (_targetIndex == index)
                {
                    if (build.Count < _minLen)
                    {
                        _res.Clear();
                        _minLen = build.Count;
                    }
                    _res.Add(new List<string>(build));
                    return;
                }
                if (build.Count == _minLen)
                {
                    return;
                }
                build.Add(wordList[index]);

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (used[i]) continue;
                    if (DiffOne(wordList[index], wordList[i]))
                    {
                        used[i] = true;
                        Help(i, used, wordList, build);
                        used[i] = false;
                    }
                }
                build.RemoveAt(build.Count - 1);

            }

            // Optimize
            private bool DiffOne(string str, string ta)
            {
                var key = str + ' ' + ta;
                if (_cache.ContainsKey(key)) return _cache[key];
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ta[i]) continue;
                    if (diff)
                    {
                        _cache[key] = false;
                        _cache[ta + " " + str] = false;
                        return false;
                    }
                    diff = true;
                }

                _cache[key] = true;
                _cache[ta + " " + str] = true;

                return true;

            }


        }

        // Timeout
        class Simple1
        {

            private int _targetIndex = -1;
            private int _minLen;
            private IList<IList<string>> _res;

            public IList<IList<string>> Simple(string beginWord, string endWord, IList<string> wordList)
            {
                _targetIndex = -1;
                for (int i = 0; i < wordList.Count; i++)
                {
                    if (wordList[i] == endWord)
                    {
                        _targetIndex = i;
                        break;
                    }
                }

                _res = new List<IList<string>>();

                if (_targetIndex == -1) return _res;

                _minLen = int.MaxValue;

                bool[] used = new bool[wordList.Count];

                List<string> build = new List<string>() { beginWord };

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (DiffOne(beginWord, wordList[i]))
                    {
                        used[i] = true;
                        Help(i, used, wordList, build);
                        used[i] = false;
                    }
                }

                foreach (var item in _res)
                {
                    item.Add(endWord);
                }

                return _res;
            }

            private void Help(int index, bool[] used, IList<string> wordList, List<string> build)
            {
                if (_targetIndex == index)
                {
                    if (build.Count < _minLen)
                    {
                        _res.Clear();
                        _minLen = build.Count;
                    }
                    _res.Add(new List<string>(build));
                    return;
                }
                if (build.Count == _minLen)
                {
                    return;
                }
                build.Add(wordList[index]);

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (used[i]) continue;
                    if (DiffOne(wordList[index], wordList[i]))
                    {
                        used[i] = true;
                        Help(i, used, wordList, build);
                        used[i] = false;
                    }
                }
                build.RemoveAt(build.Count - 1);

            }

            /// <summary>
            /// diff one -> can jump: str==>ta
            /// </summary>
            private bool DiffOne(string str, string ta)
            {
                bool diff = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ta[i]) continue;
                    if (diff) return false;
                    diff = true;
                }

                return true;

            }


        }

    }
}
