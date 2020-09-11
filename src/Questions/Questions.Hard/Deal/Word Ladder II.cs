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
    [Obsolete("bug")]
    public class Word_Ladder_II
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
                            CopyHelp(workItem.Build, dic, res, workItem.Build.Count, ignore);
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
                            CopyHelp(workItem.Build, dic, res, workItem.Build.Count, ignore);
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

        private void CopyHelp(IList<string> list, Dictionary<string, List<IList<string>>> dic, IList<IList<string>> res, int end, ISet<string> ignore)
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
                        ignore.Add(str);
                        res.Add(new List<string>(item));
                        CopyHelp(item, dic, res, i - 1, ignore);
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
