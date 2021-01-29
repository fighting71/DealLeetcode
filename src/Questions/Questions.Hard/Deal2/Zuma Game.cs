using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 6:27:24 PM
    /// @source : https://leetcode.com/problems/zuma-game/
    /// @des : 
    ///     想想《祖玛》。你有一排球在桌子上，颜色有红(R)，黄(Y)，蓝(B)，绿(G)和白(W)。你手里也有几个球。
    ///     每次，你可以选择手中的球，并将其插入一行(包括最左和最右的位置)。然后，如果有3个或3个以上相同颜色的球接触，就把这些球移开【坑：当有超过3个以上的相同颜色时，你可以选择删除3个或者全部删除...（没玩过这祖玛）】。一直这样做，直到没有更多的球可以移除。
    ///     找出最少使用多少个球，以删除所有球在桌子上。如果不能删除所有的球，则输出-1。
    /// </summary>
    public class Zuma_Game
    {

        // You may assume that the initial row of balls on the table won’t have any 3 or more consecutive balls with the same color.
        //1 <= board.length <= 16
        //1 <= hand.length <= 5
        //Both input strings will be non-empty and only contain characters 'R','Y','B','G','W'.

        class Item
        {
            public char Char { get; set; }
            public int Count { get; set; }
        }

        // 1.format board  [case: RR -> {R,2} RRBBG-> {R,2}{B,2}{G,1} => list(ele,ele2,ele3)]
        // 2.each list
        //  if hand has ele.Char && hand[ele].Count + ele.Count >= 3 (can remove this ele)
        //      remove ele AND cut list [case: RRBBRR (add B) -> RRBBBRR -> RRRR -> empty ]
        //      confirm:  if after cut ele.Count > 3 you can {remove all} or {remove 3 count} [case: RRBBRR -> RRRR(count > 3) -> R or empty]

        public int Explain(string board, string hand)
        {
            #region get count dic
            Dictionary<char, int> countDic = new Dictionary<char, int>();

            foreach (var c in hand)
            {
                if (countDic.ContainsKey(c)) countDic[c]++;
                else countDic[c] = 1;
            }
            #endregion

            #region format board
            List<Item> list = new List<Item>();
            Item prev = default;

            foreach (var c in board)
            {
                if (prev != default && prev.Char == c) prev.Count++;
                else list.Add(prev = new Item { Char = c, Count = 1 });
            }
            #endregion

            int res = -1;

            Helper(list, 0, countDic);

            return res;

            #region helper method

            void Helper(List<Item> list, int i, Dictionary<char, int> countDic)
            {
                if (i == list.Count) return;

                var curr = list[i];

                if (countDic.ContainsKey(curr.Char)) // has curr
                {
                    if (countDic[curr.Char] + curr.Count >= 3) // can remove
                    {
                        // clone list
                        var clone = new List<Item>(list.Count);

                        foreach (var item in list)
                            clone.Add(new Item { Char = item.Char, Count = item.Count });

                        var cloneDic = new Dictionary<char, int>(countDic);
                        cloneDic[curr.Char] -= 3 - curr.Count;// use char
                        ReduceList(clone, i, cloneDic);
                        if (clone.Count == 0) // list is empty -> win
                        {
                            if (res == -1) res = hand.Length - cloneDic.Values.Sum();
                            else res = Math.Min(res, hand.Length - cloneDic.Values.Sum());
                            return;
                        }
                        Helper(clone, 0, cloneDic);
                    }
                }

                // to next char
                Helper(list, i + 1, countDic);

            }

            void ReduceList(List<Item> list, int i, Dictionary<char, int> countDic)
            {
                list.RemoveAt(i);

                if (list.Count == 0) return;

                while (true)
                {
                    if (i >= list.Count || i - 1 < 0) return;

                    var curr = list[i];
                    var prev = list[i - 1];
                    if (curr.Char != prev.Char) return;

                    prev.Count += curr.Count;
                    list.RemoveAt(i--);
                    if (prev.Count < 3) return;

                    if (prev.Count != 3) // if count > 3 -> you can do {1. remove 3 ele} or {2. remove all ele}
                    {
                        prev.Count %= 3;
                        Helper(list, i, countDic);
                    }

                    list.RemoveAt(i);

                }

            }

            #endregion

        }

        // Runtime: 92 ms, faster than 100.00% of C# online submissions for Zuma Game.
        // Memory Usage: 22.5 MB, less than 100.00% of C# online submissions for Zuma Game.
        // emmm... 本想踩一个 啊这,罢了罢了
        public int Try2(string board, string hand)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var c in hand)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }
            List<Item> list = new List<Item>();

            Item prev = default;

            foreach (var c in board)
            {
                if (prev != default && prev.Char == c)
                {
                    prev.Count++;
                }
                else
                {
                    list.Add(prev = new Item { Char = c, Count = 1 });
                }
            }

            int res = -1;

            Helper(list, 0, dic);

            void Helper(List<Item> list, int i, Dictionary<char, int> countDic)
            {
                if (i == list.Count)
                {
                    return;
                }

                var curr = list[i];

                if (countDic.ContainsKey(curr.Char))
                {
                    if (countDic[curr.Char] + curr.Count >= 3)
                    {
                        var clone = new List<Item>(list.Count);

                        foreach (var item in list)
                        {
                            clone.Add(new Item { Char = item.Char, Count = item.Count });
                        }

                        var cloneDic = new Dictionary<char, int>(countDic);
                        cloneDic[curr.Char] -= 3 - curr.Count;
                        ReduceList(clone, i, cloneDic);
                        if (clone.Count == 0)
                        {
                            if (res == -1) res = hand.Length - cloneDic.Values.Sum();
                            else res = Math.Min(res, hand.Length - cloneDic.Values.Sum());
                            return;
                        }
                        Helper(clone, 0, cloneDic);
                    }
                }

                Helper(list, i + 1, countDic);

            }

            void ReduceList(List<Item> list, int i, Dictionary<char, int> countDic)
            {
                list.RemoveAt(i);

                if (list.Count == 0) return;

                while (true)
                {
                    if (i >= list.Count || i - 1 < 0) return;

                    var curr = list[i];
                    var prev = list[i - 1];
                    if (curr.Char != prev.Char) return;

                    prev.Count += curr.Count;
                    list.RemoveAt(i--);
                    if (prev.Count < 3) return;

                    // 若 总和大于3 则此处有两个选择：a.删除3个 b.全部删除... [是个鬼Zuma,哪有这规则]
                    if(prev.Count != 3)
                    {
                        prev.Count %= 3;
                        Helper(list, i, countDic);
                    }

                    list.RemoveAt(i);

                }

            }

            return res;
        }

        public int Try(string board, string hand)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var c in hand)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }
            List<Item> list = new List<Item>();

            Item prev = default;

            foreach (var c in board)
            {
                if (prev != default && prev.Char == c)
                {
                    prev.Count++;
                }
                else
                {
                    list.Add(prev = new Item { Char = c, Count = 1 });
                }
            }

            int res = -1;

            Helper(list, 0, dic);

            void Helper(List<Item> list, int i, Dictionary<char, int> countDic)
            {
                if (i == list.Count)
                {
                    return;
                }

                var curr = list[i];

                if (countDic.ContainsKey(curr.Char))
                {
                    if(countDic[curr.Char] + curr.Count >= 3)
                    {
                        var clone = new List<Item>(list.Count);

                        foreach (var item in list)
                        {
                            clone.Add(new Item { Char = item.Char, Count = item.Count });
                        }

                        var cloneDic = new Dictionary<char, int>(countDic);
                        cloneDic[curr.Char] -= 3 - curr.Count;
                        ReduceList(clone, i);
                        if (clone.Count == 0)
                        {
                            if (res == -1) res = hand.Length - cloneDic.Values.Sum();
                            else res = Math.Min(res, hand.Length - cloneDic.Values.Sum());
                            return;
                        }
                        Helper(clone, 0, cloneDic);
                    }
                }

                Helper(list, i + 1, countDic);

            }

            void ReduceList(List<Item> list, int i)
            {
                list.RemoveAt(i);

                if (list.Count == 0) return;

                while (true)
                {
                    if (i >= list.Count || i - 1 < 0) return;

                    var curr = list[i];
                    var prev = list[i - 1];
                    if (curr.Char != prev.Char) return;

                    prev.Count = prev.Count + curr.Count;
                    list.RemoveAt(i);
                    if (prev.Count < 3) return;

                    // 若 总和大于3 则此处有两个选择：a.删除3个 b.全部删除... [是个鬼Zuma,哪有这规则]
                    list.RemoveAt(i - 1);
                    i = i - 1;

                }

            }

            return res;
        }

        public int Slow(string board, string hand)
        {

            // 红(R)，黄(Y)，蓝(B)，绿(G)和白(W)

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var c in hand)
            {
                if (dic.ContainsKey(c)) dic[c]++;
                else dic[c] = 1;
            }
            List<(char, int)> list = new List<(char, int)>();

            (char, int) prev = default;

            foreach (var c in board)
            {
                if (prev != default && prev.Item1 == c)
                {
                    prev.Item2++;
                }
                else
                {
                    prev = (c, 1);
                    list.Add(prev);
                }
            }

            int res = -1;

            Helper(list, 0, dic);

            void Helper(List<(char, int)> list, int i, Dictionary<char, int> countDic)
            {
                if (i == list.Count)
                {
                    return;
                }

                var curr = list[i];

                if (countDic.ContainsKey(curr.Item1))
                {
                    var old = countDic[curr.Item1];
                    var oldNum = curr.Item2;

                    int max = Math.Min(oldNum + old, 3);

                    for (int j = max; j >= oldNum; j--)
                    {
                        countDic[curr.Item1] = old - (j - oldNum);
                        if (j == 3)
                        {
                            var clone = new List<(char, int)>(list);
                            ReduceList(clone, i);
                            if (clone.Count == 0)
                            {
                                if (res == -1) res = hand.Length - countDic.Values.Sum();
                                else res = Math.Min(res, hand.Length - countDic.Values.Sum());
                                return;
                            }
                            Helper(clone, 0, countDic);
                        }
                        else
                        {
                            Helper(list, i + 1, countDic);
                        }
                    }

                    curr.Item2 = oldNum;
                    countDic[curr.Item1] = old;
                }

                Helper(list, i + 1, countDic);

            }

            void ReduceList(List<(char, int)> list, int i)
            {
                list.RemoveAt(i);

                if (list.Count == 0) return;

                while (true)
                {
                    if (i >= list.Count || i - 1 < 0) return;

                    var curr = list[i];
                    var prev = list[i - 1];
                    if (curr.Item1 != prev.Item1) return;

                    prev.Item2 = (prev.Item2 + curr.Item2) % 3;
                    list.RemoveAt(i);
                    if (prev.Item2 != 0) return;

                    list.RemoveAt(i - 1);
                    i = i - 1;

                }

            }

            return res;

        }

    }
}
