using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week1
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 2:25:28 PM
    /// @source : https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3697/
    /// @des : 
    /// </summary>
    public class Global_and_Local_Inversions
    {

        //A will be a permutation of [0, 1, ..., A.length - 1].
        // A will have length in range[1, 5000].
        //The time limit for this problem has been reduced.


        public bool Solution2(int[] A)
        {

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] == i) continue;

                if (A[i] > i + 1 || A[i + 1] > i + 1) return false;
                i++;

            }

            //for (int i = 1; i < A.Length; i += 2)
            //    if (A[i] > i || A[i - 1] > i) return false;
            return true;
        }

        // Your runtime beats 80.00 %
        public bool Try(int[] A)
        {
            int min = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] == min)
                {
                    min++;
                    continue;
                }

                if(A[i] == min + 1 && A[i + 1] == min)
                {
                    i++;
                    min += 2;
                    continue;
                }
                return false;

            }
            return true;
        }

        // bug..
        public bool IsIdealPermutation(int[] A)
        {
            int global = 0, local = 0;

            List<int> list = Enumerable.Range(0, A.Length).ToList();

            for (int i = 0; i < A.Length - 1; i++)
            {
                var min = list[0]; 

                if (A[i] == min)
                {
                    list.RemoveAt(0);
                    continue;
                }

                global++;

                if (A[i] > A[i + 1]) local++;

            }
            return global == local;
        }
    }
}
