using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal2
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/3/2021 11:14:22 AM
    /// @source : https://leetcode.com/problems/student-attendance-record-ii/
    /// @des : 
    ///     给定一个正整数n，返回长度为n的所有可能的考勤记录，这将被视为有奖励。
    ///     学生考勤记录是只包含以下三个字符的字符串:
    ///     A:没有。
    ///     “L”:晚了。
    ///     “P”:礼物。
    ///     如果一个记录中不包含超过一个“A”(缺席) 且不包含超过两个连续的“L”(迟到)，则该记录被视为有奖励。
    ///     
    ///     target: 返回有奖励的记录数
    ///     
    /// @remark: 感觉像排列组合解法，懒得找公式，直接用dp会比较容易
    /// </summary>
    [Favorite(FlagConst.DP)]
    public class Student_Attendance_Record_II
    {


        /**
         * Explain:        
         * defind dp[i][lCount] [aCount]

                i -> index of records
                lCount -> The record contains the number of L's
                aCount -> The record contains the number of A's
           base case:

	            var last = dp[len - 1]
                next[0][0] = 3; // you can choice {A,L,P}
	            next[1][0] = 3;// you can choice {A,L,P}
	            next[2][0] = 2;// you can choice {A,P}
	            next[0][1] = 2;// you can choice {L,P}
	            next[1][1] = 2;// you can choice {L,P}
	            next[2][1] = 1;// you can choice {P}
            state transition

                dp[i][lCount][aCount] = 
	                dp[i][0][aCount] // append P
	                + dp[i][0][aCount + 1] // append A
	                + dp[i][lCount + 1][aCount] // append L
         */

        // The answer may be very large, return it after mod 10^9 + 7.
        // Note: The value of n won't exceed 100,000.

        // Runtime: 296 ms, faster than 53.33% of C# online submissions for Student Attendance Record II.
        // Memory Usage: 19.4 MB, less than 93.33% of C# online submissions for Student Attendance Record II.
        // 一切顺利~
        public int Try2(int n)
        {

            if (n == 0) return 0;
            const int mod = 1000_000_007;

            // dp 只使用了next
            #region base case // 初始值设1 or 直接给定last值都行.
            int[][] next = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                next[i] = new int[3];
            }

            next[0][0] = 3;
            next[1][0] = 3;
            next[2][0] = 2;
            next[0][1] = 2;
            next[1][1] = 2;
            next[2][1] = 1;
            #endregion

            for (int i = n - 2; i >= 0; i--)
            {
                var curr = new int[4][];
                for (int j = 0; j < curr.Length; j++)
                {
                    curr[j] = new int[3];
                }
                for (int aCount = 0; aCount < 2; aCount++)
                {
                    for (int lCount = 0; lCount < 3; lCount++)
                    {
                        curr[lCount][aCount] = (next[0][aCount] // 追加P
                            + (next[lCount + 1][aCount] // 追加L
                            + next[0][aCount + 1] // 追加A
                            ) % mod) % mod;
                    }
                }
                next = curr;
            }

            return next[0][0];
        }

        public int Try(int n)
        {

            if (n == 0) return 0;
            int mod = 1000_000_007;

            int[][][] dp = new int[n][][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[4][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[3];
                }
            }

            int[][] last = dp[n - 1];
            last[0][0] = 3;
            last[1][0] = 3;
            last[2][0] = 2;
            last[0][1] = 2;
            last[1][1] = 2;
            last[2][1] = 1;

            for (int i = n - 2; i >= 0; i--)
            {
                for (int aCount = 0; aCount < 2; aCount++)
                {
                    for (int lCount = 0; lCount < 3; lCount++)
                    {
                        dp[i][lCount][aCount] = (dp[i + 1][0][aCount] + (dp[i + 1][lCount + 1][aCount] + dp[i + 1][0][aCount + 1]) % mod) % mod;
                    }
                }
            }

            return dp[0][0][0];
        }

        public int Simple(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 3;

            int mod = 1000_000_007;

            return Help(0, 0, 0);

            int Help(int i, int aCount, int lCount)
            {
                if (i == n) return 1;

                bool aFull = aCount == 1, lFull = lCount == 2;


                int res = Help(i + 1, aCount, 0);

                if (aFull && lFull) return res;

                if (!aFull)
                {
                    res = (res + Help(i + 1, aCount + 1, 0)) % mod;
                }
                if (!lFull)
                {
                    res = (res + Help(i + 1, aCount, lCount + 1)) % mod;
                }
                return res % mod;
            }
        }

        public int Show(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 3;

            int mod = 1000_000_007;

            return Help(0, 0, 0, string.Empty);

            int Help(int i, int aCount, int lCount, string str)
            {
                if (i == n)
                {
                    Console.WriteLine(str);
                    return 1;
                }

                bool aFull = aCount == 1, lFull = lCount == 2;

                int res = Help(i + 1, aCount, 0, str + 'P');

                if (aFull && lFull) return res;

                if (!aFull)
                {
                    res = (res + Help(i + 1, aCount + 1, 0, str + 'A')) % mod;
                }
                if (!lFull)
                {
                    res = (res + Help(i + 1, aCount, lCount + 1, str + 'L')) % mod;
                }
                return res % mod;
            }
        }

    }
}
