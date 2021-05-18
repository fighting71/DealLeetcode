using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.May.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/18/2021 4:49:46 PM
    /// @source : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/600/week-3-may-15th-may-21st/3747/
    /// @des : 
    /// </summary>
    [Optimize(FlagConst.Slow)]
    public class Find_Duplicate_File_in_System
    {

        // Your runtime beats 53.13 %
        public IList<IList<string>> FindDuplicate(string[] paths)
        {

            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();

            foreach (var path in paths)
            {

                string[] arr = path.Split(' ');

                var floder = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    var file = arr[i];

                    int leftStart = file.IndexOf("(");
                    var content = file.AsSpan(leftStart).ToString();
                    var fullPath = floder + '/' + file.AsSpan(0, leftStart).ToString();

                    if (dic.TryGetValue(content, out var list))
                    {
                        list.Add(fullPath);
                    }
                    else
                    {
                        dic[content] = new List<string>() { fullPath };
                    }

                }

            }

            return dic.Where(u => u.Value.Count > 1).Select(u => u.Value).ToArray();

        }

    }
}
