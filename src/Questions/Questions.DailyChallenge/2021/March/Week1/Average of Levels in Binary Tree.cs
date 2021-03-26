using Command.CommonStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/6/2021 1:51:24 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3661/
    /// @des : 
    /// </summary>
    public class Average_of_Levels_in_Binary_Tree
    {
        // Your runtime beats 41.86 %
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<Item> list = new List<Item>();

            Helper(root, 0);

            return list.Select(u => u.Sum / (double)u.Count).ToArray();

            void Helper(TreeNode node, int depth)
            {
                if (node == null) return;

                if (list.Count == depth)
                {
                    list.Add(new Item { Count = 1, Sum = node.val });
                }
                else
                {
                    Item item = list[depth];
                    item.Count++;
                    item.Sum += node.val;
                }

                Helper(node.left, depth + 1);
                Helper(node.right, depth + 1);

            }

        }
        private class Item
        {
            // 我丢，int32可能越界
            public long Sum { get; set; }
            public int Count { get; set; }
        }
    }
}
