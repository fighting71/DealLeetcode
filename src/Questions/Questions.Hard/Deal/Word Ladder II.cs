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
    /// @source : https://leetcode.com/problems/word-lAdder-ii/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Complex)]
    public class Word_Ladder_II
    {
        public IList<IList<string>> Solution(string beginWord, string endWord, IList<string> wordList)
        {
            IList<IList<string>> res = new List<IList<string>>();

            ISet<string> set = new HashSet<string>();

            foreach (var item in wordList)
            {
                set.Add(item);
            }

            if (!set.Contains(endWord)) return res;

            set.Add(beginWord);

            Dictionary<string, ISet<string>> canJumpDic = new Dictionary<string, ISet<string>>();

            foreach (var item in set)
            {
                canJumpDic[item] = GetNeighbors(item, set);
            }

            Queue<WorkItem> pending = new Queue<WorkItem>();
            pending.Enqueue(new WorkItem(new List<string>(), beginWord));
            Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
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
                    dic.Add(currWord, new List<List<string>> { new List<string>(workItem.Build) });
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

            public List<string> Build { get; set; }
            public string Word { get; set; }

            public WorkItem(List<string> build, string word) : this()
            {
                this.Build = build;
                this.Word = word;
            }
        }

        private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, IList<IList<string>> res)
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

        private ISet<String> GetNeighbors(String node, ISet<String> dict)
        {
            ISet<String> res = new HashSet<String>();
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

        // source:https://leetcode.com/problems/word-ladder-ii/discuss/40475/My-concise-JAVA-solution-based-on-BFS-and-DFS
        public class OtherSolution
        {
            public List<List<String>> FindLAdders(String start, String end, List<String> wordList)
            {
                HashSet<String> dict = new HashSet<String>(wordList);
                List<List<String>> res = new List<List<string>>();
                Dictionary<String, List<String>> nodeNeighbors = new Dictionary<String, List<String>>();// Neighbors for every node
                Dictionary<String, int> distance = new Dictionary<String, int>();// Distance of every node from the start node
                List<String> solution = new List<String>();

                dict.Add(start);
                bfs(start, end, dict, nodeNeighbors, distance);
                dfs(start, end, dict, nodeNeighbors, distance, solution, res);
                return res;
            }

            // BFS: Trace every node's distance from the start node (level by level).
            private void bfs(String start, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance)
            {
                foreach (String str in dict)
                    nodeNeighbors.Add(str, new List<String>());

                Queue<String> queue = new Queue<string>();
                queue.Enqueue(start);
                distance.Add(start, 0);

                while (queue.Count > 0)
                {
                    int count = queue.Count();
                    bool foundEnd = false;
                    for (int i = 0; i < count; i++)
                    {
                        String cur = queue.Dequeue();
                        int curDistance = distance[cur];
                        List<String> neighbors = getNeighbors(cur, dict);

                        foreach (String neighbor in neighbors)
                        {
                            nodeNeighbors[cur].Add(neighbor);
                            if (!distance.ContainsKey(neighbor))
                            {// Check if visited
                                distance.Add(neighbor, curDistance + 1);
                                if (end.Equals(neighbor))// Found the shortest path
                                    foundEnd = true;
                                else
                                    queue.Enqueue(neighbor);
                            }
                        }
                    }

                    if (foundEnd)
                        break;
                }
            }

            // *** 此处直接查看所有偏差一位字母的元素。
            // Find all next level nodes.    
            private List<String> getNeighbors(String node, HashSet<String> dict)
            {
                List<String> res = new List<String>();
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

            // DFS: output all paths with the shortest distance.
            private void dfs(String cur, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance, List<String> solution, List<List<String>> res)
            {
                solution.Add(cur);
                if (end.Equals(cur))
                {
                    res.Add(new List<String>(solution));
                }
                else
                {
                    foreach (String next in nodeNeighbors[cur])
                    {
                        if (distance[next] == distance[cur] + 1)
                        {
                            dfs(next, end, dict, nodeNeighbors, distance, solution, res);
                        }
                    }
                }
                solution.RemoveAt(solution.Count() - 1);
            }
        }

        public class Explain
        {
            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
            {
                /*
                 * Think:
                 *  注: A->B  此过程称为跳转
                 *  目标是最短的跳转路径
                 * 1.首先验证 endWord是否存在
                 * 2.先从一次跳转开始判断  判断完毕后 验证二次跳转
                 *      跳转次数不断累加，直至跳转到最终的目标停下
                 *      · 因为是从最小的次数开始，故得到的一个答案即是最短路径
                 * 3.找到路径后，检索相同长度的跳转，然后结束
                 * 
                 */
                List<List<string>> res = new List<List<string>>();

                if (!wordList.Contains(endWord)) return res;

                // 方便计算统一计入词典。
                wordList.Add(beginWord);

                // 由于在找路径时，会频繁验证是否能跳转，故可以先将所有可跳转的目录缓存下来。
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

                // 使用队列可方便存储要处理的项，方便按顺序执行。
                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), beginWord));
                Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
                while (pending.Count > 0)
                {
                    var workItem = pending.Dequeue();

                    // 若是已找到最佳路径且当前项的路径长大于最佳路径 直接结束。
                    if (res.Count > 0 && workItem.Build.Count == res[0].Count + 1) break;
                    // 当前项没有可跳转的目标。
                    if (!canJumpDic.ContainsKey(workItem.Word)) continue;
                    // 当前项可跳转至终点。
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

                    // 遍历可跳转的元素
                    foreach (var currWord in canJumpDic[workItem.Word])
                    {
                        // 元素已被跳转
                        if (workItem.Build.Contains(currWord)) continue;
                        // 元素已被其他项跳转 即元素相同的情况下，后面的最短路径有且至多一条
                        if (dic.ContainsKey(currWord))
                        {
                            // 路径长度相同则缓存。  A->B  C->B  no A->D->B
                            if (workItem.Build.Count == dic[currWord][0].Count)
                            {
                                dic[currWord].Add(workItem.Build);
                            }
                            continue;
                        }
                        dic.Add(currWord, new List<List<string>> { new List<string>(workItem.Build) });

                        // 更新已跳转元素，更新当前元素。1
                        var newBuild = new List<string>(workItem.Build);
                        newBuild.Add(currWord);

                        // 放入待处理工作项。
                        pending.Enqueue(new WorkItem(newBuild, currWord));
                    }
                }

                // 统一添加头和尾。
                foreach (var item in res)
                {
                    item.Insert(0, beginWord);
                    item.Add(endWord);
                }

                return res;
            }

            private struct WorkItem
            {
                /// <summary>
                /// 已跳转的字符串。
                /// </summary>
                public List<string> Build { get; set; }
                /// <summary>
                /// 当前跳转到的字符串.
                /// </summary>
                public string Word { get; set; }

                public WorkItem(List<string> build, string word) : this()
                {
                    this.Build = build;
                    this.Word = word;
                }
            }

            /// <summary>
            /// 从缓存中复制项
            /// </summary>
            /// <param name="list"></param>
            /// <param name="dic"></param>
            /// <param name="res"></param>
            private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, List<List<string>> res)
            {
                // 已添加部分，无须追加。
                int len = res.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    var str = list[i];

                    if (dic.ContainsKey(str))
                    {
                        foreach (var item in dic[str].Skip(1))
                        {
                            // 可能存在多次复用，故此处需要拷贝。
                            res.Add(new List<string>(item));
                            // 考虑缓存项中继续包含缓存项。
                            CopyHelp(item, dic, res);
                        }
                    }

                    foreach (var item in res.Skip(len))
                    {
                        item.Add(str);
                    }
                }
            }

            /// <summary>
            /// 是否仅相差一个字符【主要耗时.】
            /// </summary>
            /// <param name="str"></param>
            /// <param name="ta"></param>
            /// <returns></returns>
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


        // 更慢...
        public class Simple9
        {

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
            {
                List<List<string>> res = new List<List<string>>();

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

            private void CopyHelp(List<int> list, Dictionary<int, List<List<int>>> dic, List<List<string>> res, List<string> wordList)
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
            //Runtime: 1120 ms, faster than 40.57% of C# online submissions for Word LAdder II.
            //Memory Usage: 45.8 MB, less than 52.00% of C# online submissions for Word LAdder II.
            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
            {
                List<List<string>> res = new List<List<string>>();

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
                Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
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
                        dic.Add(currWord, new List<List<string>> { new List<string>(workItem.Build) });
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

                public List<string> Build { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, string word) : this()
                {
                    this.Build = build;
                    this.Word = word;
                }
            }

            private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, List<List<string>> res)
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
        /// Runtime: 1600 ms, faster than 21.72% of C# online submissions for Word LAdder II.
        /// Memory Usage: 45.9 MB, less than 52.00% of C# online submissions for Word LAdder II.
        /// </summary>
        class Simple7
        {

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
            {
                List<List<string>> res = new List<List<string>>();

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
                Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
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
                            dic.Add(currWord, new List<List<string>> { new List<string>(workItem.Build) });
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

                public List<string> Build { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, string word) : this()
                {
                    this.Build = build;
                    this.Word = word;
                }
            }

            private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, List<List<string>> res, ISet<string> ignore)
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
                public List<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, List<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
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

                List<List<string>> res = new List<List<string>>();

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));
                Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
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
                            //dic.Add(currWord, new List<List<string>> { workItem.Build });
                            dic.Add(currWord, new List<List<string>> { new List<string>(workItem.Build) });
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

            private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, List<List<string>> res, ISet<string> ignore)
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
                public List<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, List<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
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

                List<List<string>> res = new List<List<string>>();

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));
                Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
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
                            dic.Add(currWord, new List<List<string>> { workItem.Build });
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
            private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, List<List<string>> res, int end, ISet<string> ignore = null)
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
                public List<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, List<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
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

                List<List<string>> res = new List<List<string>>();

                Queue<WorkItem> pending = new Queue<WorkItem>();
                pending.Enqueue(new WorkItem(new List<string>(), wordList, beginWord));
                Dictionary<string, List<List<string>>> dic = new Dictionary<string, List<List<string>>>();
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
                            dic.Add(currWord, new List<List<string>> { workItem.Build });
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
            private void CopyHelp(List<string> list, Dictionary<string, List<List<string>>> dic, List<List<string>> res)
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
                public List<string> WordList { get; set; }
                public string Word { get; set; }

                public WorkItem(List<string> build, List<string> wordList, string word) : this()
                {
                    this.Build = build;
                    this.WordList = wordList;
                    this.Word = word;
                }
            }
            //optmize
            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
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

                List<List<string>> res = new List<List<string>>();

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
            private List<List<string>> _res;
            private Dictionary<string, bool> _cache = new Dictionary<string, bool>();

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
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

                _res = new List<List<string>>();

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

            private void Help(int index, bool[] used, List<string> wordList, List<string> build)
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
            private List<List<string>> _res;

            public List<List<string>> Simple(string beginWord, string endWord, List<string> wordList)
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

                _res = new List<List<string>>();

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

            private void Help(int index, bool[] used, List<string> wordList, List<string> build)
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
