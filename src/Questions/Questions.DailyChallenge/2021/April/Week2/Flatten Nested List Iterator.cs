using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week2
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/13/2021 5:14:47 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3706/
    /// @des : 
    /// </summary>
    public class Flatten_Nested_List_Iterator
    {

        // 1 <= nestedList.length <= 500
        // The values of the integers in the nested list is in the range[-106, 106].

        // Your runtime beats 45.65 %
        // 告辞.
        public class NestedIterator
        {
            Queue<int> queue;
            public NestedIterator(IList<NestedInteger> nestedList)
            {
                queue = new Queue<int>();
                Help(nestedList);
            }

            public void Help(IList<NestedInteger> list)
            {
                foreach (var item in list)
                {
                    if (item.IsInteger())
                    {
                        queue.Enqueue(item.GetInteger());
                    }
                    else
                    {
                        Help(item.GetList());
                    }
                }
            }

            public bool HasNext()
            {
                return queue.Count > 0;
            }

            public int Next()
            {
                return queue.Dequeue();
            }

        }

        // 虽然通过但很slow...
        public class NestedIterator1 {

            int i, j;
            List<List<int>> resList;
            public NestedIterator1(IList<NestedInteger> nestedList)
            {
                resList = new List<List<int>>(nestedList.Count);
                for (int i = 0; i < nestedList.Count; i++)
                {
                    var curr = nestedList[i];
                    if (curr.IsInteger())
                    {
                        resList.Add(new List<int>() { curr.GetInteger() });
                    }
                    else
                    {
                        var list = new List<int>();
                        Help(curr.GetList(), list);
                        if(list.Count == 0)
                        {
                            continue;
                        }
                        resList.Add(list);
                    }
                }
            }

            public bool HasNext()
            {
                return i < resList.Count;
            }

            public int Next()
            {
                int res = resList[i][j];
                if(++j == resList[i].Count)
                {
                    i++;
                    j = 0;
                }
                return res;
            }

        }

        #region try
        //private readonly IList<NestedInteger> nestedList;

        //private int _count;
        //private int _i;
        //private int _j;

        //List<int> list = new List<int>();

        //public Flatten_Nested_List_Iterator(IList<NestedInteger> nestedList)
        //{
        //    this.nestedList = nestedList;
        //    _count = nestedList.Count;
        //}

        //public bool HasNext()
        //{
        //    return _i < _count;
        //}

        //public int Next()
        //{
        //    var curr = nestedList[_i];
        //    if (curr.IsInteger())
        //    {
        //        _i++;
        //        return curr.GetInteger();
        //    }
        //    else if (_j < list.Count)
        //    {
        //        if (_j == list.Count - 1) _i++;
        //        return list[_j++];
        //    }
        //    else
        //    {
        //        list.Clear();
        //        Help(curr.GetList(), list);
        //        _j = 1;
        //        return list[0];
        //    }
        //}

        #endregion

        public static void Help(IList<NestedInteger> list, List<int> res)
        {
            foreach (var item in list)
            {
                if (item.IsInteger())
                {
                    res.Add(item.GetInteger());
                }
                else
                {
                    Help(item.GetList(), res);
                }
            }
        }

    }

    public interface NestedInteger
    {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

    public class CusNestedInteger : NestedInteger
    {
        private readonly int v;

        private bool isInteger;

        public CusNestedInteger(int v)
        {
            this.v = v;
            isInteger = true;
        }

        public CusNestedInteger(IList<NestedInteger> list)
        {
            List = list;
        }

        public IList<NestedInteger> List { get; }

        public int GetInteger()
        {
            return v;
        }

        public IList<NestedInteger> GetList()
        {
            return List;
        }

        public bool IsInteger()
        {
            return isInteger;
        }
    }


}
