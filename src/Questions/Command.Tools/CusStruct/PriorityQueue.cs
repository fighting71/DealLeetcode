using System;
using System.Collections.Generic;
using System.Text;

namespace Command.CusStruct
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/29/2021 9:49:51 AM
    /// @source : https://blog.csdn.net/sigmarising/article/details/114625754
    /// @des : 优先(排序)队列
    /// </summary>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private SortedList<T, int> list = new SortedList<T, int>();
        private int count = 0;

        public void Add(T item)
        {
            if (list.ContainsKey(item)) list[item]++;
            else list.Add(item, 1);

            count++;
        }

        public T PopFirst()
        {
            return Pop(0);
            if (Size() == 0) return default(T);
            T result = list.Keys[0];
            if (--list[result] == 0)
                list.RemoveAt(0);

            count--;
            return result;
        }

        public T PopLast()
        {
            return Pop(list.Count - 1);
            if (Size() == 0) return default(T);
            int index = list.Count - 1;
            T result = list.Keys[index];
            if (--list[result] == 0)
                list.RemoveAt(index);

            count--;
            return result;
        }

        private T Pop(int index)
        {
            if (index < 0 || Size() <= index) return default(T);
            T result = list.Keys[index];
            if (--list[result] == 0)
                list.RemoveAt(index);

            count--;
            return result;
        }

        public int Size()
        {
            return count;
        }

        public T PeekFirst()
        {
            if (Size() == 0) return default(T);
            return list.Keys[0];
        }

        public T PeekLast()
        {
            if (Size() == 0) return default(T);
            int index = list.Count - 1;
            return list.Keys[index];
        }
    }
}
