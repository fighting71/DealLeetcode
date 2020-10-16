using Command.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020September.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 3:08:29 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Majority_Element_II
    {

        public IList<int> MajorityElement(int[] nums)
        {

            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic[item] = 1;
                }
            }

            return dic.Where(u => u.Value > nums.Length / 3).Select(u => u.Key).ToArray();

        }

        // TODO: how faster?
        public IList<int> Optimize(int[] nums)
        {

            Dictionary<int, int> dic = new Dictionary<int, int>();

            int max = nums.Length / 3;

            foreach (var item in nums)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic[item] = 1;
                }
            }

            IList<int> res = new List<int>();

            foreach (var item in dic)
            {
                if(item.Value > max)
                {
                    res.Add(item.Key);
                }
            }

            return res;

        }

    }
}
