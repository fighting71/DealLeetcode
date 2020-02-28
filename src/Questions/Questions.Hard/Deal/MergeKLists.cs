using Command.Attr;
using Command.CommonStruct;
using Command.Const;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/25/2020 4:38:48 PM
    /// @source : https://leetcode.com/problems/merge-k-sorted-lists/
    /// @des : 链表复杂排序
    /// </summary>
    [Description(FlagConst.Sort)]
    public class MergeKLists
    {

        /**
         * Runtime: 520 ms(emm...), faster than 24.66% of C# online submissions for Merge k Sorted Lists.
         * Memory Usage: 29.2 MB, less than 8.33% of C# online submissions for Merge k Sorted Lists.
         * 
         * 简单暴力法
         * 
         * can solov ~
         * 
         */
        public ListNode Simple(ListNode[] lists)
        {
            ListNode root = null,node = root;
            // 每次取最小的节点出来
            int minIndex, min,len = lists.Length;

            // 遍历节点

            while (true)
            {
                minIndex = -1; min = int.MaxValue;
                for (int i = 0; i < len; i++)
                {
                    if (lists[i] == null) continue;
                    if(lists[i].val< min)
                    {
                        min = lists[i].val;
                        minIndex = i;
                    }
                }

                // 没取到表示没元素了
                if (minIndex == -1) return root;

                // 根节点特殊处理.
                if(root == null)
                    node = (root = new ListNode(min));
                else
                    node = (node.next = new ListNode(min));

                // 然后将最小节点移动一下-》下次遍历排除
                lists[minIndex] = lists[minIndex].next;

            }

        }

        /// <summary>
        /// 
        /// Runtime: 108 ms, faster than 93.54% of C# online submissions for Merge k Sorted Lists.
        /// Memory Usage: 29.1 MB, less than 8.33% of C# online submissions for Merge k Sorted Lists.
        /// 
        /// 考验排序技巧-》借助已实现的排序算法处理，skip
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode Solution(ListNode[] lists)
        {

            List<int> list = new List<int>();
            ListNode node;
            // 遍历并将所有节点值放到集合中
            foreach (var item in lists)
            {
                node = item;

                while (node != null)
                {
                    list.Add(node.val);
                    node = node.next;
                }

            }

            // 将集合进行排序
            if (list.Count == 0) return null;

            // 排序大法好...
            list.Sort();

            ListNode root;
            // 构建root
            node = (root = new ListNode(list[0]));

            for (int i = 1; i < list.Count; i++)
            {
                node = (node.next = new ListNode(list[i]));
            }

            return root;
        }

        /// <summary>
        /// Runtime: 220 ms, faster than 46.19% of C# online submissions for Merge k Sorted Lists.
        /// Memory Usage: 29.1 MB, less than 8.33% of C# online submissions for Merge k Sorted Lists.
        /// 
        /// 慢于Try3...
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode Try4(ListNode[] lists)
        {
            ListNode root = null;
            List<int> list = new List<int>();

            // 遍历并将所有节点值放到集合中
            foreach (var item in lists)
            {
                root = CombinationNodeSort(root, item);
            }

            return root;
        }

        public ListNode CombinationNodeSort(ListNode node,ListNode node2)
        {
            if (node == null) return node2;
            if (node2 == null) return node;

            ListNode root,eachNode;

            if (node.val < node2.val)
            {
                root = node;
                eachNode = node2;
            }
            else
            {
                root = node2;
                eachNode = node;
            }

            ListNode prev = root, next;

            while (eachNode != null)
            {
                next = prev.next;

                if(next == null)
                {
                    prev.next = eachNode;
                    return root;
                }

                if (eachNode.val < next.val)
                {
                    prev.next = eachNode;
                    eachNode = eachNode.next;
                    prev = prev.next;
                    prev.next = next;
                }
                else
                {
                    prev = next;
                }
            }

            return root;

        }

        /// <summary>
        /// 效率还是低...
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode Try2(ListNode[] lists)
        {
            ListNode root = null, node = root, minNode = node;
            int minIndex = 0;
            while (true)
            {
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null) continue;
                    if (minNode == null || lists[i].val < minNode.val)
                    {
                        minNode = lists[i];
                        minIndex = i;
                    }
                }

                if (minNode == null) return root;

                if (root == null)
                    node = (root = minNode);
                else
                    node = (node.next = minNode);

                minNode = minNode.next;
                lists[minIndex] = minNode;

            }
        }
    }
}
