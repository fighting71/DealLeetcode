using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2020.November.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/18/2020 10:39:10 AM
    /// @source : https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3534/
    /// @des : 
    /// </summary>
    [Obsolete]
    public class Mirror_Reflection
    {
        // 1 <= p <= 1000
        // 0 <= q <= p

        // https://leetcode.com/problems/mirror-reflection/discuss/146336/Java-solution-with-an-easy-to-understand-explanation
        public int OtherSolution(int p, int q)
        {
            int m = q, n = p;
            while (m % 2 == 0 && n % 2 == 0)
            {
                m /= 2;
                n /= 2;
            }
            if (m % 2 == 0 && n % 2 == 1) return 0;
            if (m % 2 == 1 && n % 2 == 1) return 1;
            if (m % 2 == 1 && n % 2 == 0) return 2;
            return -1;
        }
        private enum Direction
        {
            Top = 0,
            Bottom = 1,
            Left = 2,
            Right = 3
        }

        public int MirrorReflection(int p, int q)
        {
            if (q == 0) return 0;
            if (p == q) return 1;
            if (p % q == 2) return 2;

            Direction direction = Direction.Right;

            int position = q;

            while (true)
            {
                if(position == 0)
                {

                }
                if(position == p)
                {

                }
                if (p % position == 0)
                {

                }
                if ((p % (position * 2)) == 0)
                {

                }



            }

            return default;

        }

    }
}
