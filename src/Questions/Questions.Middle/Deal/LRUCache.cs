using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Middle.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/1 14:57:46
    /// @source : 
    /// @des : 
    /// </summary>
    [Obsolete("越想越复杂，告辞...")]
    public class LRUCache
    {
        private readonly int[] _valueArr;
        private readonly int _capacity;
        private int _count;
        private List<int> _list;
        private int[] _indexArr;
        private int[] _countArr;
        List<int> countList = new List<int>();
        
        public LRUCache(int capacity)
        {
            _valueArr = new int[int.MaxValue];
            _indexArr = new int[int.MaxValue];
            _countArr = new int[int.MaxValue];
            _list = new List<int>(capacity);
            this._capacity = capacity;
            Array.Fill(_valueArr, -1);
        }

        public int Get(int key)
        {
            var count = ++_countArr[key];
            if (count == countList.Count)
            {
                
            }
            var old = _indexArr[key];
            return _valueArr[key];
        }

        public void Put(int key, int value)
        {
            _valueArr[key] = value;
            if (_count == _capacity)
            {
                // 使最近最少使用的项无效。
                _valueArr[_list[0]] = -1;
                _list[0] = key;
                _indexArr[key] = 0;
            }
            else
            {
                _count++;
                _list.Add(key);
                _indexArr[key] = _list.Count - 1;
            }

            _countArr[key] = 0;
        }
    }
}