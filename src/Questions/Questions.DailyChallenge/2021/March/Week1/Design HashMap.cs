using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/8/2021 2:03:57 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3663/
    /// @des :
    /// </summary>
    [Favorite(FlagConst.Design, "来自Dictionary的简易版")]
    public class Design_HashMap
    {

        // All keys and values will be in the range of [0, 1000000].
        //The number of operations will be in the range of[1, 10000].
        //Please do not use the built-in HashMap library.

        // Your runtime beats 82.38 % of csharp submissions.
        public Design_HashMap()
        {

        }

        int _count;
        int[] _buckets;
        Entry[] _entries;

        struct Entry
        {
            public int hashCode { get; set; }
            public int value { get; set; }
            public int next { get; set; }
        }

        private ref int GetBucket(int hashCode)
        {
            int[] buckets = _buckets;
            return ref buckets[hashCode % buckets.Length];
        }

        // 扩容
        private void Resize(int newSize)
        {
            Entry[] entries = new Entry[newSize];

            int count = _count;
            Array.Copy(_entries, entries, count);
            _buckets = new int[newSize];

            for (int i = 0; i < count; i++)
            {
                // 遍历的是entries 按照与添加类似的规则重新指定 next  更新 bucket √
                if (entries[i].next >= -1)
                {
                    ref int bucket = ref GetBucket(entries[i].hashCode);
                    entries[i].next = bucket - 1; // Value in _buckets is 1-based
                    bucket = i + 1;
                }
            }

            _entries = entries;

        }

        private void Init(int count)
        {
            _buckets = new int[count];
            _entries = new Entry[count];
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            if (_count == 0)
            {
                Init(2);
            }

            Entry[] entries = _entries;
            int hashCode = key;
            ref int bucket = ref GetBucket(key);

            int i = bucket - 1;

            while (true)
            {
                if ((uint)i >= (uint)entries.Length) break;

                if (entries[i].hashCode == hashCode)
                {
                    entries[i].value = value;
                    return;
                }
                i = entries[i].next;
            }

            int count = _count;
            if (count == entries.Length)
            {
                Resize(count * 2);
                bucket = ref GetBucket(hashCode);
            }
            int index = count;
            _count = count + 1;
            entries = _entries;

            ref Entry entry = ref entries[index];
            entry.hashCode = hashCode;
            entry.next = bucket - 1; // Value in _buckets is 1-based
            entry.value = value;
            bucket = index + 1; // Value in _buckets is 1-based

        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            if (_count == 0) return -1;
            Entry[] entries = _entries;
            int hashCode = key;
            int bucket = GetBucket(hashCode);
            int i = bucket - 1;
            while (true)
            {
                if ((uint)i >= (uint)entries.Length) return -1;

                if (entries[i].hashCode == hashCode)
                {
                    return entries[i].value;
                }
                i = entries[i].next;
            }
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            if (_count == 0) return;
            Entry[] entries = _entries;
            int hashCode = key;
            int bucket = GetBucket(hashCode);
            int i = bucket - 1;
            while (true)
            {
                if ((uint)i >= (uint)entries.Length) return;

                if (entries[i].hashCode == hashCode)
                {
                    entries[i].value = -1;
                    return;
                }
                i = entries[i].next;
            }
        }

    }

    public static class Design_HashMapExt
    {
        public static void put(this Design_HashMap map, int key, int value) => map.Put(key, value);
        public static int get(this Design_HashMap map, int key)
        {
            int value = map.Get(key);
            Console.WriteLine(value);
            return value;
        }
        public static void remove(this Design_HashMap map, int key) => map.Remove(key);
    }

}
