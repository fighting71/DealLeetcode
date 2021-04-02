using Command.CommonStruct;
using Command.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2021 2:06:49 PM
    /// @source : https://leetcode.com/problems/find-k-th-smallest-pair-distance/
    /// @des : 
    /// </summary>
    [Obsolete("凡是根据位置找值的，优先考虑二分法... ")]
    public class Find_K_th_Smallest_Pair_Distance
    {

        // Note:
        //2 <= len(nums) <= 10000.
        //0 <= nums[i] < 1000000.
        //1 <= k <= len(nums) * (len(nums) - 1) / 2.

        // source: https://blog.csdn.net/u013300579/article/details/78395228
        // remark: 淦！ 想到了二分法，但没想到怎么二分...
        public int OtherSolution(int[] nums, int k)
        {
            Array.Sort(nums);

            int l = 0;
            int h = nums[nums.Length - 1] - nums[0];
            while (l < h)
            {//二分查找，因为当count==k时，搜索到的m差值可能并不存在，需要继续循环判断，直到范围确定           
                int m = (l + h) / 2;
                //search
                //使用窗口思想，判断差值<=k的个数，r-l即表示[l,r]间间隔<m的个数（每确定一个窗口就新增加了（r-l+1）- 1个差值对）
                // 《滑动窗口》找出小于m的共有多少个
                // *真巧妙
                int left = 0;
                int count = 0;
                //for (int right = 0; right < nums.Length; right++) // 遍历集合
                for (int right = 1; right < nums.Length; right++) // 遍历集合
                {
                    // 若是 [left, right] > m 则left+1
                    // 为啥left++, 若[left, right] > m 则 [left, right + 1] 必定 > m 故应该跳过这种情况，便于复用+计算数量
                    while (nums[right] - nums[left] > m)
                    {
                        left++;
                    }
                    count += right - left;
                }
                /*注意，下面这种写法是错误的，因为比如l=3，r=4，m=(3+4)/2 = 3(因为是向下取整)，所以此次迭代有可能l=m后，l=3，r=4陷入死循环！
                if(count<=k){
                    l = m ;
                }else{
                    h = m-1;
                }
                */

                if (count >= k) // 由于中间值不一定存在，故需要继续收缩...
                {
                    h = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            return l;
        }

        class Item
        {
            public int Value { get; set; }
            public int Index { get; set; }
        }

        public int Try2(int[] nums, int k)
        {
            Array.Sort(nums);

            int len = nums.Length;

            int[] log = new int[len - 1];

            int min = int.MaxValue, max = int.MinValue;
            ListNode<Item> root = null,last = null;

            for (int i = 0; i < len - 1; i++)
            {
                AddNode(new ListNode<Item>(new Item() { Index = 1, Value = nums[i + 1] - nums[i] }));
                log[i] = i + 1;
            }

            int res = 0;
            while (k-- > 0)
            {
                res = root.val.Value;
                min = root.next.val.Value;
                var index = root.val.Index;
                root = root.next;
                if(++log[index] != len)
                {
                    AddNode(new ListNode<Item>(new Item { Index = index, Value = log[index] - nums[index] }));
                }

            }

            return res;

            void AddNode(ListNode<Item> node)
            {
                if(node.val.Value <= min) {
                    node.next = root;
                    root = node;
                    min = node.val.Value;
                    return;
                }

                if(node.val.Value >= max)
                {
                    if(last != null)
                    {
                        last.next = node;
                    } 
                    else
                    {
                        root.next = node;
                    }
                    last = node;
                    max = node.val.Value;
                    return;
                }

                ListNode<Item> prev = root, next = root.next;

                while (next.val.Value < node.val.Value)
                {
                    prev = next;
                    next = next.next;
                }
                node.next = next;
                prev.next = node;
            }

        }

        // slow
        public int Try(int[] nums, int k)
        {
            Array.Sort(nums);

            int len = nums.Length;

            int[] log = new int[len - 1];

            for (int i = 0; i < len - 1; i++)
            {
                log[i] = i + 1;
            }

            int min = 0;
            while (k-- > 0)
            {
                min = int.MaxValue;
                int minIndex = -1;
                for (int i = 0; i < len - 1; i++)
                {
                    if (log[i] == len) continue;

                    var diff = nums[log[i]] - nums[i];
                    if (diff < min)
                    {
                        min = diff;
                        minIndex = i;
                    }
                }
                log[minIndex]++;
            }

            return min;

        }

        public int Simple(int[] nums, int k)
        {

            List<int> distance = new List<int>();

            int len = nums.Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    distance.Add(Math.Abs(nums[j] - nums[i]));
                }
            }

            int[] sort = distance.OrderBy(u => u).ToArray();

            ShowTools.Show(sort);

            return sort[k - 1];
        }
    }
}
