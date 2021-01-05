using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/16/2020 2:14:49 PM
    /// @source :https://leetcode.com/problems/patching-array/ 
    /// @des :
    ///     给定一个已排序的正整数数组nums和一个整数n，向数组中添加/修补元素，使得数组中某些元素的和可以构成[1,n]范围内的任何数字。返回所需的最小补丁数量。
    /// </summary>
    [Favorite(FlagConst.Special, "耐人寻味，看似条条大路通罗马，实则只有一条出口...")]
    public class Patching_Array
    {
        public abstract class Solution
        {

            public int Run(int[] nums, int n)
            {
                #region base case
                if (n < 1) return 0;// 区间[1,n]在(n<1)的情况下不包含任何数.
                #endregion
                return GetRes(nums, n);
            }

            protected abstract int GetRes(int[] nums, int n);

            #region 计算nums所能到达的点
            protected void getarea(int[] nums, int index, int build, ISet<int> set)
            {
                if (index == nums.Length)
                {
                    set.Add(build);
                    return;
                }
                // 每次都有两个选择:添加此数字或不添加
                getarea(nums, index + 1, build, set);
                getarea(nums, index + 1, build + nums[index], set);
            }
            protected void GetArea(int[] nums, int index, int build, ISet<int> set, int max)
            {
                if (build > max) return;
                if (index == nums.Length)
                {
                    set.Add(build);
                    return;
                }
                // 每次都有两个选择:添加此数字或不添加
                GetArea(nums, index + 1, build, set, max);
                GetArea(nums, index + 1, build + nums[index], set, max);
            }
            protected void GetArea(int[] nums, int index, int build, bool[] has)
            {
                // 因为题意为正整数，故再加下去并无任何意义
                if (build > has.Length) return;
                if (index == nums.Length)
                {
                    has[build] = true;
                    return;
                }
                // 每次都有两个选择:添加此数字或不添加
                GetArea(nums, index + 1, build, has);
                GetArea(nums, index + 1, build + nums[index], has);
            }
            #endregion
        }

        public class Try : Solution
        {
            // slow 缺陷 n较大时比较耗时且out of memory ... 
            protected override int GetRes(int[] nums, int n)
            {

                bool[] has = new bool[n + 1];
                GetArea(nums, 0, 0, has);

                // 获取需要补充数
                int need = 0,
                    // 补丁数
                    fix = 0;

                for (int i = 0; i < n + 1; i++)
                {
                    if (!has[i]) need++;
                }

                while (need > 0) // 无限循环直至无可需补充的数
                {
                    int minNeed = need + 1;// 单次最小补充数
                    for (int i = 1; ; i++)
                    {
                        int currNeed = need;// 当补充数字i后所需的补充数
                        for (int j = 0; j < n + 1 - i; j++) // *** slow 当n比较大时，循环比较久
                        {
                            if (has[j] && !has[j + i]) currNeed--;
                        }

                        // 若补充i+1后的所需的补充数 > 补充i后的所需的补充数 则补充i, 因为i越大，填充的位置越少
                        if (currNeed >= minNeed)
                        {
                            i--;
                            Console.Write(i + "  ");
                            for (int j = n; j >= i; j--)
                            {
                                if (has[j - i]) has[j] = true;
                            }
                            fix++;
                            need = minNeed;
                            break;
                        }
                        else minNeed = currNeed;
                    }
                }

                return fix;
            }
        }

        // 同样存在n较大的情况下计算过长
        public class Try2 : Solution
        {
            protected override int GetRes(int[] nums, int n)
            {
                ISet<int> set = new HashSet<int>() { 0 };

                GetArea(nums, 0, 0, set, n);
                int fix = 0;

                while (set.Count <= n)
                {
                    int max = 0;
                    for (int i = 1; ; i++)
                    {
                        int curr = 0;
                        foreach (var item in set)
                        {
                            if (item + i <= n && !set.Contains(item + i)) curr++;
                        }

                        if (curr < max)
                        {
                            i--;
                            foreach (var item in set.ToArray())
                            {
                                if (item + i <= n)
                                    set.Add(item + i);
                            }
                            fix++;
                            break;
                        }
                        else max = curr;
                    }
                }
                return fix;
            }
        }

        public class Try3 : Solution
        {
            protected override int GetRes(int[] nums, int n)
            {

                // a.填充[1,n]需要多少个数字

                var list = new List<int>();

                int max = 1, fix = 1;

                n--;
                // 通过try方案可知，最优方案为1 2 4 ...n^2 即 * 2
                while (n > 0)
                {
                    fix++;
                    max *= 2;
                    if (n > max)
                    {
                        list.Add(max);
                        n -= max;
                    }
                    else
                    {
                        list.Add(max);
                        break;
                    }
                }

                // b.有多少个数字可被nums中的数字代替...
                // ==> otherSolution,此处一个误导在于，追究于用nums替换最优方案中的数，而题意主要是计算fix次数. 

                return fix;
            }

        }

        // source : https://leetcode.com/problems/patching-array/discuss/78488/Solution-%2B-explanation
        // desc: OMG
        public class OtherSolution : Solution
        {
            protected override int GetRes(int[] nums, int n)
            {
                /*
                 * 
                 * 让我们miss成为[0,n]可能会丢失的最小总和。意味着我们已经知道我们可以在中建立所有和[0,miss)。然后，如果num <= miss给定数组中有一个数字，则可以将其加到这些较小的总和中，以建立所有总和[0,miss+num)。如果不这样做，则必须将这样的数字添加到数组中，最好添加miss自身，以最大化覆盖范围。
                 * 
                 * miss += nums[i++]; ==> amazing... 就是少了这步...
                 * 
                 */
                long miss = 1, i = 0;
                int added = 0;
                while (miss <= n)
                {
                    if (i < nums.Length && nums[i] <= miss)
                    {
                        miss += nums[i++];
                    }
                    else
                    {
                        miss += miss;
                        added++;
                    }
                }
                return added;
            }
        }


    }
}
