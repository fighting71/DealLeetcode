using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/6/2021 3:30:25 PM
    /// @source : https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/
    /// @des : 告辞  10%
    /// </summary>
    [Optimize]
    public class RandomizedCollection
    {

        /** Initialize your data structure here. */
        public RandomizedCollection()
        {

        }

        List<int> list = new List<int>();

        Random rand = new Random();

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            bool res = true;
            if (list.Contains(val)) res = false;
            list.Add(val);
            return res;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            return list.Remove(val);
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            if (list.Count == 0) return 0;

            return list[rand.Next(list.Count)];
        }
    }

}
