using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020September.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/25/2020 6:43:00 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Largest_Number
    {
        // bug
        public string LargestNumber(int[] nums)
        {

            // 相当于排序处理

            //Input: [3,30,34,5,9,]
            //Output: "9534330"

            StringBuilder builder = new StringBuilder();

            int len = nums.Length,maxWid = 1;

            int[] lenArr = new int[len];

            for (int i = 0; i < len; i++)
            {
                int wid = 1,emp = nums[i];
                while(emp >= 10)
                {
                    emp /= 10;
                    wid++;
                }
                maxWid = Math.Max(maxWid, wid);
                lenArr[i] = wid;
            }

            IEnumerable<int> enumerable = nums.Select((u,index) =>
            {
                var emp = u;

                var diff = maxWid - lenArr[index];

                while (diff-->0)
                {
                    emp = emp * 10 + emp % 10;
                }

                return new { num = u, compare = emp };
            }).OrderByDescending(u=>u.compare).Select(u=>u.num);

            foreach (var item in enumerable)
            {
                builder.Append(item);
            }

            return builder.ToString();
        }

    }
}
