using Command.CommonStruct;
using Command.Helper;
using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.January.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/24/2021 6:34:44 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMerge_k_Sorted_ListsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Merge_k_Sorted_Lists instance = new Merge_k_Sorted_Lists();

            ListNode tree = new int[] { 1, 4, 5 };

            int[][] arr = JsonConvert.DeserializeObject<int[][]>("[[1,4,5],[1,3,4],[2,6]]");

            ShowTools.Show(instance.Simple(ConvertHelper.ConvertToListNode(arr)));
            ShowTools.Show(instance.Try(ConvertHelper.ConvertToListNode(arr)));

            Func<ListNode[]> getArg = () => {
                var len = random.Next(1000_0);

                var res = new ListNode[len];

                for (int i = 0; i < len; i++)
                {
                    int subLen = random.Next(500);
                    ListNode root = null, curr = root;
                    for (int j = 0; j < subLen; j++)
                    {
                        ListNode node = new ListNode(random.Next(-1000_0, 1000_0));
                        if (j == 0)
                        {
                            root = curr = node;
                        }
                        else
                        {
                            curr.next = node;
                            curr = node;
                        }
                    }
                    res[i] = root;
                }
                return res;
            };

            BaseLibrary.CommonTest(new ListNode[0][], instance.Try, getArg, showArg: false);
            BaseLibrary.CommonTest(new ListNode[0][], instance.Simple, getArg, showArg: false);

        }
    }
}
