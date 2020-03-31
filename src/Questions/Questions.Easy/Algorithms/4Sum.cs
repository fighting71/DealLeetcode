using Command.Attr;
using Command.Const;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Easy.Algorithms
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2020 3:01:17 PM
    /// @source : https://leetcode.com/problems/4sum/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Complex)]
    public class _4Sum
    {

        /// <summary>
        /// Runtime: 704 ms, faster than 14.75% of C# online submissions for 4Sum.
        /// Memory Usage: 32.3 MB, less than 10.00% of C# online submissions for 4Sum.
        /// 
        /// 至少比上一个好...
        /// 
        /// key : 如何调过不必要的遍历...
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> Solution3(int[] nums, int target)
        {
            int n  = nums.Length;
            IList<IList<int>> res = new List<IList<int>>();
            if (n < 4) return res;
            Array.Sort(nums);
            Dictionary<int, ISet<string>> dic = new Dictionary<int, ISet<string>>();

            for (int i = 0; i < n - 3 && !(nums[i] > 0 && nums[i] > target); i++)
            {
                var num = target - nums[i];
                for (int j = i + 1; j < n - 2 && !(nums[j] > 0 && nums[j] > num); j++)
                {
                    var num2 = num - nums[j];
                    for (int k = j + 1; k < n - 1 && !(nums[k] > 0 && nums[k] > num2); k++)
                    {
                        var num3 = num2 - nums[k];

                        for (int g = k + 1; g < n && !(nums[g] > num3); g++)
                        {

                            if (dic.ContainsKey(num3))
                            {
                                if (dic[num3].Contains($"{nums[i]},{nums[j]},{nums[k]}")) break;
                                res.Add(new List<int>() { nums[i], nums[j], nums[k], num3 });
                                dic[num3].Add($"{nums[i]},{nums[j]},{nums[k]}");
                                break;
                            }

                            if (nums[g] == num3)
                            {
                                res.Add(new List<int>() { nums[i], nums[j], nums[k], num3 });
                                dic[num3] = new HashSet<string>() { $"{nums[i]},{nums[j]},{nums[k]}" };
                            }
                        }
                    }
                }
            }

            return res;

        }

        /// <summary>
        ///  与1差不多
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> Solution2(int[] nums, int target)
        {
            Dictionary<int, IList<IList<int>>> dic = new Dictionary<int, IList<IList<int>>>();

            Array.Sort(nums);

            Help(nums, target, 0, new List<int>(4), dic);

            return dic.SelectMany(u => u.Value).ToList();
        }

        private void Help(int[] arr, int target, int i, IList<int> build, Dictionary<int, IList<IList<int>>> dic)
        {

            if (build.Count == 4)
            {
                if (target == 0)
                {
                    var buildClone = new List<int>(build);
                    buildClone.Add(target);
                    if (dic.ContainsKey(build[3]))
                        dic[build[3]].Add(buildClone);
                    else dic[build[3]] = new List<IList<int>>() { buildClone };
                }
                return;
            }

            for (; i < arr.Length + build.Count - 3 && !(arr[i] >= 0 && arr[i] > target); i++)
            {
                if (build.Count == 3 && dic.TryGetValue(target, out var list))
                {
                    foreach (var item in list)
                    {
                        if (build[0] == item[0] && build[1] == item[1] && build[2] == item[2]) return;
                    }

                    if (arr[i] <= target)
                    {
                        var buildClone = new List<int>(build);
                        buildClone.Add(target);
                        dic[target].Add(buildClone);
                    }
                    return;
                }

                build.Add(arr[i]);
                Help(arr, target - arr[i], i + 1, build, dic);
                build.RemoveAt(build.Count - 1);
            }

        }

        Dictionary<int, List<int[]>> dic = new Dictionary<int, List<int[]>>();

        public IList<IList<int>> Solution(int[] nums, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();

            Array.Sort(nums);

            Help(nums, target, 0, new List<int>(4), res);

            return res;
        }

        /// <summary>
        /// Runtime: 1980 ms, faster than 5.33% of C# online submissions for 4Sum.
        /// Memory Usage: 32.2 MB, less than 10.00% of C# online submissions for 4Sum.
        /// cry ~~
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <param name="i"></param>
        /// <param name="build"></param>
        /// <param name="res"></param>
        private void Help(int[] arr, int target, int i, IList<int> build, IList<IList<int>> res)
        {

            if (build.Count == 4)
            {
                if (target == 0)
                {
                    res.Add(new List<int>(build));
                    if (dic.ContainsKey(build[3]))
                        dic[build[3]].Add(new[] { build[0], build[1], build[2] });
                    else dic[build[3]] = new List<int[]>() { new[] { build[0], build[1], build[2] } };
                }
                return;
            }

            for (; i < arr.Length + build.Count - 3 && !(arr[i] >= 0 && arr[i] > target); i++)
            {
                if (build.Count == 3 && dic.TryGetValue(target, out var list))
                {
                    foreach (var item in list)
                    {
                        if (build[0] == item[0] && build[1] == item[1] && build[2] == item[2]) return;
                    }

                    if (arr[i] <= target)
                    {
                        var buildClone = new List<int>(build);
                        buildClone.Add(target);
                        dic[target].Add(new[] { build[0], build[1], build[2] });
                        res.Add(buildClone);
                    }
                    return;
                }
                build.Add(arr[i]);
                Help(arr, target - arr[i], i + 1, build, res);
                build.RemoveAt(build.Count - 1);
            }

        }

        // bug 过于复杂-》抛弃...
        private void OldHelp(int[] arr, int target, int i, IList<int> build, IList<IList<int>> res)
        {

            if (build.Count == 3)
            {
                if (dic.TryGetValue(target, out var list))
                {

                    foreach (var item in list)
                    {
                        if (build[0] == item[0] && build[1] == item[1] && build[2] == item[2]) return;
                    }

                    if (arr[i] <= target)
                    {
                        var buildClone = new List<int>(build);
                        buildClone.Add(target);
                        dic[target].Add(new[] { build[0], build[1], build[2] });
                        res.Add(buildClone);
                    }
                    return;
                }

                if (arr[i] > target) return;

            }

            if (build.Count == 4)
            {
                if (target == 0)
                {
                    res.Add(new List<int>(build));
                    if (dic.ContainsKey(build[3]))
                        dic[build[3]].Add(new[] { build[0], build[1], build[2] });
                    else dic[build[3]] = new List<int[]>() { new[] { build[0], build[1], build[2] } };
                }
                return;
            }

            if (i == arr.Length || arr.Length - i + build.Count < 4) return;

            var plus = target - arr[i];

            build.Add(arr[i]);

            Help(arr, plus, i + 1, build, res);

            build.RemoveAt(build.Count - 1);

            Help(arr, target, i + 1, build, res);


        }


    }
}
