using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week5
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/30/2021 4:43:51 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/597/week-5-april-29th-april-30th/3726/
    /// @des : 
    /// </summary>
    public class Powerful_Integers
    {

        // Constraints:
        //1 <= x, y <= 100
        //0 <= bound <= 10^6
        public IList<int> Try(int x, int y, int bound)
        {
            if (x == 1 && y == 1) return new[] { 2 };

            ISet<int> set = new HashSet<int>();
            if (x == 1)
            {
                var b = y;
                while (x + b <= bound)
                {
                    set.Add(x + y);
                    b *= y;
                }
            }
            else if (y == 1)
            {
                var a = x;
                while (a + y <= bound)
                {
                    set.Add(x + y);
                    a *= x;
                }
            }
            else
            {
                int a = 1;
                while (true)
                {
                    int b = 1;
                    if (a + b > bound)
                    {
                        break;
                    }
                    set.Add(a + b);
                    if (y != 1)
                    {
                        while (true)
                        {
                            b *= y;
                            if (a + b > bound)
                            {
                                break;
                            }
                            set.Add(a + b);
                        }
                    }
                    if (x == 1) break;
                    a *= x;
                }
            }

            return set.ToArray();

        }

        // Runtime: 204 ms
        // Memory Usage: 26.3 MB
        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            ISet<int> set = new HashSet<int>();

            int a = 1;
            while (true)
            {
                int b = 1;
                if (a + b > bound)
                {
                    break;
                }
                set.Add(a + b);
                if (y != 1)
                {
                    while (true)
                    {
                        b *= y;
                        if (a + b > bound)
                        {
                            break;
                        }
                        set.Add(a + b);
                    }
                }
                if (x == 1) break;
                a *= x;
            }

            return set.ToArray();

        }

    }
}
